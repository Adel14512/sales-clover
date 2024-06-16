using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL301401;
using Evaluation.CAL.Request.BL301401;
using Evaluation.CAL.Response.BL301401;
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
    public class BL301401Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL301401Controller(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SalesTransactionBL301401NewRec([FromBody] SalesTransactionBL301401NewRecReq salesTransactionBL301401NewRecReq)
        {
            SalesTransactionBL301401Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL301401 = new SalesTransactionBL301401Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL301401NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL301401NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL301401NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL301401NewRecReq));
                resp.SalesTransactionBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401NewRec(salesTransactionBL301401NewRecReq.BusinessLineCode, salesTransactionBL301401NewRecReq.ContactId, salesTransactionBL301401NewRecReq.AF1BL301401, salesTransactionBL301401NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL301401.Reserved1 != null ? resp.SalesTransactionBL301401.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL301401.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL301401.Reserved1 != null)
                        resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL301401NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL301401FindAF1WithRecIdFilter([FromBody] SalesTransactionBL301401FindAF1WithRecIdReq salesTransactionBL301401FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL301401Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL301401FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindAF1WithRecIdFilter(salesTransactionBL301401FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL301401.Reserved1 != null ? resp.SalesTransactionBL301401.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL301401.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL301401.Reserved1 != null)
                        resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto
                        {
                            RecId = -1,
                            AF1BL301401 = new List<AF1BL301401Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL301401UpdAF1Rec([FromBody] SalesTransactionBL301401UpdAF1RecReq salesTransactionBL301401UpdAF1RecReq)
        {
            SalesTransactionBL301401Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL301401UpdAF1RecReq));
                resp.SalesTransactionBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401UpdAF1Rec(salesTransactionBL301401UpdAF1RecReq.RecId, salesTransactionBL301401UpdAF1RecReq.AF1BL301401, salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL301401.Reserved1 != null ? resp.SalesTransactionBL301401.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL301401.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL301401.Reserved1 != null)
                        resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                        {
                            RecId = -1,
                            AF1BL301401 = new List<AF1BL301401Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL301401UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL301401FindCQWithRecIdFilter([FromBody] SalesTransactionBL301401FindCQWithRecIdFilterReq salesTransactionBL301401FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL301401CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL301401 = new List<CQDetailsBL301401Dto>
                //{
                //},
                //CQSummaryBL301401 = new List<CQSummaryBL301401Dto>
                //{
                //},
                CQPivotBL301401 = new List<dynamic>
                {
                },
                CQBenefitBL301401 = new List<dynamic>
                {
                },
                CQBenefitCompareBL301401 = new List<dynamic>
                {
                },
                CQPivotMemberBL301401 = new List<dynamic>
                {
                },
                CQHeaderBL301401 = new List<CQHeader301401Dto>
                {
                },
                CQCategoryBL301401 = new List<CQCategory>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL301401FindCQWithRecIdFilterReq));

                //resp.CQBenefitBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQBenefitWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);

                //resp.CQDetailsBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQDetailsWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQSummaryWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQPivotWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQBenefitWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitCompareBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQBenefitCompareWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotMemberBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQPivotMemberWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQHeaderWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQCategoryBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQCategoryWithRecIdFilter(salesTransactionBL301401FindCQWithRecIdFilterReq.SalesTransactionId);


                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    //if (resp.CQPivotBL301401[0].Reserved1 != null)
                    //    resp.CQPivotBL301401 = new List<dynamic>
                    //    {
                    //    };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL301401 = new List<dynamic>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL301401FindShortFullWithRecIdFilter([FromBody]
        SalesTransactionBL301401FindCQShortFullListWithRecIdFilterReq salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL301401CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL301401 = new List<CQFullListBL301401Dto>()
                {
                },
                CQShortListBL301401 = new List<CQShortListBL301401Dto>()
                {
                },
                CQHeaderBL301401 = new List<CQHeader301401Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindCQShortFullListWithRecIdFilterReq is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQFullListWithRecIdFilter(salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQShortListWithRecIdFilter(salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQHeaderWithRecIdFilter(salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL301401.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL301401[0].Reserved1 != null ? resp.CQFullListBL301401[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL301401[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL301401[0].Reserved1 != null)
                        resp.CQFullListBL301401 = new List<CQFullListBL301401Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindCQShortFullListWithRecIdFilterReq is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL301401 = new List<CQFullListBL301401Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL301401FindSlipWithRecIdFilter([FromBody] SalesTransactionBL301401FindAF1WithRecIdReq salesTransactionBL301401FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL301401SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
                },
                CQHeaderBL301401 = new List<CQHeader301401Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL301401FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindAF1WithRecIdFilter(salesTransactionBL301401FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL301401 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL301401FindCQHeaderWithRecIdFilter(salesTransactionBL301401FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL301401.Reserved1 != null ? resp.SalesTransactionBL301401.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL301401.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL301401.Reserved1 != null)
                        resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto
                        {
                            RecId = -1,
                            AF1BL301401 = { new AF1BL301401Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL301401FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto
                {
                    RecId = -1,
                    AF1BL301401 = { new AF1BL301401Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL301401UpdGlobalRec([FromBody] SalesTransactionBL301401UpdGlobalRecReq
    salesTransactionBL301401UpdGlobalRecReq)
        {
            SalesTransactionBL301401Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401UpdGlobalRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.CorrelationId,
                    salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401UpdGlobalRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL301401UpdGlobalRecReq));
                resp.SalesTransactionBL301401 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL301401UpdGlobalRec(
                    salesTransactionBL301401UpdGlobalRecReq.RecId,
                    salesTransactionBL301401UpdGlobalRecReq.ClientId,
                    salesTransactionBL301401UpdGlobalRecReq.MasterId,
                    salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.UserName, salesTransactionBL301401UpdGlobalRecReq.PolicyId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL301401.Reserved1 != null ? resp.SalesTransactionBL301401.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL301401.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.
                        CorrelationId;
                    if (resp.SalesTransactionBL301401.Reserved1 != null)
                        resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto
                        {
                            RecId = -1,
                            AF1BL301401 = new List<AF1BL301401Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL301401UpdGlobalRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL301401UpdGlobalRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
