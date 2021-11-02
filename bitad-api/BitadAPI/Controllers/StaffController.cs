using System.Collections.Generic;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class StaffController : AuthorizedController
    {
        private IStaffService _staffService;
        private IJwtService _jwtService;

        public StaffController(IStaffService staffService, IJwtService jwtService)
        {
            _staffService = staffService;
            _jwtService = jwtService;
        }

        [HttpGet("GetStaff")]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaff()
        {
            return Ok(await _staffService.GetAll());
        }

        [HttpGet("GetStaffAdmin")]
        [Authorize]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaffAdmin()
        {
            var result = await MakeAuthorizedServiceCall(_staffService.GetAllAdmin, _jwtService);
            return result;
        }

        [HttpPut("CheckAttendance")]
        [Authorize]
        public async Task<ActionResult<DtoAttendanceResult>> CheckAttendance(string attendanceCode)
        {
            var result = await MakeAuthorizedServiceCall(attendanceCode, _staffService.CheckAttendance, _jwtService);
            return result;

        }
        
        [HttpPut("CheckWorkshopAttendance")]
        [Authorize]
        public async Task<ActionResult<DtoAttendanceResult>> CheckWorkshopAttendance(string attendanceCode, string workshopCode)
        {
            var result = await MakeAuthorizedServiceCall(attendanceCode, workshopCode,
                _staffService.CheckAttendanceWorkshop, _jwtService);
            return result;

        }
        
    }
}
