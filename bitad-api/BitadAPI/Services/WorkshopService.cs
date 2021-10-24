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
        private IWorkshopRepository workshopRepository;
        private IMapper _mapper;
        private IJwtService _jwtService;

        public WorkshopService(IWorkshopRepository repository, IMapper mapper, IJwtService jwtService)
        {
            workshopRepository = repository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<ICollection<DtoWorkshop>> GetAll()
        {
            var workshops = await workshopRepository.GetAll();
            return _mapper.Map<ICollection<Workshop>, ICollection<DtoWorkshop>>(workshops);
        }

        public async Task<TokenRefreshResponse<ICollection<DtoWorkshopParticipant>>> GetParticipantsForWorkshop(int issuerId, string code)
        {
            var workshop = await workshopRepository.GetByCode(code);
            var token = await _jwtService.GetNewToken(issuerId);

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
