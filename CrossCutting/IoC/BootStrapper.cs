using Application;
using Application.Interfaces;
using Data;
using Data.Context;
using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Service;
using SimpleInjector;

namespace CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static Container Register(Container container)
        {
            // App
            //container.Register<IUnitAppService, UnitAppService>(Lifestyle.Scoped);
            //container.Register<ILogErrorAppService, LogErrorAppService>(Lifestyle.Scoped);

            //// Service
            //container.Register<IUnitService, UnitService>(Lifestyle.Scoped);
            //container.Register<IGenericService<LogError>, GenericService<LogError>>(Lifestyle.Scoped);

            //// Infra Dados
            //container.Register<IUnitRepository, UnitRepository>(Lifestyle.Scoped);
            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            //container.Register<IGenericRepository<LogError>, GenericRepository<LogError>>(Lifestyle.Scoped);


            container.Register<ModelContext>(Lifestyle.Scoped);

            return container;
        }
    }
}
