using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Request.BLDuplication;
using Evaluation.CAL.Request.Ticket;
using Evaluation.CAL.Response;
using Evaluation.CAL.Response.BLDuplication;
using Evaluation.CAL.Response.Ticket;
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
    public class TicketController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public IConfiguration _Configuration { get; }

        public TicketController(IConfiguration configuration, ILoggerManager logger)
        {
            _Configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult TicketDetailsUpdRec([FromBody] TicketDetailsUpdRecReq ticketDetailsUpdRecReq)
        {
            TicketDetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                TicketDetails = new CAL.DTO.Ticket.TicketDetailsDto { TicketId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = ticketDetailsUpdRecReq == null ? Guid.NewGuid().ToString() :
                        ticketDetailsUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        ticketDetailsUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        ticketDetailsUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        ticketDetailsUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(ticketDetailsUpdRecReq.WebRequestCommon.CorrelationId, ticketDetailsUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint TicketDetailsUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(ticketDetailsUpdRecReq));
                resp.TicketDetails = InstManagerAccessPoint.GetNewAccessPoint().TicketDetailsUpdRec(ticketDetailsUpdRecReq.TicketDetails, ticketDetailsUpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.TicketDetails.Reserved1 != null ? resp.TicketDetails.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.TicketDetails.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = ticketDetailsUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.TicketDetails.Reserved1 != null)
                        resp.TicketDetails = new CAL.DTO.Ticket.TicketDetailsDto { TicketId = -1 };
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
                _logger.LogInfo("Calling the Endpoint TicketDetailsUpdRec is completed");

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
                resp.WebResponseCommon.CorrelationId = ticketDetailsUpdRecReq.WebRequestCommon.CorrelationId;
                resp.TicketDetails = new CAL.DTO.Ticket.TicketDetailsDto { TicketId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
