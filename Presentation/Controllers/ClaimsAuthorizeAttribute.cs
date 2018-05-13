using Domain.Enum;
using Domain.Util;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.Controllers
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private TypePermissionEnum _claimType;
        private ValuePermissionEnum _claimValue;

        public ClaimsAuthorizeAttribute(TypePermissionEnum claimType, ValuePermissionEnum claimValue)
        {
            this._claimType = claimType;
            this._claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;
            string claimType = EnumDescription.GetEnumDescription(_claimType);
            string claimValue = EnumDescription.GetEnumDescription(_claimValue);
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimType && c.Value == claimValue);
            if (claim != null)
            {
                return true;
            }


            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            bool user = HttpContext.Current.User.Identity.IsAuthenticated;
            if (user)
            {
                if ((((string) filterContext.RouteData.Values["action"]).ToLower().Equals("create") && !((string)filterContext.RouteData.Values["controller"]).ToLower().Equals("variable")) ||
                    (((string)filterContext.RouteData.Values["action"]).ToLower().Equals("edit") && !((string)filterContext.RouteData.Values["controller"]).ToLower().Equals("variable") && !((string)filterContext.RouteData.Values["controller"]).ToLower().Equals("wps")) ||
                    ((string) filterContext.RouteData.Values["action"]).ToLower().Equals("delete") ||
                    ((string) filterContext.RouteData.Values["action"]).ToLower().Equals("update") ||
                    ((string) filterContext.RouteData.Values["action"]).ToLower().Equals("associate") ||
                    ((string) filterContext.RouteData.Values["action"]).ToLower().Equals("validate")
                )
                {
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary(new {action = "ModalAccessDenied", controller = "Error"}));
                }
                else
                {
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary(new {action = "AccessDenied", controller = "Error"}));
                }
            }
        }

        public static string GetUserProfile()
        {
            var claims = ((ClaimsIdentity)HttpContext.Current.User.Identity).Claims;
            return claims.FirstOrDefault(c => c.Type.Equals("PROFILE")).Value;
        }

        public static int GetUserIdCompany()
        {
            var claims = ((ClaimsIdentity)HttpContext.Current.User.Identity).Claims;
            return Int32.Parse(claims.FirstOrDefault(c => c.Type.Equals("COMPANY")).Value);
        }
    }
}