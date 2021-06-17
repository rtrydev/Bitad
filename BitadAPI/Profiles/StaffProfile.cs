using System;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;

namespace BitadAPI.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, DtoStaff>();
            CreateMap<DtoStaff, Staff>();
        }
    }
}
