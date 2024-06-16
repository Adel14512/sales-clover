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
using Evaluation.CAL.Request.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.Response.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.DTO.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.Request.Dashboard;
using Evaluation.CAL.Response.Dashboard;
using Evaluation.CAL.DTO.Dashboard;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public DashboardController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductPriceControFindAll(ProductPriceControlReq productPriceControlReq)
        {
            ProductPriceControlResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },

                ProductPriceControl = new List<ProductPriceControlDto>()
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
                    resp.WebResponseCommon.CorrelationId = productPriceControlReq == null ? Guid.NewGuid().ToString() :
                        productPriceControlReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productPriceControlReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productPriceControlReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productPriceControlReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productPriceControlReq.WebRequestCommon.CorrelationId, productPriceControlReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductPriceControFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productPriceControlReq));

                resp.ProductPriceControl = InstManagerAccessPoint.GetNewAccessPoint().ProductPriceControlFindAll();

                if (resp != null && resp.ProductPriceControl != null && resp.ProductPriceControl.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductPriceControl[0].Reserved1 != null ? resp.ProductPriceControl[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.ProductPriceControl[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productPriceControlReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductPriceControl[0].Reserved1 != null)
                        resp.ProductPriceControl = new List<ProductPriceControlDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductPriceControFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = productPriceControlReq.WebRequestCommon.CorrelationId;
                resp.ProductPriceControl = new List<ProductPriceControlDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult TicketHistoryFindDataWithNbrDaysFilter(TicketHistoryReq ticketHistoryReq)
        {
            TicketHistoryResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },

                TicketHistory = new List<TicketHistoryDto>()
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
                    resp.WebResponseCommon.CorrelationId = ticketHistoryReq == null ? Guid.NewGuid().ToString() :
                        ticketHistoryReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        ticketHistoryReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        ticketHistoryReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        ticketHistoryReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(ticketHistoryReq.WebRequestCommon.CorrelationId, ticketHistoryReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint TicketHistoryFindDataWithNbrDaysFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(ticketHistoryReq));

                resp.TicketHistory = InstManagerAccessPoint.GetNewAccessPoint().TicketHistoryFindDataWithNbrDaysFilter(ticketHistoryReq.NbrDays, ticketHistoryReq.WebRequestCommon.UserName);

                if (resp != null && resp.TicketHistory != null && resp.TicketHistory.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.TicketHistory[0].Reserved1 != null ? resp.TicketHistory[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.TicketHistory[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = ticketHistoryReq.WebRequestCommon.CorrelationId;
                    if (resp.TicketHistory[0].Reserved1 != null)
                        resp.TicketHistory = new List<TicketHistoryDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint TicketHistoryFindDataWithNbrDaysFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = ticketHistoryReq.WebRequestCommon.CorrelationId;
                resp.TicketHistory = new List<TicketHistoryDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
