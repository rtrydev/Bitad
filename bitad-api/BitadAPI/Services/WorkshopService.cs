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
    }
    public class WorkshopService : IWorkshopService
    {
        private IWorkshopRepository workshopRepository;
        private IMapper _mapper;

        public WorkshopService(IWorkshopRepository repository, IMapper mapper, IJwtService jwtService)
        {
            workshopRepository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<DtoWorkshop>> GetAll()
        {
            var workshops = await workshopRepository.GetAll();
            return _mapper.Map<ICollection<Workshop>, ICollection<DtoWorkshop>>(workshops);
        }

    }
}
