using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL010602;
using Evaluation.CAL.DTO.BL321110;
using Evaluation.CAL.Request.BL321110;
using Evaluation.CAL.Response.BL321110;
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
    public class BL321110Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL321110Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL321110NewRec([FromBody] SalesTransactionBL321110NewRecReq salesTransactionBL321110NewRecReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110NewRecReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110NewRec(salesTransactionBL321110NewRecReq.BusinessLineCode, salesTransactionBL321110NewRecReq.ContactId, salesTransactionBL321110NewRecReq.AF1BL321110, salesTransactionBL321110NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110FindAF1WithRecIdFilter([FromBody] SalesTransactionBL321110FindAF1WithRecIdReq salesTransactionBL321110FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindAF1WithRecIdFilter(salesTransactionBL321110FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto
                        {
                            RecId = -1,
                            AF1BL321110 = new List<AF1BL321110Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110UpdAF1Rec([FromBody] SalesTransactionBL321110UpdAF1RecReq salesTransactionBL321110UpdAF1RecReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110UpdAF1RecReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110UpdAF1Rec(salesTransactionBL321110UpdAF1RecReq.RecId, salesTransactionBL321110UpdAF1RecReq.AF1BL321110, salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                        {
                            RecId = -1,
                            AF1BL321110 = new List<AF1BL321110Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL321110FindCQWithRecIdFilter([FromBody] SalesTransactionBL321110FindCQWithRecIdFilterReq salesTransactionBL321110FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL321110CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQPivotSummaryBL321110 = new List<dynamic>
                {
                },
                CQPivotSectionBL321110 = new List<dynamic>
                {
                },
                CQPivotMemberBL321110 = new List<dynamic>
                {
                },
                CQHeaderBL321110 = new List<CQHeader321110>
                {
                },
                CQPivotBenefitBL321110 = new List<dynamic>
                {
                },
                CQPivotPricesListBL321110 = new List<dynamic>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQDetailsWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotSummaryBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQSummaryWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotSectionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQPivotWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotMemberBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQBenefitWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQBillsBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQBillsWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQHeaderWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBenefitBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQPivotBenefitWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotPricesListBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQPivotListPricesWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQCategoryWithRecIdFilter(salesTransactionBL321110FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQHeaderBL321110[0].Reserved1 != null ? resp.CQHeaderBL321110[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQHeaderBL321110[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQHeaderBL321110[0].Reserved1 != null)
                //        resp.CQHeaderBL321110 = new List<CQHeader321110>
                //        {
                //        };
                //    //{
                //    //    Code= regionNewRecReq.Region.Code,
                //    //    Description= regionNewRecReq.Region.Description,
                //    //    IsActive= regionNewRecReq.Region.IsActive                            
                //    //};
                //}
                //else
                //{
                //    //
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQHeaderBL321110 = new List<CQHeader321110>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110FindShortFullWithRecIdFilter([FromBody]
        SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL321110CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL321110 = new List<CQFullListBL321110Dto>()
                {
                },
                CQShortListBL321110 = new List<CQShortListBL321110Dto>()
                {
                },
                CQHeaderBL321110 = new List<CQHeader321110>
                {
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQFullListWithRecIdFilter(salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQShortListWithRecIdFilter(salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQHeaderWithRecIdFilter(salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL321110.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL321110[0].Reserved1 != null ? resp.CQFullListBL321110[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL321110[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL321110[0].Reserved1 != null)
                        resp.CQFullListBL321110 = new List<CQFullListBL321110Dto>
                        {
                        };
                    //{
                    //    Code= regionNewRecReq.Region.Code,
                    //    Description= regionNewRecReq.Region.Description,
                    //    IsActive= regionNewRecReq.Region.IsActive                            
                    //};
                }
                else
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL321110 = new List<CQFullListBL321110Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL321110FindSlipWithRecIdFilter([FromBody] SalesTransactionBL321110FindSlipWithRecIdReq salesTransactionBL321110FindSlipWithRecIdReq)
        {
            SalesTransactionBL321110SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                AF1BL321110 = new List<dynamic>(),
                Step2BL321110 = new List<dynamic>(),
                Step3BL321110 = new List<dynamic>(),
                Step4BL321110 = new List<dynamic>(),
                CQHeaderBL321110 = new List<CQHeader321110>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindSlipWithRecIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.CorrelationId, salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindSlipWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110FindSlipWithRecIdReq));
                resp.AF1BL321110 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL321110FindAF1WithRecId(salesTransactionBL321110FindSlipWithRecIdReq.SalesTransactionId);
                resp.Step2BL321110 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL321110FindStep2WithRecId(salesTransactionBL321110FindSlipWithRecIdReq.SalesTransactionId);
                resp.Step3BL321110 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL321110FindStep3WithRecId(salesTransactionBL321110FindSlipWithRecIdReq.SalesTransactionId);
                resp.Step4BL321110 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL321110FindStep4WithRecId(salesTransactionBL321110FindSlipWithRecIdReq.SalesTransactionId);
                resp.CQHeaderBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110FindCQHeaderWithRecIdFilter(salesTransactionBL321110FindSlipWithRecIdReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.CorrelationId;


                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.CorrelationId;
                //    if (resp.SalesTransactionBL321110.Reserved1 != null)
                //        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto
                //        {
                //            RecId = -1,
                //            AF1BL321110 = { new AF1BL321110Dto { } }
                //        };
                //    //{
                //    //    Code= regionNewRecReq.Region.Code,
                //    //    Description= regionNewRecReq.Region.Description,
                //    //    IsActive= regionNewRecReq.Region.IsActive                            
                //    //};
                //}
                //else
                //{
                //    //
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110FindSlipWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110FindSlipWithRecIdReq.WebRequestCommon.CorrelationId;
                resp.AF1BL321110 = new List<dynamic>();
                resp.Step2BL321110 = new List<dynamic>();
                resp.Step3BL321110 = new List<dynamic>();
                resp.Step4BL321110 = new List<dynamic>();
                resp.CQHeaderBL321110 = new List<CQHeader321110>();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL321110UpdSlip2Rec([FromBody] SalesTransactionBL321110UpdSlip2RecReq salesTransactionBL321110UpdSlip2RecReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip2RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip2Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110UpdSlip2RecReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110UpdSlip2Rec(salesTransactionBL321110UpdSlip2RecReq.RecId, salesTransactionBL321110UpdSlip2RecReq.Slip2BL321110, salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                        {
                            RecId = -1,
                            AF1BL321110 = new List<AF1BL321110Dto>(),
                            Slip2BL321110 = new List<Slip2BL321110Dto>(),
                            Slip3BL321110 = new List<Slip3BL321110Dto>(),
                            Slip4BL321110 = new List<Slip4BL321110Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip2Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip2RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110UpdSlip3Rec([FromBody] SalesTransactionBL321110UpdSlip3RecReq salesTransactionBL321110UpdSlip3RecReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip3RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip3Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110UpdSlip3RecReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110UpdSlip3Rec(salesTransactionBL321110UpdSlip3RecReq.RecId, salesTransactionBL321110UpdSlip3RecReq.Slip3BL321110, salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                        {
                            RecId = -1,
                            AF1BL321110 = new List<AF1BL321110Dto>(),
                            Slip2BL321110 = new List<Slip2BL321110Dto>(),
                            Slip3BL321110 = new List<Slip3BL321110Dto>(),
                            Slip4BL321110 = new List<Slip4BL321110Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip3Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip3RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110UpdSlip4Rec([FromBody] SalesTransactionBL321110UpdSlip4RecReq salesTransactionBL321110UpdSlip4RecReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip4RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip4Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110UpdSlip4RecReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110UpdSlip4Rec(salesTransactionBL321110UpdSlip4RecReq.RecId, salesTransactionBL321110UpdSlip4RecReq.Slip4BL321110, salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                        {
                            RecId = -1,
                            AF1BL321110 = new List<AF1BL321110Dto>(),
                            Slip2BL321110 = new List<Slip2BL321110Dto>(),
                            Slip3BL321110 = new List<Slip3BL321110Dto>(),
                            Slip4BL321110 = new List<Slip4BL321110Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip4Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip4RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL321110UpdSlip5Rec([FromBody] SalesTransactionBL321110UpdSlip5RecReq salesTransactionBL321110UpdSlip5RecReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>(),
                    Slip5BL321110 = new List<Slip5BL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip5RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip5Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110UpdSlip5RecReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110UpdSlip5Rec(salesTransactionBL321110UpdSlip5RecReq.RecId, salesTransactionBL321110UpdSlip5RecReq.Slip5BL321110, salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                        {
                            RecId = -1,
                            AF1BL321110 = new List<AF1BL321110Dto>(),
                            Slip2BL321110 = new List<Slip2BL321110Dto>(),
                            Slip3BL321110 = new List<Slip3BL321110Dto>(),
                            Slip4BL321110 = new List<Slip4BL321110Dto>(),
                            Slip5BL321110 = new List<Slip5BL321110Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdSlip5Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdSlip5RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>(),
                    Slip2BL321110 = new List<Slip2BL321110Dto>(),
                    Slip3BL321110 = new List<Slip3BL321110Dto>(),
                    Slip4BL321110 = new List<Slip4BL321110Dto>(),
                    Slip5BL321110 = new List<Slip5BL321110Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter([FromBody] SalesTransactionBL321110DetailsFindWithSalesTrxIdReq salesTransactionBL321110DetailsFindWithSalesTrxIdReq)
        {
            SalesTransactionBL321110DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                {
                },
                SalesTransactionBL321110DetailsPrices = new List<SalesTransactionBL321110DetailsPriceDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsFindWithSalesTrxIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId, salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110DetailsFindWithSalesTrxIdReq));
                resp.SalesTransactionBL321110Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter(salesTransactionBL321110DetailsFindWithSalesTrxIdReq.SalesTransactionId);

                foreach (var item in resp.SalesTransactionBL321110Details)
                {
                    var salesTrxDetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter(item.RecId);
                    if (salesTrxDetailsPrices != null && salesTrxDetailsPrices.Count > 0 && salesTrxDetailsPrices[0].Reserved1 == null)
                    {
                        resp.SalesTransactionBL321110DetailsPrices.AddRange(salesTrxDetailsPrices);
                    }
                }

                if (resp != null && resp.SalesTransactionBL321110Details != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? resp.SalesTransactionBL321110Details[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110Details[0].Reserved1 != null)
                        resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                        {
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110DetailsPricesNewRec([FromBody] SalesTransactionBL321110DetailsPricesNewRecReq salesTransactionBL321110DetailsPricesNewRecReq)
        {
            SalesTransactionBL321110DetailsPricesResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110DetailsPrices = new List<SalesTransactionBL321110DetailsPriceDto>()
                {
                },
                SalesTransactionBL321110Details = new SalesTransactionBL321110DetailsNewDto()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsPricesNewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsPricesNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110DetailsPricesNewRecReq));
                resp.SalesTransactionBL321110DetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsPricesNewRec(salesTransactionBL321110DetailsPricesNewRecReq.salesTransactionDetailsPrices, salesTransactionBL321110DetailsPricesNewRecReq.CommisinOnGPPer, salesTransactionBL321110DetailsPricesNewRecReq.AdminFeesAmount, salesTransactionBL321110DetailsPricesNewRecReq.CostOfPolicyPer, salesTransactionBL321110DetailsPricesNewRecReq.CostOfPolicyAmount, salesTransactionBL321110DetailsPricesNewRecReq.FixedTaxesAmount, salesTransactionBL321110DetailsPricesNewRecReq.FixedTaxesPer, 
                  salesTransactionBL321110DetailsPricesNewRecReq.VATPer,
                  salesTransactionBL321110DetailsPricesNewRecReq.AgeCalculationFullDate,
                  salesTransactionBL321110DetailsPricesNewRecReq.AgeCalculationYear,
                  salesTransactionBL321110DetailsPricesNewRecReq.AgeCalculationStartDate,
                  salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.UserName);

                resp.SalesTransactionBL321110Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsFindWithRecIdFilter(salesTransactionBL321110DetailsPricesNewRecReq.salesTransactionDetailsPrices[0].SalesTrxDetailsId);

                if (resp != null && resp.SalesTransactionBL321110DetailsPrices != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 != null ? resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 != null)
                        resp.SalesTransactionBL321110DetailsPrices = new List<SalesTransactionBL321110DetailsPriceDto>()
                        {
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsPricesNewRec is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsPricesNewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110DetailsPrices = new List<SalesTransactionBL321110DetailsPriceDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter([FromBody] SalesTransactionBL321110DetailsPricesFindWithSalesTrxDetailsIdReq salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq)
        {
            SalesTransactionBL321110DetailsPricesResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110DetailsPrices = new List<SalesTransactionBL321110DetailsPriceDto>()
                {
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId, salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq));
                resp.SalesTransactionBL321110DetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter(salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.SalesTransactionDetailsId);

                if (resp != null && resp.SalesTransactionBL321110DetailsPrices != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 != null ? resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110DetailsPrices[0].Reserved1 != null)
                        resp.SalesTransactionBL321110DetailsPrices = new List<SalesTransactionBL321110DetailsPriceDto>()
                        {
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110DetailsPrices = new List<SalesTransactionBL321110DetailsPriceDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL321110DetailsUpdSlip2Rec([FromBody] SalesTransactionBL321110DetailsUpdSlip2RecReq salesTransactionBL321110DetailsUpdSlip2RecReq)
        {
            SalesTransactionBL321110DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                {
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip2RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsUpdSlip2Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110DetailsUpdSlip2RecReq));
                resp.SalesTransactionBL321110Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsUpdSlip2Rec(salesTransactionBL321110DetailsUpdSlip2RecReq.RecId, salesTransactionBL321110DetailsUpdSlip2RecReq.Slip2BL321110, salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? resp.SalesTransactionBL321110Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110Details[0].Reserved1 != null)
                        resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                        {
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsUpdSlip2Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult SalesTransactionBL321110DetailsUpdSlip3Rec([FromBody] SalesTransactionBL321110DetailsUpdSlip3RecReq salesTransactionBL321110DetailsUpdSlip3RecReq)
        {
            SalesTransactionBL321110DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                {
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip3RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsUpdSlip3Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110DetailsUpdSlip3RecReq));
                resp.SalesTransactionBL321110Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsUpdSlip3Rec(salesTransactionBL321110DetailsUpdSlip3RecReq.RecId, salesTransactionBL321110DetailsUpdSlip3RecReq.Slip3BL321110, salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? resp.SalesTransactionBL321110Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110Details[0].Reserved1 != null)
                        resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                        {
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsUpdSlip3Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL321110DetailsUpdSlip4Rec([FromBody] SalesTransactionBL321110DetailsUpdSlip4RecReq salesTransactionBL321110DetailsUpdSlip4RecReq)
        {
            SalesTransactionBL321110DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                {
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip4RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId, salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsUpdSlip4Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110DetailsUpdSlip4RecReq));
                resp.SalesTransactionBL321110Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL321110DetailsUpdSlip4Rec(salesTransactionBL321110DetailsUpdSlip4RecReq.RecId, salesTransactionBL321110DetailsUpdSlip4RecReq.Slip4BL321110, salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? resp.SalesTransactionBL321110Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL321110Details[0].Reserved1 != null)
                        resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                        {
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110DetailsUpdSlip4Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110Details = new List<SalesTransactionBL321110DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL321110UpdGlobalRec([FromBody] SalesTransactionBL321110UpdGlobalRecReq
    salesTransactionBL321110UpdGlobalRecReq)
        {
            SalesTransactionBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdGlobalRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.CorrelationId,
                    salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdGlobalRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL321110UpdGlobalRecReq));
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL321110UpdGlobalRec(
                    salesTransactionBL321110UpdGlobalRecReq.RecId,
                    salesTransactionBL321110UpdGlobalRecReq.ClientId,
                    salesTransactionBL321110UpdGlobalRecReq.MasterId,
                    salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.UserName, salesTransactionBL321110UpdGlobalRecReq.PolicyId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL321110.Reserved1 != null ? resp.SalesTransactionBL321110.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL321110.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.
                        CorrelationId;
                    if (resp.SalesTransactionBL321110.Reserved1 != null)
                        resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto
                        {
                            RecId = -1,
                            AF1BL321110 = new List<AF1BL321110Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL321110UpdGlobalRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL321110UpdGlobalRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
