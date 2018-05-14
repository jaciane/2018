using Domain.Enum;
using Domain.Util;
using System.Linq;
using System.Security.Claims;

namespace Application.ViewModels
{
    public static class LayoutViewModel
    {
        public static bool VerifyClaimExists(TypePermissionEnum _claimType, ValuePermissionEnum _claimValue, ClaimsIdentity ClaimsUser)
        {
            string claimType = EnumDescription.GetEnumDescription(_claimType);
            string claimValue = EnumDescription.GetEnumDescription(_claimValue);
            var claim = ClaimsUser.Claims.FirstOrDefault(c => c.Type == claimType && c.Value == claimValue);
            if (claim != null)
            {
                return true;
            }
            return false;
        }
    }
}
