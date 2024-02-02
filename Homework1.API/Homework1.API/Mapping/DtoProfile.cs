using AutoMapper;
using Homework1.API.Models.DTOs;
using Homework1.API.Models.Users;
using System.Net.Http.Headers;

namespace Homework1.API.Mapping
{
    public class DtoProfile:Profile
    {
        //Mapper Library/AutoMapper : User Entity => UserDto 
        //there are another options too (manuel, linq method)
        public DtoProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
