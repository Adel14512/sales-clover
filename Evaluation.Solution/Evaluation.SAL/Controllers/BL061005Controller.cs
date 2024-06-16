using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.BL061005;
using Evaluation.CAL.Response.BL061005;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.BL061005;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL061005Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL061005Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL061005NewRec([FromBody] SalesTransactionBL061005NewRecReq salesTransactionBL061005NewRecReq)
        {
            SalesTransactionBL061005Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL061005 = new SalesTransactionBL061005Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL061005NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL061005NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL061005NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL061005NewRecReq));
                resp.SalesTransactionBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005NewRec(salesTransactionBL061005NewRecReq.BusinessLineCode, salesTransactionBL061005NewRecReq.ContactId, salesTransactionBL061005NewRecReq.ClientId, salesTransactionBL061005NewRecReq.MasterId, salesTransactionBL061005NewRecReq.AF1BL061005, salesTransactionBL061005NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL061005.Reserved1 != null ? resp.SalesTransactionBL061005.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL061005.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL061005.Reserved1 != null)
                        resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL061005NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL061005FindAF1WithRecIdFilter([FromBody] SalesTransactionBL061005FindAF1WithRecIdReq salesTransactionBL061005FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL061005Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL061005 = new SalesTransactionBL061005Dto()
                {
                    RecId = -1,
                    AF1BL061005 = new List<AF1BL061005Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL061005FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindAF1WithRecIdFilter(salesTransactionBL061005FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL061005.Reserved1 != null ? resp.SalesTransactionBL061005.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL061005.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL061005.Reserved1 != null)
                        resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto
                        {
                            RecId = -1,
                            AF1BL061005 = new List<AF1BL061005Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto
                {
                    RecId = -1,
                    AF1BL061005 = new List<AF1BL061005Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL061005UpdAF1Rec([FromBody] SalesTransactionBL061005UpdAF1RecReq salesTransactionBL061005UpdAF1RecReq)
        {
            SalesTransactionBL061005Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL061005 = new SalesTransactionBL061005Dto()
                {
                    RecId = -1,
                    AF1BL061005 = new List<AF1BL061005Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL061005UpdAF1RecReq));
                resp.SalesTransactionBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005UpdAF1Rec(salesTransactionBL061005UpdAF1RecReq.RecId, salesTransactionBL061005UpdAF1RecReq.ClientId, salesTransactionBL061005UpdAF1RecReq.MasterId, salesTransactionBL061005UpdAF1RecReq.AF1BL061005, salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL061005.Reserved1 != null ? resp.SalesTransactionBL061005.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL061005.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL061005.Reserved1 != null)
                        resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto()
                        {
                            RecId = -1,
                            AF1BL061005 = new List<AF1BL061005Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL061005UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto()
                {
                    RecId = -1,
                    AF1BL061005 = new List<AF1BL061005Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL061005FindCQWithRecIdFilter([FromBody] SalesTransactionBL061005FindCQWithRecIdFilterReq salesTransactionBL061005FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL061005CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQDetailsBL061005 = new List<CQDetailsBL061005Dto>
                {
                },
                CQSummaryBL061005 = new List<CQSummaryBL061005Dto>
                {
                },
                CQPivotBL061005 = new List<dynamic>
                {
                },
                CQBenefitBL061005 = new List<dynamic>
                {
                },
                CQBillsBL061005 = new List<dynamic>
                {
                },
                CQHeaderBL061005 = new List<CQHeader061005Dto>
                {
                },
                CQCategoryBL061005 = new List<CQCategory061005Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL061005FindCQWithRecIdFilterReq));
                resp.CQDetailsBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQDetailsWithRecIdFilter(salesTransactionBL061005FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQSummaryBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQSummaryWithRecIdFilter(salesTransactionBL061005FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQPivotWithRecIdFilter(salesTransactionBL061005FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQBenefitWithRecIdFilter(salesTransactionBL061005FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQBillsWithRecIdFilter(salesTransactionBL061005FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQHeaderWithRecIdFilter(salesTransactionBL061005FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQCategoryBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQCategoryWithRecIdFilter(salesTransactionBL061005FindCQWithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL061005[0].Reserved1 != null ? resp.CQDetailsBL061005[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL061005[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQDetailsBL061005[0].Reserved1 != null)
                        resp.CQDetailsBL061005 = new List<CQDetailsBL061005Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQDetailsBL061005 = new List<CQDetailsBL061005Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL061005FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL061005FindCQShortFullListWithRecIdFilterReq salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL061005CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL061005 = new List<CQFullListBL061005Dto>()
                {
                },
                CQShortListBL061005 = new List<CQShortListBL061005Dto>()
                {
                },
                CQHeaderBL061005 = new List<CQHeader061005Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQFullListWithRecIdFilter(salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQShortListWithRecIdFilter(salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQHeaderWithRecIdFilter(salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL061005.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL061005[0].Reserved1 != null ? resp.CQFullListBL061005[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL061005[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL061005[0].Reserved1 != null)
                        resp.CQFullListBL061005 = new List<CQFullListBL061005Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL061005 = new List<CQFullListBL061005Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL061005FindSlipWithRecIdFilter([FromBody] SalesTransactionBL061005FindAF1WithRecIdReq salesTransactionBL061005FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL061005SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL061005 = new SalesTransactionBL061005Dto()
                {
                    RecId = -1,
                    AF1BL061005 = new List<AF1BL061005Dto>()
                },
                CQHeaderBL061005 = new List<CQHeader061005Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL061005FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindAF1WithRecIdFilter(salesTransactionBL061005FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL061005 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL061005FindCQHeaderWithRecIdFilter(salesTransactionBL061005FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL061005.Reserved1 != null ? resp.SalesTransactionBL061005.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL061005.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL061005.Reserved1 != null)
                        resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto
                        {
                            RecId = -1,
                            AF1BL061005 = { new AF1BL061005Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL061005FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL061005FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL061005 = new SalesTransactionBL061005Dto
                {
                    RecId = -1,
                    AF1BL061005 =  { new AF1BL061005Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}