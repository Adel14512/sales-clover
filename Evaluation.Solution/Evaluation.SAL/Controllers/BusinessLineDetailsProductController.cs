using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO;
using Evaluation.CAL.DTO.BusinessLineDetailsProduct;
using Evaluation.CAL.Request;
using Evaluation.CAL.Request.BLDuplication;
using Evaluation.CAL.Request.BusinessLineDetailsProduct;
using Evaluation.CAL.Response;
using Evaluation.CAL.Response.BLDuplication;
using Evaluation.CAL.Response.BusinessLineDetailsProduct;
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
    public class BusinessLineDetailsProductController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public IConfiguration _Configuration { get; }

        public BusinessLineDetailsProductController(IConfiguration configuration, ILoggerManager logger)
        {
            _Configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult BusinessLineDetailsProductFindWithProductIdFilter([FromBody] BusinessLineDetailsProductFindWithProductIdFilterRecReq businessLineDetailsProductFindWithProductIdFilterRecReq)
        {
            BusinessLineDetailsProductResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                BusinessLineDetailsProduct = new BusinessLineDetailsProductDto()
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
                    resp.WebResponseCommon.CorrelationId = businessLineDetailsProductFindWithProductIdFilterRecReq == null ? Guid.NewGuid().ToString() :
                        businessLineDetailsProductFindWithProductIdFilterRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        businessLineDetailsProductFindWithProductIdFilterRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(businessLineDetailsProductFindWithProductIdFilterRecReq.WebRequestCommon.CorrelationId, businessLineDetailsProductFindWithProductIdFilterRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint BusinessLineDetailsProductFindWithProductIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(businessLineDetailsProductFindWithProductIdFilterRecReq));
                resp.BusinessLineDetailsProduct = InstManagerAccessPoint.GetNewAccessPoint().BusinessLineDetailsProductFindWithProductIdFilter(businessLineDetailsProductFindWithProductIdFilterRecReq.ProductId);

                if (resp != null)//&& resp.BusinessLine.Count > 0
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.BusinessLineDetailsProduct.Reserved1 != null ? resp.BusinessLineDetailsProduct.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.BusinessLineDetailsProduct.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = businessLineDetailsProductFindWithProductIdFilterRecReq.WebRequestCommon.CorrelationId;
                    if (resp.BusinessLineDetailsProduct.Reserved1 != null)
                        resp.BusinessLineDetailsProduct = new BusinessLineDetailsProductDto();
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint BusinessLineDetailsProductFindWithProductIdFilter is completed");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = businessLineDetailsProductFindWithProductIdFilterRecReq.WebRequestCommon.CorrelationId;
                resp.BusinessLineDetailsProduct = new BusinessLineDetailsProductDto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
