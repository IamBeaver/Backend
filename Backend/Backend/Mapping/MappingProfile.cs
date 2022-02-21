using AutoMapper;
using Backend.Models.Dtos;
using Backend.Models.Requests;
using DataAccess.Data.Entities;

namespace Backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<CreateUserRequest, BaseUserDto>();
            CreateMap<UpdateUserRequest, UserDto>();
        }
    }
}
