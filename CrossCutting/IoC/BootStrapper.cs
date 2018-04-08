using Application;
using Application.Interfaces;
using Data;
using Data.Context;
using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Identity.Context;
using Service;
using SimpleInjector;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Identity.Configuration;
using Identity.Model;

namespace CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static Container Register(Container container)
        {
            //Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser, int>>(
            () => new CustomUserStore(container.GetInstance<ApplicationDbContext>()), Lifestyle.Scoped);
            container.Register(
                () => new UserManager<ApplicationUser, int>(
                    new CustomUserStore(
                        container.GetInstance<ApplicationDbContext>())), Lifestyle.Scoped);

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
