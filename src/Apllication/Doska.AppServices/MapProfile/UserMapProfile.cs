using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Domain;
using Doska.Contracts.AdDto;
using Doska.Contracts.UserDto;

namespace Doska.AppServices.MapProfile
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<User, InfoUserResponse>().ReverseMap();
            CreateMap<User, LoginRequest>().ReverseMap();
            CreateMap<User, RegisterRequest>().ReverseMap();
        }
    }
}
