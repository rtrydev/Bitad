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
    public interface IWorkshopService
    {
        public Task<ICollection<DtoWorkshop>> GetAll();
        public Task<TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>> GetParticipantsForWorkshop(int issuerId, string code);
        public Task<TokenRefreshResponse<DtoWorkshop>> SelectWorkshop(int userId, string workshopCode);

    }
    public class WorkshopService : IWorkshopService
    {
        private IWorkshopRepository _workshopRepository;
        private IMapper _mapper;
        private IJwtService _jwtService;
        private IUserRepository _userRepository;
        private CodeGenerator _generator = new CodeGenerator();

        public WorkshopService(IWorkshopRepository workshopRepository, IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
        {
            _workshopRepository = workshopRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<ICollection<DtoWorkshop>> GetAll()
        {
            var workshops = await _workshopRepository.GetAll();
            return _mapper.Map<ICollection<Workshop>, ICollection<DtoWorkshop>>(workshops);
        }

        public async Task<TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>> GetParticipantsForWorkshop(int issuerId, string code)
        {
            var workshop = await _workshopRepository.GetByCode(code);
            var token = await _jwtService.GetNewToken(issuerId);

            var issuer = await _userRepository.GetById(issuerId);
            if (issuer.Role != UserRole.Admin && issuer.Role != UserRole.Super) return TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>.NullResponse(token, 403);

            if (workshop is null)
            {
                return TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>.NullResponse(token, 404);
            }
            
            var participants = _mapper.Map<ICollection<User>, ICollection<DtoWorkshopParticipant>>(workshop.Participants);
            return new TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>()
            {
                Token = token,
                Body = participants,
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

            user.WorkshopAttendanceCode = _generator.GenerateRandomCode();
            var userResult = await _userRepository.UpdateUser(user);

            var result = await _workshopRepository.AddParticipant(workshop.Id, userResult);
            
            return new TokenRefreshResponse<DtoWorkshop>
            {
                Body = _mapper.Map<DtoWorkshop>(result),
                Token = refreshToken,
                Code = 0
            };
        }
    }
}
