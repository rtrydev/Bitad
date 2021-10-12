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
    }

    public class StaffService : IStaffService
    {
        private IStaffRepository staffRepository;
        private IMapper _mapper;
        private IUserRepository _userRepository;
        private IJwtService _jwtService;

        public StaffService(IStaffRepository repository, IMapper mapper, IUserRepository userRepository, IJwtService jwtService)
        {
            staffRepository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _jwtService = jwtService;
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
    }
}
