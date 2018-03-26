using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Application.Interfaces;
using System.Collections;
using Identity.Context;
using System.Security.Claims;
using Application.ViewModels;
using System.Linq.Expressions;
using System.Linq;

namespace Identity.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {

        private IProfileAppService _profileAppService;
        private IUserAppService _userAppService;
        private IAccessAppService _accessAppService;
        private IParameterAppService _parameterAppService;

        //FIND PROFILE
        public override Task<IList<string>> GetRolesAsync(int userId)
        {
            var user = GetUser(userId);
            return Task.FromResult((IList<string>)new List<string>() { _profileAppService.GetById(user.IdProfile).Name });
        }

        private UserViewModel GetUser(int userId)
        {
            return _userAppService.GetById(userId);
        }

        public override Task<IList<Claim>> GetClaimsAsync(int userId)
        {
            var Claims = GetClaims(userId);
            return Task.FromResult((IList<Claim>)Claims);
        }

        private List<Claim> GetClaims(int userId)
        {
            var user = GetUser(userId);
            var PermissionList = _profileAppService.GetPermissions(user.IdProfile);
            List<PermissionViewModel> permission = new List<PermissionViewModel>()
            {
                new PermissionViewModel() {
                    ClaimType = "COMPANY",
                    ClaimValue = user.IdCompany.ToString()
                },
                new PermissionViewModel() {
                    ClaimType = "PROFILE",
                    ClaimValue = user.Profile.Name
                }
            };
            PermissionList.AddRange(permission);
            return BindClaims(PermissionList);
        }

        private List<Claim> BindClaims(List<PermissionViewModel> Access)
        {
            List<Claim> Claims = new List<Claim>();
            foreach (var item in Access)
            {
                Claims.Add(new Claim(item.ClaimType, item.ClaimValue));
            }
            return Claims;
        }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            Expression<Func<UserViewModel, bool>> filterUser;
            filterUser = (UserViewModel p) => (p.Cpf.Equals(user.Cpf) && p.IdCompany == user.IdCompany);
            var resultCpf = _userAppService.Get(filterUser);
            if (resultCpf.Count() > 0)
            {
                return Task.FromResult((IdentityResult)IdentityResult.Failed("CPF já cadastrado para a empresa selecionada."));
            }
            filterUser = (UserViewModel p) => (p.Email.ToLower().Equals(user.Email.ToLower()));
            var resultEmail = _userAppService.Get(filterUser);
            if (resultEmail.Count() > 0)
            {
                return Task.FromResult((IdentityResult)IdentityResult.Failed("E-mail já cadastrado."));
            }
            return base.CreateAsync(user, password);
        }
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store, IProfileAppService profileAppService, IUserAppService userAppService, IAccessAppService accessAppService, IParameterAppService parameterAppService)
            : base(store)
        {
            _profileAppService = profileAppService;
            _userAppService = userAppService;
            _accessAppService = accessAppService;
            _parameterAppService = parameterAppService;

            //Username validation config
            UserValidator = new UserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            PasswordValidator = new CustomPasswordValidator()
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            //Lockout Configuaration
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            // Providers to Two Factor Autentication
            RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Seu código de segurança é: {0}"
            });

            RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });

            //E-mail service class Config
            EmailService = new MailService(_parameterAppService);


            var provider = new DpapiDataProtectionProvider("Petrobras");
            var dataProtector = provider.Create("EmailConfirmation");

            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>(dataProtector);
        }
    }
}