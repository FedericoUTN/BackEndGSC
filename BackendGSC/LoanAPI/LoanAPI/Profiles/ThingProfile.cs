using AutoMapper;
using LoadApi.Entities;
using LoanAPI.Models;

namespace LoanAPI.Profiles
{
    public class ThingProfile : Profile
    {
        public ThingProfile()
        {
            CreateMap<ThingDTOViewModel, Thing>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => $"{src.Description}")
                )
                .ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => $"{src.CategoryId}")
                ).ReverseMap(); //TWO WAY MAPPING
        }
    }
}

