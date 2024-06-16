using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Request.BLDuplication;
using Evaluation.CAL.Response;
using Evaluation.CAL.Response.BLDuplication;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessLineController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public IConfiguration _Configuration { get; }

        public BusinessLineController(IConfiguration configuration, ILoggerManager logger)
        {
            _Configuration = configuration;
            _logger = logger;
        }
        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult BusinessLineRelatedDocFindWithBusinessLineCodeFilter([FromBody] BusinessLineRelatedDocFindWithBusinessLineCodeFilterReq businessLineRelatedDocFindWithBusinessLineCodeFilterReq)
        {
            BusinessLineRelatedDocFindWithBusinessLineCodeFilterResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                BusinessLineRelatedDoc = new BusinessLineRelatedDocDto()
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
                    resp.WebResponseCommon.CorrelationId = businessLineRelatedDocFindWithBusinessLineCodeFilterReq == null ? Guid.NewGuid().ToString() :
                        businessLineRelatedDocFindWithBusinessLineCodeFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        businessLineRelatedDocFindWithBusinessLineCodeFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(businessLineRelatedDocFindWithBusinessLineCodeFilterReq.WebRequestCommon.CorrelationId, businessLineRelatedDocFindWithBusinessLineCodeFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint BusinessLineRelatedDocFindWithBusinessLineCodeFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(businessLineRelatedDocFindWithBusinessLineCodeFilterReq));
                resp.BusinessLineRelatedDoc = InstManagerAccessPoint.GetNewAccessPoint().BusinessLineRelatedDocFindWithBusinessLineCodeFilter(businessLineRelatedDocFindWithBusinessLineCodeFilterReq.BusinessLineCode, businessLineRelatedDocFindWithBusinessLineCodeFilterReq.ApplicationForm);

                if (resp != null)//&& resp.BusinessLine.Count > 0
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.BusinessLineRelatedDoc.Reserved1 != null ? resp.BusinessLineRelatedDoc.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.BusinessLineRelatedDoc.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = businessLineRelatedDocFindWithBusinessLineCodeFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.BusinessLineRelatedDoc.Reserved1 != null)
                        resp.BusinessLineRelatedDoc = new BusinessLineRelatedDocDto();
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint BusinessLineRelatedDocFindWithBusinessLineCodeFilter is completed");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = businessLineRelatedDocFindWithBusinessLineCodeFilterReq.WebRequestCommon.CorrelationId;
                resp.BusinessLineRelatedDoc = new BusinessLineRelatedDocDto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult BusinessLineDupRec([FromBody] BusinessLineDuplicationNewRecReq businessLineDuplicationNewRecReq)
        {
            BusinessLineDuplicationResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                BusinessLineDuplication = new CAL.DTO.BLDuplication.BusinessLineDuplicationDto() { TicketId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = businessLineDuplicationNewRecReq == null ? Guid.NewGuid().ToString() :
                        businessLineDuplicationNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        businessLineDuplicationNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        businessLineDuplicationNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        businessLineDuplicationNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(businessLineDuplicationNewRecReq.WebRequestCommon.CorrelationId, businessLineDuplicationNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(businessLineDuplicationNewRecReq));
                resp.BusinessLineDuplication = InstManagerAccessPoint.GetNewAccessPoint().BusinessLineDuplicationNewRec(businessLineDuplicationNewRecReq.BusinessLineDuplication, businessLineDuplicationNewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.BusinessLineDuplication.Reserved1 != null ? resp.BusinessLineDuplication.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.BusinessLineDuplication.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = businessLineDuplicationNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.BusinessLineDuplication.Reserved1 != null)
                        resp.BusinessLineDuplication = new CAL.DTO.BLDuplication.BusinessLineDuplicationDto() { TicketId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = businessLineDuplicationNewRecReq.WebRequestCommon.CorrelationId;
                resp.BusinessLineDuplication = new CAL.DTO.BLDuplication.BusinessLineDuplicationDto() { TicketId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
