using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;

namespace BitadAPI.Services
{
    public interface IAdminService
    {
        public Task<TokenRefreshResponse<ICollection<DtoUser>>> GetWinners(int issuerId, int numberOfWinners);
        public Task<TokenRefreshResponse> SendConfirmationMails(int issuerId);
        public Task<TokenRefreshResponse> SendInformationMails(int issuerId, string htmlName, string title);
        public Task<TokenRefreshResponse> ExcludeInactiveUsersFromWorkshops(int issuerId);
        public Task<TokenRefreshResponse<DtoUser>> BanUser(int issuerId, string email);
        public Task<TokenRefreshResponse<DtoUser>> UnbanUser(int issuerId, string email);
    }
    public class AdminService : IAdminService
    {
        private IJwtService _jwtService;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private IWorkshopRepository _workshopRepository;
        private IMailService _mailService;

        public AdminService(IJwtService jwtService, IUserRepository userRepository, IMapper mapper, IWorkshopRepository workshopRepository, IMailService mailService)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
            _mapper = mapper;
            _workshopRepository = workshopRepository;
            _mailService = mailService;
        }
        
        public async Task<TokenRefreshResponse<ICollection<DtoUser>>> GetWinners(int issuerId, int numberOfWinners)
        {
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            var rand = new Random(DateTime.Now.Millisecond);
            var issuer = await _userRepository.GetById(issuerId);
            
            if (issuer.Role != UserRole.Super) return TokenRefreshResponse<ICollection<DtoUser>>.NullResponse(refreshToken, 403);

            var users = (await _userRepository.GetAll())
                .Where(user => (user.AttendanceCheckDate is not null) && user.Role is UserRole.Guest && !user.BannedFromRoulette).ToList();
            
            if (users.Count < numberOfWinners)
                return new TokenRefreshResponse<ICollection<DtoUser>>
                {
                    Body = new List<DtoUser>(),
                    Token = refreshToken,
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
            };
        }
        
        public async Task<TokenRefreshResponse> SendConfirmationMails(int issuerId)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Super)
            {
                return new TokenRefreshResponse
                {
                    Token = refreshToken,
                    Code = 403
                };
            }

            var users = await _userRepository.GetManyByPredicate(x => x.ActivationDate != null);
            
            if(Environment.GetEnvironmentVariable("EMAIL_ENABLED") == "enabled")
            {
                foreach (var user in users)
                {
                    _ = Task.Run(async () => await _mailService.SendConfirmationMail(user.Email, user.ConfirmCode, user.FirstName));
                }
            }

            return new TokenRefreshResponse()
            {
                Token = refreshToken,
                Code = 200
            };


        }
        
        public async Task<TokenRefreshResponse> SendInformationMails(int issuerId, string htmlName, string title)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Super)
            {
                return new TokenRefreshResponse
                {
                    Token = refreshToken,
                    Code = 403
                };
            }

            var users = await _userRepository.GetManyByPredicate(x => x.ActivationDate != null);
            
            if(Environment.GetEnvironmentVariable("EMAIL_ENABLED") == "enabled")
            {
                foreach (var user in users)
                {
                    await _mailService.SendInformationMail(user.Email, user.FirstName, htmlName, title);
                    Thread.Sleep(200);
                }
            }

            return new TokenRefreshResponse()
            {
                Token = refreshToken,
                Code = 200
            };


        }

        

        public async Task<TokenRefreshResponse> ExcludeInactiveUsersFromWorkshops(int issuerId)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Super)
            {
                return new TokenRefreshResponse()
                {
                    Token = refreshToken,
                    Code = 403
                };
            }
            var workshops = await _workshopRepository.GetAll();
            foreach (var workshop in workshops)
            {
                var participants = workshop.Participants;
                foreach (var participant in participants)
                {
                    if (participant.ConfirmDate is null)
                    {
                        var user = await _userRepository.GetById(participant.Id);
                        user.WorkshopAttendanceCode = null;
                        user = await _userRepository.UpdateUser(user);
                        await _workshopRepository.RemoveParticipant(workshop.Id, user);
                    }
                }
            }

            return new TokenRefreshResponse()
            {
                Token = refreshToken,
                Code = 200
            };
        }

        public async Task<TokenRefreshResponse<DtoUser>> BanUser(int issuerId, string email)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var token = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Super)
            {
                return TokenRefreshResponse<DtoUser>.NullResponse(token, 403);
            }

            var userToBan = await _userRepository.GetByPredicate(x => x.Email == email);
            if (userToBan is null)
            {
                return TokenRefreshResponse<DtoUser>.NullResponse(token, 404);
            }

            userToBan.BannedFromRoulette = true;
            var result = await _userRepository.UpdateUser(userToBan);
            return new TokenRefreshResponse<DtoUser>()
            {
                Body = _mapper.Map<DtoUser>(result),
                Token = token,
                Code = 200
            };
        }
        public async Task<TokenRefreshResponse<DtoUser>> UnbanUser(int issuerId, string email)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var token = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Super)
            {
                return TokenRefreshResponse<DtoUser>.NullResponse(token, 403);
            }

            var userToUnban = await _userRepository.GetByPredicate(x => x.Email == email);
            if (userToUnban is null)
            {
                return TokenRefreshResponse<DtoUser>.NullResponse(token, 404);
            }

            userToUnban.BannedFromRoulette = false;
            var result = await _userRepository.UpdateUser(userToUnban);
            return new TokenRefreshResponse<DtoUser>()
            {
                Body = _mapper.Map<DtoUser>(result),
                Token = token,
                Code = 200
            };
        }
        
        private async Task BanWorkshopInactiveAccounts(string workshopCode)
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