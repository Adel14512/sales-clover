using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Wrapper;
using System.Net;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evaluation.UI.ErrorHandler
{
    
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        private readonly IUserApi _userApi;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerManager logger, IUserApi userApi)
        {
            _next = next;
            _logger = logger;
            _userApi = userApi;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
  
                _logger.LogDebug("INVOKE ACTION" + context);
                await _next(context);
              
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";


                //switch (error)
                //{
                //    case AppException e:
                //        // custom application error
                //        response.StatusCode = (int)HttpStatusCode.BadRequest;
                //        break;
                //    case KeyNotFoundException e:
                //        // not found error
                //        response.StatusCode = (int)HttpStatusCode.NotFound;
                //        break;
                //    default:
                //        // unhandled error
                //        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //        break;
                //}
                var user = await _userApi.GetUserClaims(context.User.Claims);
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                _logger.LogError("USERNAME: " + user.EmailAdress + " |  CORRELATIONID:" + Guid.NewGuid().ToString() + " | ERROR: " + error?.Message + "| DATETIME:" + DateTime.UtcNow, error);
                await response.WriteAsync(result);
            }
        }
    }
}
