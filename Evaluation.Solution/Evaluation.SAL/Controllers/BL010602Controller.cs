using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL010602;
using Evaluation.CAL.Request.BL010602;
using Evaluation.CAL.Response.BL010602;
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
    public class BL010602Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL010602Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL010602NewRec([FromBody] SalesTransactionBL010602NewRecReq salesTransactionBL010602NewRecReq)
        {
            SalesTransactionBL010602Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL010602 = new SalesTransactionBL010602Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL010602NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL010602NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL010602NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL010602NewRecReq));
                resp.SalesTransactionBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602NewRec(salesTransactionBL010602NewRecReq.BusinessLineCode, salesTransactionBL010602NewRecReq.ContactId, salesTransactionBL010602NewRecReq.ClientId, salesTransactionBL010602NewRecReq.MasterId, salesTransactionBL010602NewRecReq.AF1BL010602, salesTransactionBL010602NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL010602.Reserved1 != null ? resp.SalesTransactionBL010602.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL010602.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL010602.Reserved1 != null)
                        resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL010602NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL010602FindAF1WithRecIdFilter([FromBody] SalesTransactionBL010602FindAF1WithRecIdFilterReq salesTransactionBL010602FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL010602Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL010602 = new SalesTransactionBL010602Dto()
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL010602FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindAF1WithRecIdFilter(salesTransactionBL010602FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL010602.Reserved1 != null ? resp.SalesTransactionBL010602.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL010602.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL010602.Reserved1 != null)
                        resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto
                        {
                            RecId = -1,
                            AF1BL010602 = new AF1BL010602Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL010602UpdAF1Rec([FromBody] SalesTransactionBL010602UpdAF1RecReq salesTransactionBL010602UpdAF1RecReq)
        {
            SalesTransactionBL010602Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL010602 = new SalesTransactionBL010602Dto()
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL010602UpdAF1RecReq));
                resp.SalesTransactionBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602UpdAF1Rec(salesTransactionBL010602UpdAF1RecReq.RecId, salesTransactionBL010602UpdAF1RecReq.ClientId, salesTransactionBL010602UpdAF1RecReq.MasterId, salesTransactionBL010602UpdAF1RecReq.AF1BL010602, salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL010602.Reserved1 != null ? resp.SalesTransactionBL010602.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL010602.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL010602.Reserved1 != null)
                        resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto
                        {
                            RecId = -1,
                            AF1BL010602 = new AF1BL010602Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL010602UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto()
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL010602FindCQWithRecIdFilter([FromBody] SalesTransactionBL010602FindCQWithRecIdFilterReq salesTransactionBL010602FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL010602CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL010602 = new List<CQDetailsBL010602Dto>
                //{
                //},
                //CQSummaryBL010602 = new List<CQSummaryBL010602Dto>
                //{
                //},
                CQPivotBL010602 = new List<dynamic>
                {
                },
                CQBenefitBL010602 = new List<dynamic>
                {
                },
                CQBillsBL010602 = new List<dynamic>
                {
                },
                CQHeaderBL010602 = new List<CQHeader010602Dto>
                {
                }
                //},
                //CQCategoryBL010602 = new List<CQCategory010602Dto>
                //{
                //}
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL010602FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQDetailsWithRecIdFilter(salesTransactionBL010602FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQSummaryWithRecIdFilter(salesTransactionBL010602FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQPivotWithRecIdFilter(salesTransactionBL010602FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                resp.CQBenefitBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQBenefitWithRecIdFilter(salesTransactionBL010602FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                resp.CQBillsBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQBillsWithRecIdFilter(salesTransactionBL010602FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                resp.CQHeaderBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQHeaderWithRecIdFilter(salesTransactionBL010602FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                //resp.CQCategoryBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQCategoryWithRecIdFilter(salesTransactionBL010602FindCQWithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQPivotBL010602[0].Reserved1 != null ? resp.CQPivotBL010602[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQPivotBL010602[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQPivotBL010602[0].Reserved1 != null)
                        resp.CQPivotBL010602 = new List<dynamic>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL010602 = new List<dynamic>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL010602FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL010602FindCQShortFullListWithRecIdFilterReq salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL010602CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL010602 = new List<CQFullListBL010602Dto>()
                {
                },
                CQShortListBL010602 = new List<CQShortListBL010602Dto>()
                {
                },
                CQHeaderBL010602 = new List<CQHeader010602Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQFullListWithRecIdFilter(salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQShortListWithRecIdFilter(salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQHeaderWithRecIdFilter(salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL010602.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL010602[0].Reserved1 != null ? resp.CQFullListBL010602[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL010602[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL010602[0].Reserved1 != null)
                        resp.CQFullListBL010602 = new List<CQFullListBL010602Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL010602 = new List<CQFullListBL010602Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL010602FindSlipWithRecIdFilter([FromBody] SalesTransactionBL010602FindAF1WithRecIdFilterReq salesTransactionBL010602FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL010602SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL010602 = new SalesTransactionBL010602Dto()
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
                },
                CQHeaderBL010602 = new List<CQHeader010602Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL010602FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindAF1WithRecIdFilter(salesTransactionBL010602FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL010602 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL010602FindCQHeaderWithRecIdFilter(salesTransactionBL010602FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL010602.Reserved1 != null ? resp.SalesTransactionBL010602.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL010602.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL010602.Reserved1 != null)
                        resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto
                        {
                            RecId = -1,
                            AF1BL010602 = new AF1BL010602Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL010602FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL010602FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL010602 = new SalesTransactionBL010602Dto
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}
