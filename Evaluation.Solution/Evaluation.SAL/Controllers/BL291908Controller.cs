using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.BL291908;
using Evaluation.CAL.Response.BL291908;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.BL291908;
using Evaluation.CAL.DTO.BL281609;
using Evaluation.CAL.Request.BL281609;
using Evaluation.CAL.Response.BL281609;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL291908Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL291908Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL291908NewRec([FromBody] SalesTransactionBL291908NewRecReq salesTransactionBL291908NewRecReq)
        {
            SalesTransactionBL291908Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL291908 = new SalesTransactionBL291908Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL291908NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL291908NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL291908NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL291908NewRecReq));
                resp.SalesTransactionBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908NewRec(salesTransactionBL291908NewRecReq.BusinessLineCode, salesTransactionBL291908NewRecReq.ContactId, salesTransactionBL291908NewRecReq.AF1BL291908, salesTransactionBL291908NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL291908.Reserved1 != null ? resp.SalesTransactionBL291908.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL291908.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL291908.Reserved1 != null)
                        resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL291908NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL291908FindAF1WithRecIdFilter([FromBody] SalesTransactionBL291908FindAF1WithRecIdReq salesTransactionBL291908FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL291908Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL291908 = new SalesTransactionBL291908Dto()
                {
                    RecId = -1,
                    AF1BL291908 = new List<AF1BL291908Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL291908FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindAF1WithRecIdFilter(salesTransactionBL291908FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL291908.Reserved1 != null ? resp.SalesTransactionBL291908.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL291908.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL291908.Reserved1 != null)
                        resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto
                        {
                            RecId = -1,
                            AF1BL291908 = new List<AF1BL291908Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto
                {
                    RecId = -1,
                    AF1BL291908 = new List<AF1BL291908Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL291908UpdAF1Rec([FromBody] SalesTransactionBL291908UpdAF1RecReq salesTransactionBL291908UpdAF1RecReq)
        {
            SalesTransactionBL291908Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL291908 = new SalesTransactionBL291908Dto()
                {
                    RecId = -1,
                    AF1BL291908 = new List<AF1BL291908Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL291908UpdAF1RecReq));
                resp.SalesTransactionBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908UpdAF1Rec(salesTransactionBL291908UpdAF1RecReq.RecId, salesTransactionBL291908UpdAF1RecReq.AF1BL291908, salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL291908.Reserved1 != null ? resp.SalesTransactionBL291908.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL291908.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL291908.Reserved1 != null)
                        resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto()
                        {
                            RecId = -1,
                            AF1BL291908 = new List<AF1BL291908Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL291908UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto()
                {
                    RecId = -1,
                    AF1BL291908 = new List<AF1BL291908Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL291908FindCQWithRecIdFilter([FromBody] SalesTransactionBL291908FindCQWithRecIdFilterReq salesTransactionBL291908FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL291908CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQDetailsBL291908 = new List<CQDetailsBL291908Dto>
                {
                },
                CQSummaryBL291908 = new List<CQSummaryBL291908Dto>
                {
                },
                CQPivotBL291908 = new List<dynamic>
                {
                },
                CQBenefitBL291908 = new List<dynamic>
                {
                },
                CQBillsBL291908 = new List<dynamic>
                {
                },
                CQHeaderBL291908 = new List<CQHeader291908Dto>
                {
                },
                CQCategoryBL291908 = new List<CQCategory291908Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL291908FindCQWithRecIdFilterReq));
                resp.CQDetailsBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQDetailsWithRecIdFilter(salesTransactionBL291908FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQSummaryBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQSummaryWithRecIdFilter(salesTransactionBL291908FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQPivotWithRecIdFilter(salesTransactionBL291908FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQBenefitWithRecIdFilter(salesTransactionBL291908FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQBillsWithRecIdFilter(salesTransactionBL291908FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQHeaderWithRecIdFilter(salesTransactionBL291908FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQCategoryBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQCategoryWithRecIdFilter(salesTransactionBL291908FindCQWithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL291908[0].Reserved1 != null ? resp.CQDetailsBL291908[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL291908[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQDetailsBL291908[0].Reserved1 != null)
                        resp.CQDetailsBL291908 = new List<CQDetailsBL291908Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQDetailsBL291908 = new List<CQDetailsBL291908Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL291908FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL291908FindCQShortFullListWithRecIdFilterReq salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL291908CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL291908 = new List<CQFullListBL291908Dto>()
                {
                },
                CQShortListBL291908 = new List<CQShortListBL291908Dto>()
                {
                },
                CQHeaderBL291908 = new List<CQHeader291908Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQFullListWithRecIdFilter(salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQShortListWithRecIdFilter(salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQHeaderWithRecIdFilter(salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL291908.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL291908[0].Reserved1 != null ? resp.CQFullListBL291908[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL291908[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL291908[0].Reserved1 != null)
                        resp.CQFullListBL291908 = new List<CQFullListBL291908Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL291908 = new List<CQFullListBL291908Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL291908FindSlipWithRecIdFilter([FromBody] SalesTransactionBL291908FindAF1WithRecIdReq salesTransactionBL291908FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL291908SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL291908 = new SalesTransactionBL291908Dto()
                {
                    RecId = -1,
                    AF1BL291908 = new List<AF1BL291908Dto>()
                },
                CQHeaderBL291908 = new List<CQHeader291908Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL291908FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindAF1WithRecIdFilter(salesTransactionBL291908FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL291908 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL291908FindCQHeaderWithRecIdFilter(salesTransactionBL291908FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL291908.Reserved1 != null ? resp.SalesTransactionBL291908.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL291908.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL291908.Reserved1 != null)
                        resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto
                        {
                            RecId = -1,
                            AF1BL291908 = { new AF1BL291908Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL291908FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL291908FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL291908 = new SalesTransactionBL291908Dto
                {
                    RecId = -1,
                    AF1BL291908 = { new AF1BL291908Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}