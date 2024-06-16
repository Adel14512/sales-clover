using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.BL030904;
using Evaluation.CAL.Response.BL030904;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.BL030904;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL030904Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL030904Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL030904NewRec([FromBody] SalesTransactionBL030904NewRecReq salesTransactionBL030904NewRecReq)
        {
            SalesTransactionBL030904Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL030904 = new SalesTransactionBL030904Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL030904NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL030904NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL030904NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL030904NewRecReq));
                resp.SalesTransactionBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904NewRec(salesTransactionBL030904NewRecReq.BusinessLineCode, salesTransactionBL030904NewRecReq.ContactId, salesTransactionBL030904NewRecReq.AF1BL030904, salesTransactionBL030904NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL030904.Reserved1 != null ? resp.SalesTransactionBL030904.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL030904.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL030904.Reserved1 != null)
                        resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL030904NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL030904FindAF1WithRecIdFilter([FromBody] SalesTransactionBL030904FindAF1WithRecIdReq salesTransactionBL030904FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL030904Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL030904 = new SalesTransactionBL030904Dto()
                {
                    RecId = -1,
                    AF1BL030904 = new List<AF1BL030904Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL030904FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindAF1WithRecIdFilter(salesTransactionBL030904FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL030904.Reserved1 != null ? resp.SalesTransactionBL030904.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL030904.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL030904.Reserved1 != null)
                        resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto
                        {
                            RecId = -1,
                            AF1BL030904 = new List<AF1BL030904Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto
                {
                    RecId = -1,
                    AF1BL030904 = new List<AF1BL030904Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL030904UpdAF1Rec([FromBody] SalesTransactionBL030904UpdAF1RecReq salesTransactionBL030904UpdAF1RecReq)
        {
            SalesTransactionBL030904Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL030904 = new SalesTransactionBL030904Dto()
                {
                    RecId = -1,
                    AF1BL030904 = new List<AF1BL030904Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL030904UpdAF1RecReq));
                resp.SalesTransactionBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904UpdAF1Rec(salesTransactionBL030904UpdAF1RecReq.RecId, salesTransactionBL030904UpdAF1RecReq.AF1BL030904, salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL030904.Reserved1 != null ? resp.SalesTransactionBL030904.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL030904.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL030904.Reserved1 != null)
                        resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto()
                        {
                            RecId = -1,
                            AF1BL030904 = new List<AF1BL030904Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL030904UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto()
                {
                    RecId = -1,
                    AF1BL030904 = new List<AF1BL030904Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL030904FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL030904FindCQShortFullListWithRecIdFilterReq salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL030904CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL030904 = new List<CQFullListBL030904Dto>()
                {
                },
                CQShortListBL030904 = new List<CQShortListBL030904Dto>()
                {
                },
                CQHeaderBL030904 = new List<CQHeader030904Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQFullListWithRecIdFilter(salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQShortListWithRecIdFilter(salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQHeaderWithRecIdFilter(salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL030904.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL030904[0].Reserved1 != null ? resp.CQFullListBL030904[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL030904[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL030904[0].Reserved1 != null)
                        resp.CQFullListBL030904 = new List<CQFullListBL030904Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL030904 = new List<CQFullListBL030904Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL030904FindSlipWithRecIdFilter([FromBody] SalesTransactionBL030904FindAF1WithRecIdReq salesTransactionBL030904FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL030904SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL030904 = new SalesTransactionBL030904Dto()
                {
                    RecId = -1,
                    AF1BL030904 = new List<AF1BL030904Dto>()
                },
                CQHeaderBL030904 = new List<CQHeader030904Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL030904FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindAF1WithRecIdFilter(salesTransactionBL030904FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQHeaderWithRecIdFilter(salesTransactionBL030904FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL030904.Reserved1 != null ? resp.SalesTransactionBL030904.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL030904.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL030904.Reserved1 != null)
                        resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto
                        {
                            RecId = -1,
                            AF1BL030904 = { new AF1BL030904Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL030904 = new SalesTransactionBL030904Dto
                {
                    RecId = -1,
                    AF1BL030904 = { new AF1BL030904Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        //[HttpPost]
        //public IActionResult SalesTransactionBL030904FindCQWithRecIdFilter([FromBody] SalesTransactionBL030904FindCQWithRecIdFilterReq salesTransactionBL030904FindCQWithRecIdFilterReq)
        //{
        //    SalesTransactionBL030904CQResp resp;
        //    resp = new()
        //    {
        //        WebResponseCommon = new()
        //        {
        //        },
        //        CQDetailsBL030904 = new List<CQDetailsBL030904Dto>
        //        {
        //        },
        //        CQSummaryBL030904 = new List<CQSummaryBL030904Dto>
        //        {
        //        },
        //        CQPivotBL030904 = new List<dynamic>
        //        {
        //        },
        //        CQBenefitBL030904 = new List<dynamic>
        //        {
        //        },
        //        CQBillsBL030904 = new List<dynamic>
        //        {
        //        },
        //        CQHeaderBL030904 = new List<CQHeader030904>
        //        {
        //        },
        //        CQCategoryBL030904 = new List<CQCategory030904>
        //        {
        //        }
        //    };

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
        //            resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage));
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
        //                salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

        //            return Ok(resp);
        //        }
        //        _logger.SetCorrelationId(salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindCQWithRecIdFilter is started");
        //        _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL030904FindCQWithRecIdFilterReq));
        //        resp.CQDetailsBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQDetailsWithRecIdFilter(salesTransactionBL030904FindCQWithRecIdFilterReq.SalesTransactionId);
        //        resp.CQSummaryBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQSummaryWithRecIdFilter(salesTransactionBL030904FindCQWithRecIdFilterReq.SalesTransactionId);
        //        resp.CQPivotBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQPivotWithRecIdFilter(salesTransactionBL030904FindCQWithRecIdFilterReq.SalesTransactionId);
        //        resp.CQBenefitBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQBenefitWithRecIdFilter(salesTransactionBL030904FindCQWithRecIdFilterReq.SalesTransactionId);
        //        resp.CQBillsBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQBillsWithRecIdFilter(salesTransactionBL030904FindCQWithRecIdFilterReq.SalesTransactionId);
        //        resp.CQHeaderBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQHeaderWithRecIdFilter(salesTransactionBL030904FindCQWithRecIdFilterReq.SalesTransactionId);
        //        resp.CQCategoryBL030904 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL030904FindCQCategoryWithRecIdFilter(salesTransactionBL030904FindCQWithRecIdFilterReq.SalesTransactionId);

        //        if (resp != null)// && resp.Region.Count == 1)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL030904[0].Reserved1 != null ? resp.CQDetailsBL030904[0].Reserved1 : "Enquiry Succeeded";
        //            resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL030904[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
        //            if (resp.CQDetailsBL030904[0].Reserved1 != null)
        //                resp.CQDetailsBL030904 = new List<CQDetailsBL030904Dto>
        //                {
        //                };
        //            //{
        //            //    Code= regionNewRecReq.Region.Code,
        //            //    Description= regionNewRecReq.Region.Description,
        //            //    IsActive= regionNewRecReq.Region.IsActive                            
        //            //};
        //        }
        //        else
        //        {
        //            //
        //        }
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL030904FindCQWithRecIdFilter is completed");
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        return Ok(resp);
        //        // UserCredDao t = new UserCredDao();
        //        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error", ex);
        //        resp.WebResponseCommon.SuccessIndicator = "Error";
        //        resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
        //        resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
        //        resp.WebResponseCommon.CorrelationId = salesTransactionBL030904FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
        //        resp.CQDetailsBL030904 = new List<CQDetailsBL030904Dto>
        //        {
        //        };
        //        //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
        //        return Ok(resp);
        //    }
        //}
    }
}
