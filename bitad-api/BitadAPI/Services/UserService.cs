﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cms;

namespace BitadAPI.Services
{
    public interface IUserService
    {
        public Task<TokenRefreshResponse<DtoUser>> AuthenticateUser(DtoUserLogin userLogin);
        public Task<TokenRefreshResponse<DtoUser>> GetUserById(int id);
        public Task<TokenRefreshResponse<ICollection<DtoLeader>>> GetLeaders(int userid);
        public Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData, string ip);
        public Task<TokenRefreshResponse<DtoWorkshop>> SelectWorkshop(int userId, string workshopCode);
        public Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendance(int issuerId, string attendanceCode);
        public Task<DtoUser> ActivateAccount(string activationCode);
        public Task<TokenRefreshResponse<ICollection<DtoUser>>> GetWinners(int issuerId, int numberOfWinners);
        public Task<DtoUser> IssuePasswordReset(string username);
        public Task<DtoUser> ResetPassword(string resetCode, string newPassword);
        public Task<DtoUser> ResendActivation(string username);
        public Task<DtoUser> ConfirmAccount(string confirmCode);
        public Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendanceWorkshop(int issuerId,
            string attendanceCode, string workshopCode);
    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IWorkshopRepository _workshopRepository;
        private IMapper _mapper;
        private IJwtService _jwtService;
        private IMailService _mailService;

        public UserService(IUserRepository userRepository, IWorkshopRepository workshopRepository, IMapper mapper, IJwtService jwtService, IMailService mailService)
        {
            _userRepository = userRepository;
            _workshopRepository = workshopRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _mailService = mailService;
        }

        public async Task<TokenRefreshResponse<DtoUser>> AuthenticateUser(DtoUserLogin userLogin)
        {
            var user = await _userRepository.GetByPredicate(x => x.Email == userLogin.Email);
            if (user is null) return null;

            var hashedPassword = HashPassword(userLogin.Password, user.PasswordSalt);

            if (user.Password != hashedPassword) return null;

            if (user.ActivationDate is null)
            {
                return new TokenRefreshResponse<DtoUser>
                {
                    Token = null,
                    Body = null,
                    Code = 2
                };
            }

            var dtoUser = _mapper.Map<DtoUser>(user);
            return new TokenRefreshResponse<DtoUser>
            {
                Token = await _jwtService.GetNewToken(user.Id),
                Body = dtoUser,
                Code = 0
            };

        }

        public async Task<TokenRefreshResponse<ICollection<DtoLeader>>> GetLeaders(int userId)
        {
            var leaders = new List<DtoLeader>(20);
            var topUsers = await _userRepository.GetTopUsers(20);
            var position = 1;
            foreach (var user in topUsers)
            {
                leaders.Add(new DtoLeader
                {
                    Email = user.Email,
                    Points = user.CurrentScore,
                    Position = position++
                });
            }
            return new TokenRefreshResponse<ICollection<DtoLeader>>
            {
                Token = await _jwtService.GetNewToken(userId),
                Body = leaders,
                Code = 0
            };
        }

        public async Task<TokenRefreshResponse<DtoUser>> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            var dtoUser = _mapper.Map<DtoUser>(user);
            return new TokenRefreshResponse<DtoUser>
            {
                Body = dtoUser,
                Token = await _jwtService.GetNewToken(id),
                Code = 0
            };
        }



        public async Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData, string ip)
        {
            if (Environment.GetEnvironmentVariable("REGISTRATION_ENALBED") == "disabled")
            {
                return null;
            }

            if (registrationData.AcceptedRegulations != true || registrationData.AcceptedDataProcessing != true)
            {
                return null;
            }

            var registered = await _userRepository.GetManyByPredicate(x => x.CreationIp == ip);
            if (registered.Count > 3)
                return null;

            if (await _userRepository.GetByPredicate(x => x.Email == registrationData.Email) is not null)
                return null;

            var hashed = HashPassword(registrationData.Password);

            var workshopRegistered = false;
            var workshop = await _workshopRepository.GetByCode(registrationData.WorkshopCode);
            if (workshop is not null)
            {
                if (workshop.ParticipantsNumber >= workshop.MaxParticipants)
                {
                    workshop = null;
                }
                else
                {
                    workshopRegistered = true;
                }
            }

            var user = new User
            {
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName,
                Email = registrationData.Email,
                CurrentScore = 0,
                Password = hashed.password,
                PasswordSalt = hashed.salt,
                CreationIp = ip,
                ActivationCode = GenerateRandomCode(),
                ConfirmCode = GenerateRandomCode(),
                AttendanceCode = GenerateRandomCode(),
                Role = UserRole.Guest,
                ShirtSize = registrationData.ShirtSize,
                WorkshopAttendanceCode = workshopRegistered ? GenerateRandomCode() : null,
                BannedFromRoulette = false
                
            };


            var resultUser = await _userRepository.CreateUser(user);

            if (resultUser is null) return null;
            if (workshop is not null)
            {
                resultUser.Workshop = await _workshopRepository.AddParticipant(workshop.Id, resultUser);
            }

            if(Environment.GetEnvironmentVariable("EMAIL_ENABLED") == "enabled")
            {
                _ = Task.Run(async () => await _mailService.SendActivationMail(user.Email, user.ActivationCode, user.FirstName));
            }

            return new DtoRegistrationResponse
            {
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName,
                Email = registrationData.Email,
                Workshop = _mapper.Map<DtoWorkshop>(resultUser.Workshop)
            };
        }

        public async Task<TokenRefreshResponse<DtoWorkshop>> SelectWorkshop(int userId, string workshopCode)
        {
            var workshop = await _workshopRepository.GetByCode(workshopCode);

            var refreshToken = await _jwtService.GetNewToken(userId);

            if (workshop is null || workshop.ParticipantsNumber >= workshop.MaxParticipants)
            {
                return new TokenRefreshResponse<DtoWorkshop>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 403
                };
            }

            var user = await _userRepository.GetById(userId);

            if(user.Workshop is not null)
                return new TokenRefreshResponse<DtoWorkshop>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 1
                };

            user.WorkshopAttendanceCode = GenerateRandomCode();
            var userResult = await _userRepository.UpdateUser(user);

            var result = await _workshopRepository.AddParticipant(workshop.Id, userResult);
            
            return new TokenRefreshResponse<DtoWorkshop>
            {
                Body = _mapper.Map<DtoWorkshop>(result),
                Token = refreshToken,
                Code = 0
            };
        }

        public async Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendance(int issuerId, string attendanceCode)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role == UserRole.Guest)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 401, Message = "Unauthorized"},
                    Token = refreshToken,
                    Code = 403
                };
            }
                
            var user = await _userRepository.GetByPredicate(x => x.AttendanceCode == attendanceCode);
            if (user is null)
            {
                user = await _userRepository.GetByPredicate(x => x.Email == attendanceCode);
            }
            
            if (user is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 404, Message = "No such user"},
                    Token = refreshToken,
                    Code = 404
                };
            }

            if (user.ActivationDate is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 2, Message = "Not activated"},
                    Token = refreshToken,
                    Code = 2
                };
            }
            
            if (user.AttendanceCheckDate is not null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 1, Message = "Already checked"},
                    Token = refreshToken,
                    Code = 1
                };
            }
            
            user.AttendanceCheckDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return new TokenRefreshResponse<DtoAttendanceResult>
            {
                Body = new DtoAttendanceResult {Code = 0, Message = "Ok"},
                Token = refreshToken,
                Code = 0
            }; 

        }
        
        public async Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendanceWorkshop(int issuerId, string attendanceCode, string workshopCode)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role == UserRole.Guest)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 401, Message = "Unauthorized"},
                    Token = refreshToken,
                    Code = 403
                };
            }
                
            var user = await _userRepository.GetByPredicate(x => x.WorkshopAttendanceCode == attendanceCode);
            if (user is null)
            {
                user = await _userRepository.GetByPredicate(x => x.Email == attendanceCode);
            }
            
            if (user is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 404, Message = "No such user"},
                    Token = refreshToken,
                    Code = 404
                };
            }

            if (user.Workshop.Code != workshopCode)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 404, Message = "No such user"},
                    Token = refreshToken,
                    Code = 404
                };
            }

            if (user.ActivationDate is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 2, Message = "Not activated"},
                    Token = refreshToken,
                    Code = 2
                };
            }
            
            if (user.WorkshopAttendanceCheckDate is not null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 1, Message = "Already checked"},
                    Token = refreshToken,
                    Code = 1
                };
            }
            
            user.WorkshopAttendanceCheckDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return new TokenRefreshResponse<DtoAttendanceResult>
            {
                Body = new DtoAttendanceResult {Code = 0, Message = "Ok"},
                Token = refreshToken,
                Code = 0
            }; 

        }

        public async Task<DtoUser> ActivateAccount(string activationCode)
        {
            var user = await _userRepository.GetByPredicate(x => x.ActivationCode == activationCode);
            if (user is null) return null;
            if (user.ActivationDate is not null) return null;
            user.ActivationDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return _mapper.Map<DtoUser>(result);
        }

        public async Task<TokenRefreshResponse<ICollection<DtoUser>>> GetWinners(int issuerId, int numberOfWinners)
        {
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            var rand = new Random(DateTime.Now.Millisecond);
            
            var users = (await _userRepository.GetAll())
                .Where(user => (user.AttendanceCheckDate is not null) && user.Role is UserRole.Guest && !user.BannedFromRoulette).ToList();
            
            if (users.Count < numberOfWinners)
                return new TokenRefreshResponse<ICollection<DtoUser>>
                {
                    Body = new List<DtoUser>(),
                    Token = refreshToken,
                    Code = 3
                };
            
            var winners = new List<DtoUser>();
            var tickets = users.Select(x => x.CurrentScore == 0 ? 1 : x.CurrentScore).ToList();

            var ticketSum = tickets.Sum();

            for (int i = 0; i < numberOfWinners; i++)
            {
                var currentTicket = 0;
                var selectedTicket = rand.Next(1, ticketSum + 1);
                for (int j = 0; j < users.Count; j++)
                {
                    currentTicket += tickets[j];
                    if (currentTicket >= selectedTicket)
                    {
                        winners.Add(_mapper.Map<DtoUser>(users[j]));
                        ticketSum -= tickets[j];
                        users.RemoveAt(j);
                        tickets.RemoveAt(j);
                        break;
                    }
                }
                
            }

            return new TokenRefreshResponse<ICollection<DtoUser>>
            {
                Body = winners,
                Token = refreshToken,
                Code = 2
            };
        }

        public async Task<DtoUser> IssuePasswordReset(string email)
        {
            var user = await _userRepository.GetByPredicate(x => x.Email == email);
            if (user is null) return null;
            if (user.LastPasswordReset > DateTime.Now.AddHours(-1)) return null;

            var resetCode = GenerateRandomCode();
            user.PasswordResetCode = resetCode;
            user.LastPasswordReset = DateTime.Now;
            
            var result = await _userRepository.UpdateUser(user);
            
            if(Environment.GetEnvironmentVariable("EMAIL_ENABLED") == "enabled")
            {
                _ = Task.Run(async () => await _mailService.SendPasswordResetMail(result.Email, result.PasswordResetCode, result.FirstName));
            }

            return _mapper.Map<DtoUser>(result);

        }

        public async Task<DtoUser> ResetPassword(string resetCode, string newPassword)
        {
            var user = await _userRepository.GetByPredicate(x => x.PasswordResetCode == resetCode);
            if (user is null) return null;
            if (user.LastPasswordReset < DateTime.Now.AddDays(-1)) return null;

            var hashed = HashPassword(newPassword);
            user.Password = hashed.password;
            user.PasswordSalt = hashed.salt;
            user.PasswordResetCode = null;

            var result = await _userRepository.UpdateUser(user);
            return _mapper.Map<DtoUser>(result);
        }

        public async Task<DtoUser> ResendActivation(string email)
        {
            var user = await _userRepository.GetByPredicate(x => x.Email == email);
            if (user is null) return null;
            if (user.ActivationDate is not null) return null;
            if (user.ActivationCodeResent > DateTime.Now.AddHours(-1)) return null;
            
            user.ActivationCodeResent = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            if(Environment.GetEnvironmentVariable("EMAIL_ENABLED") == "enabled")
            {
                _ = Task.Run(async () => await _mailService.SendActivationMail(result.Email, result.ActivationCode, result.FirstName));
            }

            return _mapper.Map<DtoUser>(user);

        }

        public async Task<DtoUser> ConfirmAccount(string confirmCode)
        {
            var user = await _userRepository.GetByPredicate(x => x.ConfirmCode == confirmCode);
            if (user.ActivationDate is null) return null;
            if (user.ConfirmDate is not null) return null;
            
            user.ConfirmDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return _mapper.Map<DtoUser>(result);
        }

        private string GenerateWorkshopAttendanceCode()
        {
            var rnd = new Random();
            var codeBuilder = new StringBuilder();
            for(int i=0; i < 5; i++)
            {
                codeBuilder.Append((char)rnd.Next('A', 'Z'));
            }
            return codeBuilder.ToString();
        }

        private string GenerateRandomCode()
        {
            Guid g = Guid.NewGuid();
            string stringCode = Convert.ToBase64String(g.ToByteArray());
            return stringCode.Replace("=", "").
                Replace("/", "").
                Replace("+", "");
        }

        private (string password, string salt) HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var stringSalt = Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (hashed, stringSalt);
        }

        private string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
        
        public async Task BanWorkshopInactiveAccounts(string workshopCode)
        {
            
            var workshop = await _workshopRepository.GetByCode(workshopCode);
            foreach (var participant in workshop.Participants)
            {
                if (participant.WorkshopAttendanceCode is not null && participant.WorkshopAttendanceCheckDate is null)
                {
                    var user = await _userRepository.GetById(participant.Id);
                    user.BannedFromRoulette = true;
                    user = await _userRepository.UpdateUser(user);
                }
            }
            
        }
    }
}
