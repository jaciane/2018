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

            container.Register<IProfileAppService, ProfileAppService>(Lifestyle.Scoped);
            container.Register<IUserAppService, UserAppService>(Lifestyle.Scoped);
            container.Register<IAccessAppService, AccessAppService>(Lifestyle.Scoped);
            container.Register<IParameterAppService, ParameterAppService>(Lifestyle.Scoped);
            container.Register<IPermissionAppService, PermissionAppService>(Lifestyle.Scoped);


            //// Service
            container.Register<IProfileService, ProfileService>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IAccessService, AccessService>(Lifestyle.Scoped);
            container.Register<IGenericService<Parameter>, GenericService<Parameter>>(Lifestyle.Scoped);
            container.Register<IPermissionService, PermissionService>(Lifestyle.Scoped);


            //// Infra Dados
            container.Register<IProfileRepository, ProfileRepository>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IAccessRepository, AccessRepository>(Lifestyle.Scoped);
            container.Register<IGenericRepository<Parameter>, GenericRepository<Parameter>>(Lifestyle.Scoped);
            container.Register<IPermissionRepository, PermissionRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);


            container.Register<ModelContext>(Lifestyle.Scoped);

            return container;
        }
    }
}
