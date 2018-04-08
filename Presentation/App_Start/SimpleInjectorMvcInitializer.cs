using CrossCutting.IoC;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Presentation.App_Start
{
    public static class SimpleInjectorMvcInitializer
    {
        public static Container Initialize()
        {
            var container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //BootStrapper.Register(container);

            //container.Register<IAuthenticationManager>(() =>
            //{
            //    if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying)
            //    {
            //        return new OwinContext().Authentication;
            //    }
            //    return HttpContext.Current.GetOwinContext().Authentication;

            //}, Lifestyle.Scoped);

            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            //container.Verify();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);


            return container;
        }
    }
}