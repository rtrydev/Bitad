using System;
using AutoMapper;
using BitadAPI.Dto;
using BitadAPI.Models;

namespace BitadAPI.Profiles
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<Speaker, DtoSpeaker>();
            CreateMap<DtoSpeaker, Speaker>();
        }
    }
}
