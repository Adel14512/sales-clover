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
    public class SalesTransactionController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public SalesTransactionController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult SalesTransactionMenuFindWithColFilter(SalesTransactionMenuFindWithColFilterReq salesTransactionMenuFindWithColFilterReq)
        {
            SalesTransactionMenuFindWithColFilterResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionMenu = new List<SalesTransactionMenuDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionMenuFindWithColFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionMenuFindWithColFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionMenuFindWithColFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionMenuFindWithColFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionMenuFindWithColFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionMenuFindWithColFilterReq.WebRequestCommon.CorrelationId, salesTransactionMenuFindWithColFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionMenuFindWithColFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionMenuFindWithColFilterReq));

                resp.SalesTransactionMenu = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionMenuFindWithColFilter(salesTransactionMenuFindWithColFilterReq.ClientType, salesTransactionMenuFindWithColFilterReq.ContactId);

                if (resp != null && resp.SalesTransactionMenu.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionMenu[0].Reserved1 != null ? resp.SalesTransactionMenu[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionMenu[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionMenuFindWithColFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionMenu[0].Reserved1 != null)
                        resp.SalesTransactionMenu = new List<SalesTransactionMenuDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint SalesTransactionMenuFindWithColFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionMenuFindWithColFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionMenu = new List<SalesTransactionMenuDto>();
                //CorrelationId = genderFindAllReq.WebRequestCommon.CorrelationId
                //Region = InstManagerAccessPoint.GetNewAccessPoint().RegionFindAll()
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult SalesTransactionMenuFindWithRecIdFilter(SalesTransactionMenuFindWithRecIdReq salesTransactionMenuFindWithRecIdReq)
        {
            SalesTransactionMenuFindWithRecIdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionMenu = new SalesTransactionMenuDto()
                {
                    AF1 = -1,
                    AF2Email = -1,
                    CQ = -1,
                    CQEmail = -1,
                    MaxRange = -1,
                    MinRange = -1,
                    ParentId = -1,
                    RecId = -1,
                    Slip = -1
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionMenuFindWithRecIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionMenuFindWithRecIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionMenuFindWithRecIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionMenuFindWithRecIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionMenuFindWithRecIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionMenuFindWithRecIdReq.WebRequestCommon.CorrelationId, salesTransactionMenuFindWithRecIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionMenuFindWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionMenuFindWithRecIdReq));

                resp.SalesTransactionMenu = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionMenuFindWithRecIdFilter(salesTransactionMenuFindWithRecIdReq.RecId);

                if (resp != null && resp.SalesTransactionMenu != null)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionMenu.Reserved1 != null ? resp.SalesTransactionMenu.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionMenu.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionMenuFindWithRecIdReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionMenu.Reserved1 != null)
                        resp.SalesTransactionMenu = new SalesTransactionMenuDto()
                        {
                            AF1 = -1,
                            AF2Email = -1,
                            CQ = -1,
                            CQEmail = -1,
                            MaxRange = -1,
                            MinRange = -1,
                            ParentId = -1,
                            RecId = -1,
                            Slip = -1
                        };
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint SalesTransactionMenuFindWithRecIdFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionMenuFindWithRecIdReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionMenu = new SalesTransactionMenuDto()
                {
                    AF1 = -1,
                    AF2Email = -1,
                    CQ = -1,
                    CQEmail = -1,
                    MaxRange = -1,
                    MinRange = -1,
                    ParentId = -1,
                    RecId = -1,
                    Slip = -1
                };
                //CorrelationId = genderFindAllReq.WebRequestCommon.CorrelationId
                //Region = InstManagerAccessPoint.GetNewAccessPoint().RegionFindAll()
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult SalesTransactionFindWithContactIdFilter(SalesTransactionFindWithContactIdFilterReq salesTransactionFindWithContactIdFilterReq)
        {
            SalesTransactionFindWithContactIdFilterResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransaction = new List<SalesTransactionDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionFindWithContactIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionFindWithContactIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionFindWithContactIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionFindWithContactIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionFindWithContactIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionFindWithContactIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionFindWithContactIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionFindWithContactIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionFindWithContactIdFilterReq));

                resp.SalesTransaction = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionFindWithContactIdFilter(salesTransactionFindWithContactIdFilterReq.ContactId, salesTransactionFindWithContactIdFilterReq.InternalStatus);

                if (resp != null && resp.SalesTransaction.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransaction[0].Reserved1 != null ? resp.SalesTransaction[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransaction[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionFindWithContactIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransaction[0].Reserved1 != null)
                        resp.SalesTransaction = new List<SalesTransactionDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint SalesTransactionFindWithContactIdFilter is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionFindWithContactIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransaction = new List<SalesTransactionDto>();
                //CorrelationId = genderFindAllReq.WebRequestCommon.CorrelationId
                //Region = InstManagerAccessPoint.GetNewAccessPoint().RegionFindAll()
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
