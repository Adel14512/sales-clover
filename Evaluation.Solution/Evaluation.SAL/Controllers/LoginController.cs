using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public LoginController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[Authorize]
        public IActionResult AuthenticateUser(UserCredReq userCredReq)
        {
            UserCredResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                    SuccessIndicator = "Success",
                    ReturnCode = StatusCodes.Status200OK.ToString(),
                    ReturnMessage = "Enquiry Succeeded",
                    CorrelationId = Guid.NewGuid().ToString()
                },
                User = new()
                {
                    EmailAdress = "EmailAdressTest",
                    FirstName = "FirstNameTest",
                    LastName = "LastNameTest",
                    LoginStatus = "LoginStatusTest",
                    RoleDescription = "RoleDescriptionTest",
                    RoleId = -1,
                    UserId = -1,
                    UserName = "UserNameTest"
                }
            };
            return Ok(resp);
            //try
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        resp.WebResponseCommon.SuccessIndicator = "Success";
            //        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
            //        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
            //        .SelectMany(v => v.Errors)
            //        .Select(e => e.ErrorMessage));
            //        resp.WebResponseCommon.CorrelationId = regionFindAllReq == null ? Guid.NewGuid().ToString() :
            //            regionFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
            //            regionFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
            //        return Ok(resp);
            //    }
            //    _logger.SetCorrelationId(regionFindAllReq.WebRequestCommon.CorrelationId, regionFindAllReq.WebRequestCommon.UserName);
            //    _logger.LogInfo("Calling the Endpoint RegionFindAll is started");
            //    _logger.LogDebug(JsonConvert.SerializeObject(regionFindAllReq));
            //    resp.Region = InstManagerAccessPoint.GetNewAccessPoint().RegionFindAll();

            //    if (resp != null && resp.Region.Count > 0)
            //    {
            //        resp.WebResponseCommon.SuccessIndicator = "Success";
            //        resp.WebResponseCommon.ReturnMessage = resp.Region[0].Reserved1 != null ? resp.Region[0].Reserved1 : "Enquiry Succeeded";
            //        resp.WebResponseCommon.ReturnCode = resp.Region[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
            //        resp.WebResponseCommon.CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId;
            //        if (resp.Region[0].Reserved1 != null)
            //            resp.Region = new List<CAL.DTO.RegionDto>();
            //    }
            //    //else
            //    //{
            //    //    //resp.
            //    //}
            //    _logger.LogDebug(JsonConvert.SerializeObject(resp));
            //    _logger.LogInfo("Calling the Endpoint RegionFindAll is completed");
            //    return Ok(resp);
            //    // UserCredDao t = new UserCredDao();
            //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError("Error", ex);
            //    resp.WebResponseCommon.SuccessIndicator = "Error";
            //    resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
            //    resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
            //    resp.WebResponseCommon.CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId;
            //    resp.Region = new List<CAL.DTO.RegionDto>();
            //    //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
            //    return Ok(resp);
            //}
        }
    }
}
