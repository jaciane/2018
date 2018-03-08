using CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Reflection;
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
            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            //container.Verify();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
            return container;
        }
    }
}