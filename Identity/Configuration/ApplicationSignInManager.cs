using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Application.Interfaces;

namespace Identity.Configuration
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, int>
    {
        private readonly ICompanyAppService _companyAppService;
        private readonly IProfileAppService _profileAppService;
        

        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager, ICompanyAppService companyAppService,IProfileAppService profileAppService)
            : base(userManager, authenticationManager)
        {
            _companyAppService = companyAppService;
            _profileAppService = profileAppService;
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
        
        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var user = UserManager.FindByEmailAsync(userName).Result;
            if (user != null)
            {
                var profile = _profileAppService.GetById(user.IdProfile);
                if(profile.Active.Equals(((int)Domain.Enum.GenericStatusEnum.Inactive).ToString()))
                {
                    return Task.FromResult((SignInStatus)SignInStatus.LockedOut);
                }

                if (user.Active.Equals(((int)Domain.Enum.GenericStatusEnum.Inactive).ToString()))
                {
                    return Task.FromResult((SignInStatus)SignInStatus.LockedOut);
                }
                if (user.IdCompany != null)
                {
                    var company = _companyAppService.GetById((int)user.IdCompany);
                    if (company.Active.Equals(((int)Domain.Enum.GenericStatusEnum.Inactive).ToString()))
                    {
                        return Task.FromResult((SignInStatus)SignInStatus.LockedOut);
                    }
                }
            }
            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }
    }
}
