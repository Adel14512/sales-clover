using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.AF1ColHeader;
using Evaluation.CAL.Request.AF1ColHeader;
using Evaluation.CAL.Response.AF1ColHeader;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AF1Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public AF1Controller(ILoggerManager logger)
        {
            _logger = logger;

            //test
        }

        [HttpPost]
        public IActionResult AF1ColHeaderFindWithColFilter([FromBody] AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq)
        {
            AF1ColHeaderResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                AF1ColHeader = new AF1ColHeaderDto()
                {
                }
            };

            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = aF1ColHeaderFindWithColFilterReq == null ? Guid.NewGuid().ToString() :
                        aF1ColHeaderFindWithColFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        aF1ColHeaderFindWithColFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        aF1ColHeaderFindWithColFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        aF1ColHeaderFindWithColFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(aF1ColHeaderFindWithColFilterReq.WebRequestCommon.CorrelationId, aF1ColHeaderFindWithColFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint AF1ColHeaderFindWithColFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(aF1ColHeaderFindWithColFilterReq));
                resp.AF1ColHeader = InstManagerAccessPoint.GetNewAccessPoint().AF1ColHeaderWithColFilter(aF1ColHeaderFindWithColFilterReq.AF1Code, aF1ColHeaderFindWithColFilterReq.AF1ColHeader);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.AF1ColHeader.Reserved1 != null ? resp.AF1ColHeader.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.AF1ColHeader.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = aF1ColHeaderFindWithColFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.AF1ColHeader.Reserved1 != null)
                        resp.AF1ColHeader = new AF1ColHeaderDto
                        {

                        };
                    //{
                    //    Code= regionNewRecReq.Region.Code,
                    //    Description= regionNewRecReq.Region.Description,
                    //    IsActive= regionNewRecReq.Region.IsActive                            
                    //};
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint AF1ColHeaderFindWithColFilter is completed");
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = aF1ColHeaderFindWithColFilterReq.WebRequestCommon.CorrelationId;
                resp.AF1ColHeader = new AF1ColHeaderDto()
                {

                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}
