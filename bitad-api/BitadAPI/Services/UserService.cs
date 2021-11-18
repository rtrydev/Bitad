using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Common;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;

namespace BitadAPI.Services
{
    public interface IUserService
    {
        public Task<TokenRefreshResponse<DtoUser>> AuthenticateUser(DtoUserLogin userLogin);
        public Task<TokenRefreshResponse<DtoUser>> GetUserById(int id);
        public Task<TokenRefreshResponse<ICollection<DtoLeader>>> GetLeaders(int userid);
        public Task<DtoRegistrationResponse> RegisterUser(DtoRegistration registrationData, string ip);
        public Task<DtoUser> ActivateAccount(string activationCode);
        public Task<DtoUser> IssuePasswordReset(string username);
        public Task<DtoUser> ResetPassword(string resetCode, string newPassword);
        public Task<DtoUser> ResendActivation(string username);
        public Task<DtoUser> ConfirmAccount(string confirmCode);
        
    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IWorkshopRepository _workshopRepository;
        private IMapper _mapper;
        private IJwtService _jwtService;
        private IMailService _mailService;
        private CodeGenerator _generator = new();
        private Hasher _hasher = new();
        

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
            var email = userLogin.Email.ToLower().Trim();
            var user = await _userRepository.GetByPredicate(x => x.Email == email);
            if (user is null) return null;

            var hashedPassword = _hasher.HashPassword(userLogin.Password, user.PasswordSalt);

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

            var email = registrationData.Email.ToLower();
            if (await _userRepository.GetByPredicate(x => x.Email == email) is not null)
                return null;

            var hashed = _hasher.HashPassword(registrationData.Password);

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
                Email = email,
                CurrentScore = 0,
                Password = hashed.password,
                PasswordSalt = hashed.salt,
                CreationIp = ip,
                ActivationCode = _generator.GenerateRandomCode(),
                ConfirmCode = _generator.GenerateRandomCode(),
                AttendanceCode = _generator.GenerateRandomCode(),
                Role = UserRole.Guest,
                ShirtSize = registrationData.ShirtSize,
                WorkshopAttendanceCode = workshopRegistered ? _generator.GenerateRandomCode() : null,
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

        public async Task<DtoUser> ActivateAccount(string activationCode)
        {
            var user = await _userRepository.GetByPredicate(x => x.ActivationCode == activationCode);
            if (user is null) return null;
            if (user.ActivationDate is not null) return null;
            user.ActivationDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return _mapper.Map<DtoUser>(result);
        }

        public async Task<DtoUser> IssuePasswordReset(string email)
        {
            var trimmedEmail = email.ToLower().Trim();
            var user = await _userRepository.GetByPredicate(x => x.Email == trimmedEmail);
            if (user is null) return null;
            if (user.LastPasswordReset > DateTime.Now.AddHours(-1)) return null;

            var resetCode = _generator.GenerateRandomCode();
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

            var hashed = _hasher.HashPassword(newPassword);
            user.Password = hashed.password;
            user.PasswordSalt = hashed.salt;
            user.PasswordResetCode = null;

            var result = await _userRepository.UpdateUser(user);
            return _mapper.Map<DtoUser>(result);
        }

        public async Task<DtoUser> ResendActivation(string email)
        {
            var trimmedEmail = email.ToLower().Trim();
            var user = await _userRepository.GetByPredicate(x => x.Email == trimmedEmail);
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
        
    }
}
