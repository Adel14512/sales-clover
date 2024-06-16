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
using Evaluation.CAL.Request.ProductBenefits;
using Evaluation.CAL.Response.ProductBenefits;
using Evaluation.CAL.DTO.ProductBenefits;
using Evaluation.CAL.Request.ProductCombination;
using Evaluation.CAL.Response.ProductCombination;
using Evaluation.CAL.DTO.ProductCombination;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCombinationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public ProductCombinationController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductCombinationFindWithProductIdFilter(ProductCombinationFindWithProductIdFilterReq productCombinationFindWithProductIdFilterReq)
        {
            ProductCombinationListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductCombination = new List<ProductCombinationDto>()
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
                    resp.WebResponseCommon.CorrelationId = productCombinationFindWithProductIdFilterReq == null ? Guid.NewGuid().ToString() :
                        productCombinationFindWithProductIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productCombinationFindWithProductIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productCombinationFindWithProductIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productCombinationFindWithProductIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productCombinationFindWithProductIdFilterReq.WebRequestCommon.CorrelationId, productCombinationFindWithProductIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductCombinationFindWithProductIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productCombinationFindWithProductIdFilterReq));

                resp.ProductCombination = InstManagerAccessPoint.GetNewAccessPoint().ProductCombinationFindWithProductIdFilter(productCombinationFindWithProductIdFilterReq.ProductId);

                if (resp != null && resp.ProductCombination != null && resp.ProductCombination.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductCombination[0].Reserved1 != null ? resp.ProductCombination[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.ProductCombination[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productCombinationFindWithProductIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductCombination[0].Reserved1 != null)
                        resp.ProductCombination = new List<ProductCombinationDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductCombinationFindWithProductIdFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = productCombinationFindWithProductIdFilterReq.WebRequestCommon.CorrelationId;
                resp.ProductCombination = new List<ProductCombinationDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult ProductCombinationDeacRec(ProductCombinationDeaWithRecIdReq productCombinationDeaWithRecIdReq)
        {
            ProductCombinationResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductCombination = null
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
                    resp.WebResponseCommon.CorrelationId = productCombinationDeaWithRecIdReq == null ? Guid.NewGuid().ToString() :
                        productCombinationDeaWithRecIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productCombinationDeaWithRecIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productCombinationDeaWithRecIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productCombinationDeaWithRecIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productCombinationDeaWithRecIdReq.WebRequestCommon.CorrelationId, productCombinationDeaWithRecIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductCombinationDeacRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productCombinationDeaWithRecIdReq));

                resp.ProductCombination = InstManagerAccessPoint.GetNewAccessPoint().ProductCombinationDeacRec(productCombinationDeaWithRecIdReq.RecId);

                if (resp != null && resp.ProductCombination != null)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductCombination.Reserved1 == "is deleted successfully" ? "Record deleted" : resp.ProductCombination.Reserved1;
                    resp.WebResponseCommon.ReturnCode = resp.ProductCombination.Reserved1 == "is deleted successfully" ? StatusCodes.Status202Accepted.ToString() : StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = productCombinationDeaWithRecIdReq.WebRequestCommon.CorrelationId;
                    //if (resp.ProductCombination.Reserved1 == "is deleted successfully")
                    resp.ProductCombination = null;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ProductCombinationDeacRec is completed");
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
                resp.WebResponseCommon.CorrelationId = productCombinationDeaWithRecIdReq.WebRequestCommon.CorrelationId;
                resp.ProductCombination = null;
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult ProductCombinationNewRec([FromBody] ProductCombinationNewRecReq productCombinationNewRecReq)
        {
            ProductCombinationResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductCombination = new ProductCombinationDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = productCombinationNewRecReq == null ? Guid.NewGuid().ToString() :
                        productCombinationNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productCombinationNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productCombinationNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productCombinationNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productCombinationNewRecReq.WebRequestCommon.CorrelationId, productCombinationNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductCombinationNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productCombinationNewRecReq));
                resp.ProductCombination = InstManagerAccessPoint.GetNewAccessPoint().ProductCombinationNewRec(productCombinationNewRecReq.ProductCombination, productCombinationNewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductCombination.Reserved1 != null ? resp.ProductCombination.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.ProductCombination.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = productCombinationNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductCombination.Reserved1 != null)
                        resp.ProductCombination = new ProductCombinationDto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint ProductCombinationNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = productCombinationNewRecReq.WebRequestCommon.CorrelationId;
                resp.ProductCombination = new ProductCombinationDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult productCombinationUpdRecReq([FromBody] ProductCombinationUpdRecReq productCombinationUpdRecReq)
        {
            ProductCombinationResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductCombination = new ProductCombinationDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = productCombinationUpdRecReq == null ? Guid.NewGuid().ToString() :
                        productCombinationUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productCombinationUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productCombinationUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productCombinationUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productCombinationUpdRecReq.WebRequestCommon.CorrelationId, productCombinationUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint productCombinationUpdRecReq is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productCombinationUpdRecReq));
                resp.ProductCombination = InstManagerAccessPoint.GetNewAccessPoint().ProductCombinationUpdRec(productCombinationUpdRecReq.ProductCombination, productCombinationUpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductCombination.Reserved1 != null ? resp.ProductCombination.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.ProductCombination.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = productCombinationUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductCombination.Reserved1 != null)
                        resp.ProductCombination = new ProductCombinationDto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint productCombinationUpdRecReq is completed");

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
                resp.WebResponseCommon.CorrelationId = productCombinationUpdRecReq.WebRequestCommon.CorrelationId;
                resp.ProductCombination = new ProductCombinationDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
