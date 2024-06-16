//using WebApi.Entities;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Response;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly ILoggerManager _logger = new LoggerManager();

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        UnauthResp resp;
        resp = new()
        {
            WebResponseCommon = new()
            {
            }
        };
        //var user = (UserModel) context.HttpContext.Items["UserModel"];
        //var user = context.HttpContext.Items["Authorisation"];
        //if (user == null)
        //{
        //    resp.WebResponseCommon.SuccessIndicator = "Error";
        //    resp.WebResponseCommon.ReturnCode = StatusCodes.Status401Unauthorized.ToString();
        //    resp.WebResponseCommon.ReturnMessage = "Unauthorized";
        //    // not logged in
        //    //context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        //    context.Result = new JsonResult(resp);
        //}
        //GetCurrentUser();
        var action = context.RouteData.Values["action"];
        //var controller = context.RouteData.Values["controller"];
        ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;
        if (identity != null)
        {
            var userClaims = identity.Claims;
            //UserModel userModel = new()
            //{
            //    EamilAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
            //    Givename = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
            //    //Password = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
            //    //Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
            //    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
            //    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value
            //};
            AuthDto authDto = new()
            {
                ClientId = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                Scope = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                //Password = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                //Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                Client_Secret = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                Grant_Type = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value
            };
            if (!userClaims.Any())
            {
                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status401Unauthorized.ToString();
                resp.WebResponseCommon.ReturnMessage = "Unauthorized";
                resp.WebResponseCommon.CorrelationId = Guid.NewGuid().ToString();
                // not logged in
                //context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                _logger.SetCorrelationId(Guid.NewGuid().ToString(), "Unknown");
                _logger.LogDebug("No authorization allowed to call the Endpoint " + action);
                context.Result = new JsonResult(resp);
            }
        }
    }

    //private UserModel GetCurrentUser()
    //{
    //    //var identity = context;
    //}
}