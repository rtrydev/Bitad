using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;

namespace BitadAPI.Services
{
    public interface IWorkshopService
    {
        public Task<ICollection<DtoWorkshop>> GetAll();
        public Task<TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>> GetParticipantsForWorkshop(int issuerId, string code);
    }
    public class WorkshopService : IWorkshopService
    {
        private IWorkshopRepository _workshopRepository;
        private IMapper _mapper;
        private IJwtService _jwtService;
        private IUserRepository _userRepository;

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
            if (issuer.Role != UserRole.Admin && issuer.Role != UserRole.Super)
            {
                return new TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>()
                {
                    Token = token,
                    Code = 403,
                    Body = null
                };
            }

            if (workshop is null)
            {
                return new TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>()
                {
                    Token = token,
                    Code = 404
                };
            }
            
            var participants = _mapper.Map<ICollection<User>, ICollection<DtoWorkshopParticipant>>(workshop.Participants);
            return new TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>()
            {
                Token = token,
                Body = participants,
                Code = 200
            };

        }
    }
}
