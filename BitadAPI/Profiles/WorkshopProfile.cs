using System;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;

namespace BitadAPI.Profiles
{
    public class WorkshopProfile : Profile
    {
        public WorkshopProfile()
        {
            CreateMap<Workshop, DtoWorkshop>();
            CreateMap<DtoWorkshop, Workshop>();
        }
    }
}
