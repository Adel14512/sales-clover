using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Evaluation.UIL.Controllers
{
    public class RequestAuthenticationFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestAuthenticationFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            if (actionName == "Logout" ||
                (actionName == "Logout2") ||
                (actionName == "Index" && controllerName == "Login") ||
                (actionName == "Authenticate" && controllerName == "Login") ||
                (actionName == "Index" && controllerName == "Register") ||
                (actionName == "IsAlreadySigned" && controllerName == "Register") ||
                (actionName == "RegisterUser" && controllerName == "Register") ||
                (actionName == "Index" && controllerName == "Home") ||
                (actionName == "IsCurrentPwdCorrect" && controllerName == "Register"))
                return;

            //if (Global.IsCookieValidated == "loggedin")
            //{
            var session = _httpContextAccessor.HttpContext.Session.Get("UserName");
            if (session == null && actionName != "SessionTimeOut")
            {
                //Global.IsCookieValidated = "loggedout";
                //return  RedirectToAction("Index", "Login");
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "SessionTimeOut", controller = "Home" }));
                return;
                //return  RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Login" }));
            }
            //}
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
