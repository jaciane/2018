using Application.Interfaces;
using CrossCutting.Filters;
using CrossCutting.IoC;
using SimpleInjector;
using System.Web.Mvc;

namespace Presentation
{
    public class FilterConfig
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(container.GetInstance<GlobalErrorAttribute>());
            
        }
    }
}
