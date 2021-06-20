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
    }

    public class StaffService : IStaffService
    {
        private IStaffRepository staffRepository;
        private IMapper _mapper;

        public StaffService(IStaffRepository repository, IMapper mapper)
        {
            staffRepository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<DtoStaff>> GetAll()
        {
            var staff = await staffRepository.GetAll();
            return _mapper.Map<ICollection<Staff>, ICollection<DtoStaff>>(staff);
        }
    }
}
