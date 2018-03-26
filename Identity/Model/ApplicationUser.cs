using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Model
{
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomPermissionRole, CustomClaim>
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public int IdProfile { get; set; }
        public string Active { get; set; }
        public CustomRole Profile { get; set; }
        public bool RecieveNotification { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
