using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL041312;
using Evaluation.CAL.Request.BL041312;
using Evaluation.CAL.Response.BL041312;
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
    public class BL041312Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL041312Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312NewRec([FromBody] SalesTransactionBL041312NewRecReq salesTransactionBL041312NewRecReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312NewRecReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312NewRec(salesTransactionBL041312NewRecReq.BusinessLineCode, salesTransactionBL041312NewRecReq.ContactId, salesTransactionBL041312NewRecReq.AF1BL041312, salesTransactionBL041312NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL041312FindAF1WithRecIdFilter([FromBody] SalesTransactionBL041312FindAF1WithRecIdReq salesTransactionBL041312FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindAF1WithRecIdFilter(salesTransactionBL041312FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto
                        {
                            RecId = -1,
                            AF1BL041312 = new List<AF1BL041312Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL041312UpdAF1Rec([FromBody] SalesTransactionBL041312UpdAF1RecReq salesTransactionBL041312UpdAF1RecReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312UpdAF1RecReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312UpdAF1Rec(salesTransactionBL041312UpdAF1RecReq.RecId, salesTransactionBL041312UpdAF1RecReq.AF1BL041312, salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                        {
                            RecId = -1,
                            AF1BL041312 = new List<AF1BL041312Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312FindCQWithRecIdFilter([FromBody] SalesTransactionBL041312FindCQWithRecIdFilterReq salesTransactionBL041312FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL041312CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQPivotSummaryBL041312 = new List<dynamic>
                {
                },
                CQPivotSectionBL041312 = new List<dynamic>
                {
                },
                CQPivotMemberBL041312 = new List<dynamic>
                {
                },
                CQHeaderBL041312 = new List<CQHeader041312Dto>
                {
                },
                CQPivotBenefitBL041312 = new List<dynamic>
                {
                },
                CQPivotPricesListBL041312 = new List<dynamic>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQDetailsWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotSummaryBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQSummaryWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotSectionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQPivotWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotMemberBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQBenefitWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQBillsBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQBillsWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQHeaderWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBenefitBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQPivotBenefitWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotPricesListBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQPivotListPricesWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQCategoryWithRecIdFilter(salesTransactionBL041312FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQHeaderBL041312[0].Reserved1 != null ? resp.CQHeaderBL041312[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQHeaderBL041312[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQHeaderBL041312[0].Reserved1 != null)
                //        resp.CQHeaderBL041312 = new List<CQHeader041312>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQHeaderBL041312 = new List<CQHeader041312Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL041312FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL041312FindCQShortFullListWithRecIdFilterReq salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL041312CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL041312 = new List<CQFullListBL041312Dto>()
                {
                },
                CQShortListBL041312 = new List<CQShortListBL041312Dto>()
                {
                },
                CQHeaderBL041312 = new List<CQHeader041312Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQFullListWithRecIdFilter(salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQShortListWithRecIdFilter(salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQHeaderWithRecIdFilter(salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL041312.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL041312[0].Reserved1 != null ? resp.CQFullListBL041312[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL041312[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL041312[0].Reserved1 != null)
                        resp.CQFullListBL041312 = new List<CQFullListBL041312Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL041312 = new List<CQFullListBL041312Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312FindSlipWithRecIdFilter([FromBody] SalesTransactionBL041312FindAF1WithRecIdReq salesTransactionBL041312FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL041312SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                AF1BL041312 = new List<dynamic>(),
                Step2BL041312 = new List<dynamic>(),
                Step3BL041312 = new List<dynamic>(),
                Step4BL041312 = new List<dynamic>(),
                CQHeaderBL041312 = new List<CQHeader041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312FindAF1WithRecIdFilterReq));
                resp.AF1BL041312 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL041312FindAF1WithRecId(salesTransactionBL041312FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.Step2BL041312 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL041312FindStep2WithRecId(salesTransactionBL041312FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.Step3BL041312 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL041312FindStep3WithRecId(salesTransactionBL041312FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.Step4BL041312 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL041312FindStep4WithRecId(salesTransactionBL041312FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312FindCQHeaderWithRecIdFilter(salesTransactionBL041312FindAF1WithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;


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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.AF1BL041312 = new List<dynamic>();
                resp.Step2BL041312 = new List<dynamic>();
                resp.Step3BL041312 = new List<dynamic>();
                resp.Step4BL041312 = new List<dynamic>();
                resp.CQHeaderBL041312 = new List<CQHeader041312Dto>();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL041312UpdSlip2Rec([FromBody] SalesTransactionBL041312UpdSlip2RecReq salesTransactionBL041312UpdSlip2RecReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip2RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip2Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312UpdSlip2RecReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312UpdSlip2Rec(salesTransactionBL041312UpdSlip2RecReq.RecId, salesTransactionBL041312UpdSlip2RecReq.Slip2BL041312, salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                        {
                            RecId = -1,
                            AF1BL041312 = new List<AF1BL041312Dto>(),
                            Slip2BL041312 = new List<Slip2BL041312Dto>(),
                            Slip3BL041312 = new List<Slip3BL041312Dto>(),
                            Slip4BL041312 = new List<Slip4BL041312Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip2Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip2RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL041312UpdSlip3Rec([FromBody] SalesTransactionBL041312UpdSlip3RecReq salesTransactionBL041312UpdSlip3RecReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip3RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip3Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312UpdSlip3RecReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312UpdSlip3Rec(salesTransactionBL041312UpdSlip3RecReq.RecId, salesTransactionBL041312UpdSlip3RecReq.Slip3BL041312, salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                        {
                            RecId = -1,
                            AF1BL041312 = new List<AF1BL041312Dto>(),
                            Slip2BL041312 = new List<Slip2BL041312Dto>(),
                            Slip3BL041312 = new List<Slip3BL041312Dto>(),
                            Slip4BL041312 = new List<Slip4BL041312Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip3Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip3RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312UpdSlip4Rec([FromBody] SalesTransactionBL041312UpdSlip4RecReq salesTransactionBL041312UpdSlip4RecReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip4RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip4Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312UpdSlip4RecReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312UpdSlip4Rec(salesTransactionBL041312UpdSlip4RecReq.RecId, salesTransactionBL041312UpdSlip4RecReq.Slip4BL041312, salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                        {
                            RecId = -1,
                            AF1BL041312 = new List<AF1BL041312Dto>(),
                            Slip2BL041312 = new List<Slip2BL041312Dto>(),
                            Slip3BL041312 = new List<Slip3BL041312Dto>(),
                            Slip4BL041312 = new List<Slip4BL041312Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip4Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip4RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312UpdSlip5Rec([FromBody] SalesTransactionBL041312UpdSlip5RecReq salesTransactionBL041312UpdSlip5RecReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>(),
                    Slip5BL041312 = new List<Slip5BL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip5RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip5Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312UpdSlip5RecReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312UpdSlip5Rec(salesTransactionBL041312UpdSlip5RecReq.RecId, salesTransactionBL041312UpdSlip5RecReq.Slip5BL041312, salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                        {
                            RecId = -1,
                            AF1BL041312 = new List<AF1BL041312Dto>(),
                            Slip2BL041312 = new List<Slip2BL041312Dto>(),
                            Slip3BL041312 = new List<Slip3BL041312Dto>(),
                            Slip4BL041312 = new List<Slip4BL041312Dto>(),
                            Slip5BL041312 = new List<Slip5BL041312Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdSlip5Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdSlip5RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>(),
                    Slip2BL041312 = new List<Slip2BL041312Dto>(),
                    Slip3BL041312 = new List<Slip3BL041312Dto>(),
                    Slip4BL041312 = new List<Slip4BL041312Dto>(),
                    Slip5BL041312 = new List<Slip5BL041312Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter([FromBody] SalesTransactionBL041312DetailsFindWithSalesTrxIdReq salesTransactionBL041312DetailsFindWithSalesTrxIdReq)
        {
            SalesTransactionBL041312DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
                {
                },
                SalesTransactionBL041312DetailsPrices = new List<SalesTransactionBL041312DetailsPriceDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsFindWithSalesTrxIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId, salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312DetailsFindWithSalesTrxIdReq));
                resp.SalesTransactionBL041312Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter(salesTransactionBL041312DetailsFindWithSalesTrxIdReq.SalesTransactionId);

                foreach (var item in resp.SalesTransactionBL041312Details)
                {
                    var salesTrxDetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter(item.RecId);
                    if (salesTrxDetailsPrices != null && salesTrxDetailsPrices.Count > 0 && salesTrxDetailsPrices[0].Reserved1 == null)
                    {
                        resp.SalesTransactionBL041312DetailsPrices.AddRange(salesTrxDetailsPrices);
                    }
                }

                if (resp != null && resp.SalesTransactionBL041312Details != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? resp.SalesTransactionBL041312Details[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312Details[0].Reserved1 != null)
                        resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312DetailsPricesNewRec([FromBody] SalesTransactionBL041312DetailsPricesNewRecReq salesTransactionBL041312DetailsPricesNewRecReq)
        {
            SalesTransactionBL041312DetailsPricesResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312DetailsPrices = new List<SalesTransactionBL041312DetailsPriceDto>()
                {
                },
                SalesTransactionBL041312Details = new SalesTransactionBL041312DetailsNewDto()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsPricesNewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsPricesNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312DetailsPricesNewRecReq));
                resp.SalesTransactionBL041312DetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsPricesNewRec(salesTransactionBL041312DetailsPricesNewRecReq.salesTransactionBL041312DetailsPrices, salesTransactionBL041312DetailsPricesNewRecReq.CommisinOnGPPer, salesTransactionBL041312DetailsPricesNewRecReq.AdminFeesAmount, salesTransactionBL041312DetailsPricesNewRecReq.CostOfPolicyPer, salesTransactionBL041312DetailsPricesNewRecReq.CostOfPolicyAmount, salesTransactionBL041312DetailsPricesNewRecReq.FixedTaxesAmount, salesTransactionBL041312DetailsPricesNewRecReq.FixedTaxesPer, salesTransactionBL041312DetailsPricesNewRecReq.VATPer, salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.UserName);

                resp.SalesTransactionBL041312Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsFindWithRecIdFilter(salesTransactionBL041312DetailsPricesNewRecReq.salesTransactionBL041312DetailsPrices[0].SalesTrxDetailsId);

                if (resp != null && resp.SalesTransactionBL041312DetailsPrices != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 != null ? resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 != null)
                        resp.SalesTransactionBL041312DetailsPrices = new List<SalesTransactionBL041312DetailsPriceDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsPricesNewRec is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsPricesNewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312DetailsPrices = new List<SalesTransactionBL041312DetailsPriceDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter([FromBody] SalesTransactionBL041312DetailsPricesFindWithSalesTrxDetailsIdReq salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq)
        {
            SalesTransactionBL041312DetailsPricesResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312DetailsPrices = new List<SalesTransactionBL041312DetailsPriceDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId, salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq));
                resp.SalesTransactionBL041312DetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter(salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.SalesTransactionDetailsId);

                if (resp != null && resp.SalesTransactionBL041312DetailsPrices != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 != null ? resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312DetailsPrices[0].Reserved1 != null)
                        resp.SalesTransactionBL041312DetailsPrices = new List<SalesTransactionBL041312DetailsPriceDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312DetailsPrices = new List<SalesTransactionBL041312DetailsPriceDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312DetailsUpdSlip2Rec([FromBody] SalesTransactionBL041312DetailsUpdSlip2RecReq salesTransactionBL041312DetailsUpdSlip2RecReq)
        {
            SalesTransactionBL041312DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip2RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsUpdSlip2Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312DetailsUpdSlip2RecReq));
                resp.SalesTransactionBL041312Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsUpdSlip2Rec(salesTransactionBL041312DetailsUpdSlip2RecReq.RecId, salesTransactionBL041312DetailsUpdSlip2RecReq.Slip2BL041312, salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? resp.SalesTransactionBL041312Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312Details[0].Reserved1 != null)
                        resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsUpdSlip2Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312DetailsUpdSlip3Rec([FromBody] SalesTransactionBL041312DetailsUpdSlip3RecReq salesTransactionBL041312DetailsUpdSlip3RecReq)
        {
            SalesTransactionBL041312DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip3RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsUpdSlip3Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312DetailsUpdSlip3RecReq));
                resp.SalesTransactionBL041312Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsUpdSlip3Rec(salesTransactionBL041312DetailsUpdSlip3RecReq.RecId, salesTransactionBL041312DetailsUpdSlip3RecReq.Slip3BL041312, salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? resp.SalesTransactionBL041312Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312Details[0].Reserved1 != null)
                        resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsUpdSlip3Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL041312DetailsUpdSlip4Rec([FromBody] SalesTransactionBL041312DetailsUpdSlip4RecReq salesTransactionBL041312DetailsUpdSlip4RecReq)
        {
            SalesTransactionBL041312DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip4RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId, salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsUpdSlip4Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312DetailsUpdSlip4RecReq));
                resp.SalesTransactionBL041312Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL041312DetailsUpdSlip4Rec(salesTransactionBL041312DetailsUpdSlip4RecReq.RecId, salesTransactionBL041312DetailsUpdSlip4RecReq.Slip4BL041312, salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? resp.SalesTransactionBL041312Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL041312Details[0].Reserved1 != null)
                        resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312DetailsUpdSlip4Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312Details = new List<SalesTransactionBL041312DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL041312UpdGlobalRec([FromBody] SalesTransactionBL041312UpdGlobalRecReq
salesTransactionBL041312UpdGlobalRecReq)
        {
            SalesTransactionBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdGlobalRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.CorrelationId,
                    salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdGlobalRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL041312UpdGlobalRecReq));
                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL041312UpdGlobalRec(
                    salesTransactionBL041312UpdGlobalRecReq.RecId,
                    salesTransactionBL041312UpdGlobalRecReq.ClientId,
                    salesTransactionBL041312UpdGlobalRecReq.MasterId,
                    salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.UserName, salesTransactionBL041312UpdGlobalRecReq.PolicyId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL041312.Reserved1 != null ? resp.SalesTransactionBL041312.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL041312.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.
                        CorrelationId;
                    if (resp.SalesTransactionBL041312.Reserved1 != null)
                        resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto
                        {
                            RecId = -1,
                            AF1BL041312 = new List<AF1BL041312Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL041312UpdGlobalRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL041312UpdGlobalRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}