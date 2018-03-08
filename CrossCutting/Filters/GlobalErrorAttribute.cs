using Application.Interfaces;
using Domain.Entities;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrossCutting.Filters
{
    public class GlobalErrorAttribute : ActionFilterAttribute
    {
        private readonly ILogErrorAppService _logErrorAppService;

        public GlobalErrorAttribute(ILogErrorAppService logErrorService)
        {
            _logErrorAppService = logErrorService;
        }
        //public GlobalErrorAttribute() { }

        /*Chamado após o Action Method e antes do Action Result ser executado (antes de renderizar a View).*/
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                LogError logError = new LogError();

                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                logError.Controller = controllerName;
                logError.Action = actionName;
                logError.Description = filterContext.Exception.Message;
                logError.StackTrace = filterContext.Exception.StackTrace;
                _logErrorAppService.Insert(logError);

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                 
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
