using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.SpecialCondition;
using Evaluation.CAL.Request.SpecialCondition;
using Evaluation.CAL.Response.SpecialCondition;
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
    public class SpecialConditionController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public SpecialConditionController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        //[Authorize]
        public IActionResult SpecialConditionNewRec(SpecialConditionNewRecReq specialConditionNewRecReq)
        {
            SpecialConditionResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SpecialCondition = new SpecialConditionDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = specialConditionNewRecReq == null ? Guid.NewGuid().ToString() :
                        specialConditionNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        specialConditionNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        specialConditionNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        specialConditionNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(specialConditionNewRecReq.WebRequestCommon.CorrelationId, specialConditionNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SpecialConditionNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(specialConditionNewRecReq));
                resp.SpecialCondition = InstManagerAccessPoint.GetNewAccessPoint().SpecialConditionNewRec(specialConditionNewRecReq.SalesTrxId, specialConditionNewRecReq.BusinessLineCode,
                    specialConditionNewRecReq.ProductId, specialConditionNewRecReq.Sheet,
                    specialConditionNewRecReq.DiscountPer, specialConditionNewRecReq.DiscountAmount,
                    specialConditionNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.SpecialCondition != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SpecialCondition.Reserved1 != null ? resp.SpecialCondition.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SpecialCondition.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = specialConditionNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SpecialCondition.Reserved1 != null)
                        resp.SpecialCondition = new SpecialConditionDto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SpecialConditionNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = specialConditionNewRecReq.WebRequestCommon.CorrelationId;
                resp.SpecialCondition = new SpecialConditionDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SpecialConditionFindWithColFilter([FromBody] SpecialConditionFindWithColFilterReq specialConditionFindWithColFilterReq)
        {
            SpecialConditionResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SpecialCondition = new SpecialConditionDto()
                {
                    RecId = -1
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
                    resp.WebResponseCommon.CorrelationId = specialConditionFindWithColFilterReq == null ? Guid.NewGuid().ToString() :
                        specialConditionFindWithColFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        specialConditionFindWithColFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        specialConditionFindWithColFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        specialConditionFindWithColFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(specialConditionFindWithColFilterReq.WebRequestCommon.CorrelationId, specialConditionFindWithColFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SpecialConditionFindWithColFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(specialConditionFindWithColFilterReq));
                resp.SpecialCondition = InstManagerAccessPoint.GetNewAccessPoint().SpecialConditionFindWithColFilter(specialConditionFindWithColFilterReq.SalesTrxId,
                    specialConditionFindWithColFilterReq.BusinessLineCode,
                    specialConditionFindWithColFilterReq.ProductId,
                    specialConditionFindWithColFilterReq.Sheet);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SpecialCondition.Reserved1 != null ? resp.SpecialCondition.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SpecialCondition.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = specialConditionFindWithColFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SpecialCondition.Reserved1 != null)
                        resp.SpecialCondition = new SpecialConditionDto
                        {
                            RecId = -1
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
                _logger.LogInfo("Calling the Endpoint SpecialConditionFindWithColFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = specialConditionFindWithColFilterReq.WebRequestCommon.CorrelationId;
                resp.SpecialCondition = new SpecialConditionDto
                {
                    RecId = -1
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}
