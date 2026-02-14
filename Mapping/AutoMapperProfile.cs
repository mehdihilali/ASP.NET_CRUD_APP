using AutoMapper;
using UserManagement.DTO;
using UserManagement.Models;

namespace UserManagement.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
