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

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductBenefitsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public ProductBenefitsController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductBenefitsFindWithProductIdFilter(ProductBenefitsFindWithProductIdFilterReq productBenefitsFindWithProductIdFilterReq)
        {
            ProductBenefitsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductBenefitsList = new List<ProductBenefitsDto>()
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
                    resp.WebResponseCommon.CorrelationId = productBenefitsFindWithProductIdFilterReq == null ? Guid.NewGuid().ToString() :
                        productBenefitsFindWithProductIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productBenefitsFindWithProductIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productBenefitsFindWithProductIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productBenefitsFindWithProductIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productBenefitsFindWithProductIdFilterReq.WebRequestCommon.CorrelationId, productBenefitsFindWithProductIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductBenefitsFindWithProductIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productBenefitsFindWithProductIdFilterReq));

                resp.ProductBenefitsList = InstManagerAccessPoint.GetNewAccessPoint().ProductBenefitsFindWithProductIdFilter(productBenefitsFindWithProductIdFilterReq.ProductId);

                if (resp != null && resp.ProductBenefitsList != null && resp.ProductBenefitsList.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductBenefitsList[0].Reserved1 != null ? resp.ProductBenefitsList[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.ProductBenefitsList[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productBenefitsFindWithProductIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductBenefitsList[0].Reserved1 != null)
                        resp.ProductBenefitsList = new List<ProductBenefitsDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductBenefitsFindWithProductIdFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = productBenefitsFindWithProductIdFilterReq.WebRequestCommon.CorrelationId;
                resp.ProductBenefitsList = new List<ProductBenefitsDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductBenefitsTemplateFindAllFilter(ProductBenefitsTemplateFindAllFilterReq productBenefitsTemplateFindAllFilterReq)
        {
            ProductBenefitsTemplateResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductBenefitsTemplateList = new List<ProductBenefitsTemplateDto>()
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
                    resp.WebResponseCommon.CorrelationId = productBenefitsTemplateFindAllFilterReq == null ? Guid.NewGuid().ToString() :
                        productBenefitsTemplateFindAllFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productBenefitsTemplateFindAllFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productBenefitsTemplateFindAllFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productBenefitsTemplateFindAllFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productBenefitsTemplateFindAllFilterReq.WebRequestCommon.CorrelationId, productBenefitsTemplateFindAllFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductBenefitsTemplateFindAllFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productBenefitsTemplateFindAllFilterReq));

                resp.ProductBenefitsTemplateList = InstManagerAccessPoint.GetNewAccessPoint().ProductBenefitsTemplateFindAllFilter();

                if (resp != null && resp.ProductBenefitsTemplateList != null && resp.ProductBenefitsTemplateList.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductBenefitsTemplateList[0].Reserved1 != null ? resp.ProductBenefitsTemplateList[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.ProductBenefitsTemplateList[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productBenefitsTemplateFindAllFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductBenefitsTemplateList[0].Reserved1 != null)
                        resp.ProductBenefitsTemplateList = new List<ProductBenefitsTemplateDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductBenefitsTemplateFindAllFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = productBenefitsTemplateFindAllFilterReq.WebRequestCommon.CorrelationId;
                resp.ProductBenefitsTemplateList = new List<ProductBenefitsTemplateDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult ProductBenefitsNewRec(ProductBenefitsNewRecReq productBenefitsNewRecReq)
        {
            ProductBenefitsResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductBenefitsList = new List<ProductBenefitsDto>() { }
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
                    resp.WebResponseCommon.CorrelationId = productBenefitsNewRecReq == null ? Guid.NewGuid().ToString() :
                        productBenefitsNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productBenefitsNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productBenefitsNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productBenefitsNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productBenefitsNewRecReq.WebRequestCommon.CorrelationId, productBenefitsNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductBenefitsNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productBenefitsNewRecReq));
                resp.ProductBenefitsList = InstManagerAccessPoint.GetNewAccessPoint().ProductBenefitsNewRec(productBenefitsNewRecReq.ProductBenefitsList, productBenefitsNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductBenefitsList != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductBenefitsList[0].Reserved1 != null ? resp.ProductBenefitsList[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.ProductBenefitsList[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = productBenefitsNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductBenefitsList[0].Reserved1 != null)
                        resp.ProductBenefitsList = new List<ProductBenefitsDto>() { };
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
                _logger.LogInfo("Calling the Endpoint ProductBenefitsNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = productBenefitsNewRecReq.WebRequestCommon.CorrelationId;
                resp.ProductBenefitsList = new List<ProductBenefitsDto> { };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
