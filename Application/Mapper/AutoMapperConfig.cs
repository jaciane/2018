using AutoMapper;
using Domain.Entities;
using Application.ViewModels;
using System.Linq;
using System;

namespace Application.Mapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Unit, UnitViewModel>().ReverseMap();


                }
            );
        }

    }
}
