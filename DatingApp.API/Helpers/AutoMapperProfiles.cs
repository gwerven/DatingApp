using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // AutoMapper is convention based
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
        }
    }
}