using System;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;

namespace BitadAPI.Profiles
{
    public class SponsorProfile : Profile
    {
        public SponsorProfile()
        {
            CreateMap<Sponsor, DtoSponsor>();
            CreateMap<DtoSponsor, Sponsor>();
        }
    }
}
