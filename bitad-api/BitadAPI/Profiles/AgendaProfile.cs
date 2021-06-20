using System;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;

namespace BitadAPI.Profiles
{
    public class AgendaProfile : Profile
    {
        public AgendaProfile()
        {
            CreateMap<Agenda, DtoAgenda>();
            CreateMap<DtoAgenda, Agenda>();
        }
    }
}
