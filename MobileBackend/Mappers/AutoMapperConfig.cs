using AutoMapper;
using MobileBackend.DTO;
using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Configure() => 
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Recipe, RecipeDto>();
            }).CreateMapper();
    }
}
