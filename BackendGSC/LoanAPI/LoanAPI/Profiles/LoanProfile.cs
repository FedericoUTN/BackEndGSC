using AutoMapper;
using LoadApi.Entities;
using LoanAPI.Dto;

namespace LoanAPI.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<LoanDto, Loan>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.id}")
                )
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => $"{src.Status}")
                )
                .ForMember(
                dest => dest.ThingId,
                opt => opt.MapFrom(src => $"{src.ThingId}")
                )
                .ForMember(
                dest => dest.PersonId,
                opt => opt.MapFrom(src => $"{src.PersonId}")
                )
                .ForMember(
                dest => dest.CreateDate,
                opt => opt.MapFrom(src => DateTime.UtcNow)
                );
        }
    }
}
