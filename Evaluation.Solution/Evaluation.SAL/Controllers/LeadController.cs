using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public LeadController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[Authorize]
        public IActionResult LeadNewRec(LeadNewRecReq leadNewRecReq)
        {
            LeadResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Lead = new LeadDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = leadNewRecReq == null ? Guid.NewGuid().ToString() :
                        leadNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        leadNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        leadNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        leadNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(leadNewRecReq.WebRequestCommon.CorrelationId, leadNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint LeadNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(leadNewRecReq));
                resp.Lead = InstManagerAccessPoint.GetNewAccessPoint().LeadNewRec(leadNewRecReq.Lead, leadNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Lead != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Lead.Reserved1 != null ? resp.Lead.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Lead.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = leadNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Lead.Reserved1 != null)
                        resp.Lead = new LeadDto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint LeadNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = leadNewRecReq.WebRequestCommon.CorrelationId;
                resp.Lead = new LeadDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        //[Authorize]
        public IActionResult LeadFindAll(LeadFindAllReq leadFindAllReq)
        {
            LeadFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Lead = new List<LeadDto>()
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
                    resp.WebResponseCommon.CorrelationId = leadFindAllReq == null ? Guid.NewGuid().ToString() :
                        leadFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        leadFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        leadFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        leadFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(leadFindAllReq.WebRequestCommon.CorrelationId, leadFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint LeadFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(leadFindAllReq));
                resp.Lead = InstManagerAccessPoint.GetNewAccessPoint().LeadFindAll();

                if (resp != null && resp.Lead != null && resp.Lead.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Lead[0].Reserved1 != null ? resp.Lead[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Lead[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = leadFindAllReq.WebRequestCommon.CorrelationId;
                    if (resp.Lead[0].Reserved1 != null)
                        resp.Lead = new List<LeadDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint LeadFindAll is completed");
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
                resp.WebResponseCommon.CorrelationId = leadFindAllReq.WebRequestCommon.CorrelationId;
                resp.Lead = new List<LeadDto>();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
