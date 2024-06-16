using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.BL331211;
using Evaluation.CAL.Response.BL331211;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.BL331211;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL331211Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL331211Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211NewRec([FromBody] SalesTransactionBL331211NewRecReq salesTransactionBL331211NewRecReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211NewRecReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211NewRec(salesTransactionBL331211NewRecReq.BusinessLineCode, salesTransactionBL331211NewRecReq.ContactId, salesTransactionBL331211NewRecReq.AF1BL331211, salesTransactionBL331211NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL331211FindAF1WithRecIdFilter([FromBody] SalesTransactionBL331211FindAF1WithRecIdReq salesTransactionBL331211FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindAF1WithRecIdFilter(salesTransactionBL331211FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto
                        {
                            RecId = -1,
                            AF1BL331211 = new List<AF1BL331211Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL331211UpdAF1Rec([FromBody] SalesTransactionBL331211UpdAF1RecReq salesTransactionBL331211UpdAF1RecReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211UpdAF1RecReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211UpdAF1Rec(salesTransactionBL331211UpdAF1RecReq.RecId, salesTransactionBL331211UpdAF1RecReq.AF1BL331211, salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                        {
                            RecId = -1,
                            AF1BL331211 = new List<AF1BL331211Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211FindCQWithRecIdFilter([FromBody] SalesTransactionBL331211FindCQWithRecIdFilterReq salesTransactionBL331211FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL331211CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQPivotSummaryBL331211 = new List<dynamic>
                {
                },
                CQPivotSectionBL331211 = new List<dynamic>
                {
                },
                CQPivotMemberBL331211 = new List<dynamic>
                {
                },
                CQHeaderBL331211 = new List<CQHeader331211Dto>
                {
                },
                CQPivotBenefitBL331211 = new List<dynamic>
                {
                },
                CQPivotPricesListBL331211 = new List<dynamic>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQDetailsWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotSummaryBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQSummaryWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotSectionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQPivotWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotMemberBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQBenefitWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQBillsBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQBillsWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQHeaderWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBenefitBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQPivotBenefitWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotPricesListBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQPivotListPricesWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQCategoryWithRecIdFilter(salesTransactionBL331211FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQHeaderBL331211[0].Reserved1 != null ? resp.CQHeaderBL331211[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQHeaderBL331211[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQHeaderBL331211[0].Reserved1 != null)
                //        resp.CQHeaderBL331211 = new List<CQHeader331211>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQHeaderBL331211 = new List<CQHeader331211Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL331211FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL331211FindCQShortFullListWithRecIdFilterReq salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL331211CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL331211 = new List<CQFullListBL331211Dto>()
                {
                },
                CQShortListBL331211 = new List<CQShortListBL331211Dto>()
                {
                },
                CQHeaderBL331211 = new List<CQHeader331211Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQFullListWithRecIdFilter(salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQShortListWithRecIdFilter(salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQHeaderWithRecIdFilter(salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL331211.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL331211[0].Reserved1 != null ? resp.CQFullListBL331211[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL331211[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL331211[0].Reserved1 != null)
                        resp.CQFullListBL331211 = new List<CQFullListBL331211Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL331211 = new List<CQFullListBL331211Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211FindSlipWithRecIdFilter([FromBody] SalesTransactionBL331211FindAF1WithRecIdReq salesTransactionBL331211FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL331211SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                AF1BL331211 = new List<dynamic>(),
                Step2BL331211 = new List<dynamic>(),
                Step3BL331211 = new List<dynamic>(),
                Step4BL331211 = new List<dynamic>(),
                CQHeaderBL331211 = new List<CQHeader331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211FindAF1WithRecIdFilterReq));
                resp.AF1BL331211 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL331211FindAF1WithRecId(salesTransactionBL331211FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.Step2BL331211 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL331211FindStep2WithRecId(salesTransactionBL331211FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.Step3BL331211 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL331211FindStep3WithRecId(salesTransactionBL331211FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.Step4BL331211 = InstManagerAccessPoint.GetNewAccessPoint().salesTransactionBL331211FindStep4WithRecId(salesTransactionBL331211FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211FindCQHeaderWithRecIdFilter(salesTransactionBL331211FindAF1WithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;


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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.AF1BL331211 = new List<dynamic>();
                resp.Step2BL331211 = new List<dynamic>();
                resp.Step3BL331211 = new List<dynamic>();
                resp.Step4BL331211 = new List<dynamic>();
                resp.CQHeaderBL331211 = new List<CQHeader331211Dto>();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211UpdSlip2Rec([FromBody] SalesTransactionBL331211UpdSlip2RecReq salesTransactionBL331211UpdSlip2RecReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip2RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip2Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211UpdSlip2RecReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211UpdSlip2Rec(salesTransactionBL331211UpdSlip2RecReq.RecId, salesTransactionBL331211UpdSlip2RecReq.Slip2BL331211, salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                        {
                            RecId = -1,
                            AF1BL331211 = new List<AF1BL331211Dto>(),
                            Slip2BL331211 = new List<Slip2BL331211Dto>(),
                            Slip3BL331211 = new List<Slip3BL331211Dto>(),
                            Slip4BL331211 = new List<Slip4BL331211Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip2Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip2RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter([FromBody] SalesTransactionBL331211DetailsFindWithSalesTrxIdReq salesTransactionBL331211DetailsFindWithSalesTrxIdReq)
        {
            SalesTransactionBL331211DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
                {
                },
                SalesTransactionBL331211DetailsPrices = new List<SalesTransactionBL331211DetailsPriceDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsFindWithSalesTrxIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId, salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211DetailsFindWithSalesTrxIdReq));
                resp.SalesTransactionBL331211Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter(salesTransactionBL331211DetailsFindWithSalesTrxIdReq.SalesTransactionId);

                foreach (var item in resp.SalesTransactionBL331211Details)
                {
                    var salesTrxDetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter(item.RecId);
                    if (salesTrxDetailsPrices != null && salesTrxDetailsPrices.Count > 0 && salesTrxDetailsPrices[0].Reserved1 == null)
                    {
                        resp.SalesTransactionBL331211DetailsPrices.AddRange(salesTrxDetailsPrices);
                    }
                }

                if (resp != null && resp.SalesTransactionBL331211Details != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? resp.SalesTransactionBL331211Details[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211Details[0].Reserved1 != null)
                        resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211UpdSlip3Rec([FromBody] SalesTransactionBL331211UpdSlip3RecReq salesTransactionBL331211UpdSlip3RecReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip3RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip3Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211UpdSlip3RecReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211UpdSlip3Rec(salesTransactionBL331211UpdSlip3RecReq.RecId, salesTransactionBL331211UpdSlip3RecReq.Slip3BL331211, salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                        {
                            RecId = -1,
                            AF1BL331211 = new List<AF1BL331211Dto>(),
                            Slip2BL331211 = new List<Slip2BL331211Dto>(),
                            Slip3BL331211 = new List<Slip3BL331211Dto>(),
                            Slip4BL331211 = new List<Slip4BL331211Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip3Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip3RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211UpdSlip4Rec([FromBody] SalesTransactionBL331211UpdSlip4RecReq salesTransactionBL331211UpdSlip4RecReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip4RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip4Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211UpdSlip4RecReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211UpdSlip4Rec(salesTransactionBL331211UpdSlip4RecReq.RecId, salesTransactionBL331211UpdSlip4RecReq.Slip4BL331211, salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                        {
                            RecId = -1,
                            AF1BL331211 = new List<AF1BL331211Dto>(),
                            Slip2BL331211 = new List<Slip2BL331211Dto>(),
                            Slip3BL331211 = new List<Slip3BL331211Dto>(),
                            Slip4BL331211 = new List<Slip4BL331211Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip4Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip4RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL331211UpdSlip5Rec([FromBody] SalesTransactionBL331211UpdSlip5RecReq salesTransactionBL331211UpdSlip5RecReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>(),
                    Slip5BL331211 = new List<Slip5BL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip5RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip5Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211UpdSlip5RecReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211UpdSlip5Rec(salesTransactionBL331211UpdSlip5RecReq.RecId, salesTransactionBL331211UpdSlip5RecReq.Slip5BL331211, salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                        {
                            RecId = -1,
                            AF1BL331211 = new List<AF1BL331211Dto>(),
                            Slip2BL331211 = new List<Slip2BL331211Dto>(),
                            Slip3BL331211 = new List<Slip3BL331211Dto>(),
                            Slip4BL331211 = new List<Slip4BL331211Dto>(),
                            Slip5BL331211 = new List<Slip5BL331211Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdSlip5Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdSlip5RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>(),
                    Slip2BL331211 = new List<Slip2BL331211Dto>(),
                    Slip3BL331211 = new List<Slip3BL331211Dto>(),
                    Slip4BL331211 = new List<Slip4BL331211Dto>(),
                    Slip5BL331211 = new List<Slip5BL331211Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211DetailsPricesNewRec([FromBody] SalesTransactionBL331211DetailsPricesNewRecReq salesTransactionBL331211DetailsPricesNewRecReq)
        {
            SalesTransactionBL331211DetailsPricesResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211DetailsPrices = new List<SalesTransactionBL331211DetailsPriceDto>()
                {
                },
                SalesTransactionBL331211Details = new SalesTransactionBL331211DetailsNewDto()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsPricesNewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsPricesNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211DetailsPricesNewRecReq));
                resp.SalesTransactionBL331211DetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsPricesNewRec(salesTransactionBL331211DetailsPricesNewRecReq.salesTransactionBL331211DetailsPrices, salesTransactionBL331211DetailsPricesNewRecReq.CommisinOnGPPer, salesTransactionBL331211DetailsPricesNewRecReq.AdminFeesAmount, salesTransactionBL331211DetailsPricesNewRecReq.CostOfPolicyPer, salesTransactionBL331211DetailsPricesNewRecReq.CostOfPolicyAmount, salesTransactionBL331211DetailsPricesNewRecReq.FixedTaxesAmount, salesTransactionBL331211DetailsPricesNewRecReq.FixedTaxesPer, salesTransactionBL331211DetailsPricesNewRecReq.VATPer, salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.UserName);

                resp.SalesTransactionBL331211Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsFindWithRecIdFilter(salesTransactionBL331211DetailsPricesNewRecReq.salesTransactionBL331211DetailsPrices[0].SalesTrxDetailsId);

                if (resp != null && resp.SalesTransactionBL331211DetailsPrices != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 != null ? resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 != null)
                        resp.SalesTransactionBL331211DetailsPrices = new List<SalesTransactionBL331211DetailsPriceDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsPricesNewRec is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsPricesNewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211DetailsPrices = new List<SalesTransactionBL331211DetailsPriceDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter([FromBody] SalesTransactionBL331211DetailsPricesFindWithSalesTrxDetailsIdReq salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq)
        {
            SalesTransactionBL331211DetailsPricesResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211DetailsPrices = new List<SalesTransactionBL331211DetailsPriceDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId, salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq));
                resp.SalesTransactionBL331211DetailsPrices = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter(salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.SalesTransactionDetailsId);

                if (resp != null && resp.SalesTransactionBL331211DetailsPrices != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 != null ? resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211DetailsPrices[0].Reserved1 != null)
                        resp.SalesTransactionBL331211DetailsPrices = new List<SalesTransactionBL331211DetailsPriceDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsPricesFindWithSalesTrxIdReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211DetailsPrices = new List<SalesTransactionBL331211DetailsPriceDto>();

                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211DetailsUpdSlip2Rec([FromBody] SalesTransactionBL331211DetailsUpdSlip2RecReq salesTransactionBL331211DetailsUpdSlip2RecReq)
        {
            SalesTransactionBL331211DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip2RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsUpdSlip2Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211DetailsUpdSlip2RecReq));
                resp.SalesTransactionBL331211Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsUpdSlip2Rec(salesTransactionBL331211DetailsUpdSlip2RecReq.RecId, salesTransactionBL331211DetailsUpdSlip2RecReq.Slip2BL331211, salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? resp.SalesTransactionBL331211Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211Details[0].Reserved1 != null)
                        resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsUpdSlip2Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip2RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211DetailsUpdSlip3Rec([FromBody] SalesTransactionBL331211DetailsUpdSlip3RecReq salesTransactionBL331211DetailsUpdSlip3RecReq)
        {
            SalesTransactionBL331211DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip3RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsUpdSlip3Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211DetailsUpdSlip3RecReq));
                resp.SalesTransactionBL331211Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsUpdSlip3Rec(salesTransactionBL331211DetailsUpdSlip3RecReq.RecId, salesTransactionBL331211DetailsUpdSlip3RecReq.Slip3BL331211, salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? resp.SalesTransactionBL331211Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211Details[0].Reserved1 != null)
                        resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsUpdSlip3Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip3RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211DetailsUpdSlip4Rec([FromBody] SalesTransactionBL331211DetailsUpdSlip4RecReq salesTransactionBL331211DetailsUpdSlip4RecReq)
        {
            SalesTransactionBL331211DetailsResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip4RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId, salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsUpdSlip4Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211DetailsUpdSlip4RecReq));
                resp.SalesTransactionBL331211Details = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL331211DetailsUpdSlip4Rec(salesTransactionBL331211DetailsUpdSlip4RecReq.RecId, salesTransactionBL331211DetailsUpdSlip4RecReq.Slip4BL331211, salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? resp.SalesTransactionBL331211Details[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211Details[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL331211Details[0].Reserved1 != null)
                        resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211DetailsUpdSlip4Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211DetailsUpdSlip4RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211Details = new List<SalesTransactionBL331211DetailsDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL331211UpdGlobalRec([FromBody] SalesTransactionBL331211UpdGlobalRecReq
salesTransactionBL331211UpdGlobalRecReq)
        {
            SalesTransactionBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdGlobalRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.CorrelationId,
                    salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdGlobalRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL331211UpdGlobalRecReq));
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL331211UpdGlobalRec(
                    salesTransactionBL331211UpdGlobalRecReq.RecId,
                    salesTransactionBL331211UpdGlobalRecReq.ClientId,
                    salesTransactionBL331211UpdGlobalRecReq.MasterId,
                    salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.UserName, salesTransactionBL331211UpdGlobalRecReq.PolicyId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL331211.Reserved1 != null ? resp.SalesTransactionBL331211.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL331211.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.
                        CorrelationId;
                    if (resp.SalesTransactionBL331211.Reserved1 != null)
                        resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto
                        {
                            RecId = -1,
                            AF1BL331211 = new List<AF1BL331211Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL331211UpdGlobalRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL331211UpdGlobalRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}