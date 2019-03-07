using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UsersForListDto>()
                .ForMember(dest => dest.PhotosUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    // ResolveUsing
                    opt.MapFrom(d => d.DateIfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetaliedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateIfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}