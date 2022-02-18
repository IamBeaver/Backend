using AutoMapper;
using Backend.Models.Dtos;
using DataAccess.Data.Entities;

namespace Backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
