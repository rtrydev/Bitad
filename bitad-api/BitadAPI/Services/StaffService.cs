using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;

namespace BitadAPI.Services
{
    public interface IStaffService
    {
        public Task<ICollection<DtoStaff>> GetAll();
        public Task<TokenRefreshResponse<ICollection<DtoStaff>>> GetAllAdmin(int issuerId);
        public Task<TokenRefreshResponse<DtoUser>> SendConfirmationMails(int issuerId);
        public Task<TokenRefreshResponse<DtoUser>> BanWorkshopInactiveAccounts(int issuerId, string workshopCode);
        public Task<TokenRefreshResponse<DtoUser>> ExcludeInactiveUsersFromWorkshops(int issuerId);
    }

    public class StaffService : IStaffService
    {
        private IStaffRepository staffRepository;
        private IMapper _mapper;
        private IUserRepository _userRepository;
        private IJwtService _jwtService;
        private IMailService _mailService;
        private IWorkshopRepository _workshopRepository;

        public StaffService(IStaffRepository repository, IMapper mapper, IUserRepository userRepository, IJwtService jwtService, IMailService mailService, IWorkshopRepository workshopRepository)
        {
            staffRepository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mailService = mailService;
            _workshopRepository = workshopRepository;
        }

        public async Task<ICollection<DtoStaff>> GetAll()
        {
            var staff = await staffRepository.GetAllPublic();
            foreach (var s in staff)
            {
                s.Contact = null;
            }
            return _mapper.Map<ICollection<Staff>, ICollection<DtoStaff>>(staff);
        }

        public async Task<TokenRefreshResponse<ICollection<DtoStaff>>> GetAllAdmin(int issuerId)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role == UserRole.Guest)
            {
                return new TokenRefreshResponse<ICollection<DtoStaff>>
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 403
                };
            }
            var staff = await staffRepository.GetAll();
            return new TokenRefreshResponse<ICollection<DtoStaff>>
            {
                Body = _mapper.Map<ICollection<Staff>, ICollection<DtoStaff>>(staff),
                Token = refreshToken,
                Code = 200
            };
        }

        public async Task<TokenRefreshResponse<DtoUser>> SendConfirmationMails(int issuerId)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Super)
            {
                return new TokenRefreshResponse<DtoUser>()
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 403
                };
            }

            var users = await _userRepository.GetManyByPredicate(x => x.ActivationDate != null);
            
            if(Environment.GetEnvironmentVariable("EMAIL_ENABLED") == "enabled")
            {
                foreach (var user in users)
                {
                    _ = Task.Run(async () => await _mailService.SendConfirmationMail(user.Email, user.ConfirmCode, user.Username));
                }
            }

            return new TokenRefreshResponse<DtoUser>()
            {
                Body = _mapper.Map<DtoUser>(issuer),
                Token = refreshToken,
                Code = 200
            };


        }

        public async Task<TokenRefreshResponse<DtoUser>> BanWorkshopInactiveAccounts(int issuerId, string workshopCode)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Admin && issuer.Role != UserRole.Super)
            {
                return new TokenRefreshResponse<DtoUser>()
                {
                    Body = null,
                    Token = refreshToken,
                    Code = 403
                };
            }
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

            return new TokenRefreshResponse<DtoUser>()
            {
                Body = _mapper.Map<DtoUser>(issuer),
                Token = refreshToken,
                Code = 200
            };
        }

        public async Task<TokenRefreshResponse<DtoUser>> ExcludeInactiveUsersFromWorkshops(int issuerId)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role != UserRole.Super)
            {
                return new TokenRefreshResponse<DtoUser>()
                {
                    Body = null,
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

            return new TokenRefreshResponse<DtoUser>()
            {
                Body = _mapper.Map<DtoUser>(issuer),
                Token = refreshToken,
                Code = 200
            };
        }
    }
}
