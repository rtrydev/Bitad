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
        public Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendance(int issuerId, string attendanceCode);
        public Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendanceWorkshop(int issuerId,
            string attendanceCode, string workshopCode);
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
                s.StaffRole = null;
            }
            return _mapper.Map<ICollection<Staff>, ICollection<DtoStaff>>(staff);
        }

        public async Task<TokenRefreshResponse<ICollection<DtoStaff>>> GetAllAdmin(int issuerId)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role == UserRole.Guest) return TokenRefreshResponse<ICollection<DtoStaff>>.NullResponse(refreshToken, 403);
            
            var staff = await staffRepository.GetAll();
            return new TokenRefreshResponse<ICollection<DtoStaff>>
            {
                Body = _mapper.Map<ICollection<Staff>, ICollection<DtoStaff>>(staff),
                Token = refreshToken,
                Code = 200
            };
        }
        
        public async Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendance(int issuerId, string attendanceCode)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role == UserRole.Guest)
            {
                return TokenRefreshResponse<DtoAttendanceResult>.NullResponse(refreshToken, 403);
            }
                
            var user = await _userRepository.GetByPredicate(x => x.AttendanceCode == attendanceCode);
            if (user is null)
            {
                user = await _userRepository.GetByPredicate(x => x.Email == attendanceCode);
            }
            
            if (user is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>()
                {
                    Body = new DtoAttendanceResult() {Code = 404, Message = "User not found"},
                    Token = refreshToken
                };
            }

            if (user.ActivationDate is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 2, Message = "Not activated"},
                    Token = refreshToken,
                };
            }
            
            if (user.AttendanceCheckDate is not null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 1, Message = "Already checked"},
                    Token = refreshToken,
                };
            }
            
            user.AttendanceCheckDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return new TokenRefreshResponse<DtoAttendanceResult>
            {
                Body = new DtoAttendanceResult {Code = 0, Message = "Ok"},
                Token = refreshToken,
            }; 

        }
        
        public async Task<TokenRefreshResponse<DtoAttendanceResult>> CheckAttendanceWorkshop(int issuerId, string attendanceCode, string workshopCode)
        {
            var issuer = await _userRepository.GetById(issuerId);
            var refreshToken = await _jwtService.GetNewToken(issuerId);
            if (issuer.Role == UserRole.Guest)
            {
                return TokenRefreshResponse<DtoAttendanceResult>.NullResponse(refreshToken, 403);
            }
                
            var user = await _userRepository.GetByPredicate(x => x.WorkshopAttendanceCode == attendanceCode);
            if (user is null)
            {
                user = await _userRepository.GetByPredicate(x => x.Email == attendanceCode);
            }
            
            if (user is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>()
                {
                    Body = new DtoAttendanceResult() {Code = 404, Message = "User not found"},
                    Token = refreshToken
                };
            }

            if (user.Workshop.Code != workshopCode)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>()
                {
                    Body = new DtoAttendanceResult() {Code = 404, Message = "User not found"},
                    Token = refreshToken
                };
            }

            if (user.ActivationDate is null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 2, Message = "Not activated"},
                    Token = refreshToken,
                };
            }
            
            if (user.WorkshopAttendanceCheckDate is not null)
            {
                return new TokenRefreshResponse<DtoAttendanceResult>
                {
                    Body = new DtoAttendanceResult {Code = 1, Message = "Already checked"},
                    Token = refreshToken,
                };
            }
            
            user.WorkshopAttendanceCheckDate = DateTime.Now;
            var result = await _userRepository.UpdateUser(user);
            return new TokenRefreshResponse<DtoAttendanceResult>
            {
                Body = new DtoAttendanceResult {Code = 0, Message = "Ok"},
                Token = refreshToken,
            }; 

        }
    }
}
