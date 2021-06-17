using System;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;

namespace BitadAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, DtoUser>();
            CreateMap<DtoUser, User>();
        }
    }
}
