﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Repositories;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService serivce)
        {
            userService = serivce;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<DtoRegistrationResponse>> RegisterUser([FromBody] DtoRegistration registrationData)
        {
            var result = await userService.RegisterUser(registrationData);
            if (result is null) return Forbid();

            return Ok(result);
        }

        [HttpPost("AuthenticateUser")]
        public async Task<ActionResult<DtoUserLogon>> AuthenticateUser(string userEmail, string userCode)
        {
            var result = await userService.AuthenticateUser(userEmail, userCode);
            if (result is null) return Forbid();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUser")]
        public async Task<ActionResult<DtoUser>> GetUser()
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var user = await userService.GetUserById(id);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("GetLeaderboard")]
        public async Task<ActionResult<ICollection<DtoLeader>>> GetLeaderboard()
        {
            var result = await userService.GetLeaders();
            return Ok(result);
        }
    }
}
