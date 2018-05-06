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
                    #region  Parameter 
                    cfg.CreateMap<Parameter, ParameterViewModel>().ReverseMap();
                    #endregion
                    #region Profile
                    cfg.CreateMap<Domain.Entities.Profile, ProfileViewModel>().ReverseMap();
                    #endregion
                    #region User
                    cfg.CreateMap<UserViewModel, User>().ReverseMap();
                    cfg.CreateMap<UserViewModel, UserViewModel>().ReverseMap();
                    #endregion
         
                }
            );
        }

    }
}
