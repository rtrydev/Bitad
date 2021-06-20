using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;
using BitadAPI.Repositories;

namespace BitadAPI.Services
{
    public interface ISponsorService
    {
        public Task<ICollection<DtoSponsor>> GetAll();
    }

    public class SponsorService : ISponsorService
    {
        private ISponsorRepository _sponsorRepository;
        private IMapper _mapper;

        public SponsorService(ISponsorRepository sponsorRepository, IMapper mapper)
        {
            _sponsorRepository = sponsorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<DtoSponsor>> GetAll()
        {
            var sponsors = await _sponsorRepository.GetAll();
            return _mapper.Map<ICollection<Sponsor>, ICollection<DtoSponsor>>(sponsors);
        }
    }
}
