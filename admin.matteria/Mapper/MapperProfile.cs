using admin.matteria.Models.User;
using AutoMapper;
using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace admin.matteria.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AuthUser, UserDto>().ReverseMap();
            CreateMap<AuthUser, UserCreateDto>().ReverseMap();
            CreateMap<AuthUser, UserUpdateDto>().ReverseMap();
        }

            
    }
}
