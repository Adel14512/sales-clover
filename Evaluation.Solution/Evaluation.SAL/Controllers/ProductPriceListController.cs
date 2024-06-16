using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.Product;
using Evaluation.CAL.Response.Product;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.Product;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Response.ProductPriceList;
using Evaluation.CAL.DTO.ProductPriceList;
using Evaluation.CAL.Request.ProductPriceList;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductPriceListController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public ProductPriceListController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductPriceListFindWithProductIdFilter(ProductPriceListFindWithProductIdFilterReq productPriceListFindWithProductIdFilterReq)
        {
            ProductPriceListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductPriceList = new List<ProductPriceListDto>()
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
                    resp.WebResponseCommon.CorrelationId = productPriceListFindWithProductIdFilterReq == null ? Guid.NewGuid().ToString() :
                        productPriceListFindWithProductIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productPriceListFindWithProductIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productPriceListFindWithProductIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productPriceListFindWithProductIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productPriceListFindWithProductIdFilterReq.WebRequestCommon.CorrelationId, productPriceListFindWithProductIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductPriceListFindWithProductIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productPriceListFindWithProductIdFilterReq));

                resp.ProductPriceList = InstManagerAccessPoint.GetNewAccessPoint().ProductPriceListFindWithProductIdFilter(productPriceListFindWithProductIdFilterReq.ProductId);

                if (resp != null && resp.ProductPriceList != null && resp.ProductPriceList.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductPriceList[0].Reserved1 != null ? resp.ProductPriceList[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.ProductPriceList[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productPriceListFindWithProductIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductPriceList[0].Reserved1 != null)
                        resp.ProductPriceList = new List<ProductPriceListDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductPriceListFindWithProductIdFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = productPriceListFindWithProductIdFilterReq.WebRequestCommon.CorrelationId;
                resp.ProductPriceList = new List<ProductPriceListDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        //[Authorize]
        public IActionResult ProductPriceListNewRec(ProductPriceListNewRecReq productPriceListNewRecReq)
        {
            ProductPriceListResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductPriceList = new List<ProductPriceListDto>() { }
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
                    resp.WebResponseCommon.CorrelationId = productPriceListNewRecReq == null ? Guid.NewGuid().ToString() :
                        productPriceListNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productPriceListNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productPriceListNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productPriceListNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productPriceListNewRecReq.WebRequestCommon.CorrelationId, productPriceListNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductPriceListNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productPriceListNewRecReq));
                resp.ProductPriceList = InstManagerAccessPoint.GetNewAccessPoint().ProductPriceListNewRec(productPriceListNewRecReq.ProductPriceList, productPriceListNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductPriceList != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductPriceList[0].Reserved1 != null ? resp.ProductPriceList[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.ProductPriceList[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = productPriceListNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductPriceList[0].Reserved1 != null)
                        resp.ProductPriceList = new List<ProductPriceListDto>() { };
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
                _logger.LogInfo("Calling the Endpoint ProductPriceListNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = productPriceListNewRecReq.WebRequestCommon.CorrelationId;
                resp.ProductPriceList = new List<ProductPriceListDto> { };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult ProductPriceListNewRecV1(ProductPriceListNewRecReq productPriceListNewRecReq)
        {
            
            ProductPriceListResp resp = new()
            {
                WebResponseCommon = new WebResponseCommon(),
                ProductPriceList = new List<ProductPriceListDto>()
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
                    string correlationId = productPriceListNewRecReq?.WebRequestCommon?.CorrelationId?.Trim();
                    resp.WebResponseCommon.CorrelationId = !string.IsNullOrEmpty(correlationId) ? correlationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(productPriceListNewRecReq.WebRequestCommon.CorrelationId, productPriceListNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductPriceListNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productPriceListNewRecReq));

                resp.ProductPriceList = InstManagerAccessPoint.GetNewAccessPoint().ProductPriceListNewRec(productPriceListNewRecReq.ProductPriceList, productPriceListNewRecReq.WebRequestCommon.UserName);

                if (resp.ProductPriceList != null && resp.ProductPriceList.Any())
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductPriceList[0].Reserved1 ?? "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.ProductPriceList[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = productPriceListNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductPriceList[0].Reserved1 != null)
                        resp.ProductPriceList.Clear();
                }
                else
                {
                    // Handle no data case
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ProductPriceListNewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                string correlationId = productPriceListNewRecReq?.WebRequestCommon?.CorrelationId?.Trim();
                resp.WebResponseCommon.CorrelationId = !string.IsNullOrEmpty(correlationId) ? correlationId : Guid.NewGuid().ToString();
                resp.ProductPriceList.Clear();
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
