using Application.Interfaces;
using Domain.Entities;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrossCutting.Filters
{
    public class GlobalErrorAttribute : ActionFilterAttribute, IExceptionFilter
    {

        public GlobalErrorAttribute()
        {

        }

        public virtual void OnException(ExceptionContext filterContext)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        /*Chamado após o Action Method e antes do Action Result ser executado (antes de renderizar a View).*/
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
