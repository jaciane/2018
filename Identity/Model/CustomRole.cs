using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Identity.Model
{
    public class CustomRole : IdentityRole<int, CustomPermissionRole>
    {
        public List<ApplicationUser> UserList { get; set; }
        public List<CustomPermissionRole> AccessList { get; set; }
    }
}
