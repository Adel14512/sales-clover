using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.BL051807;
using Evaluation.CAL.Response.BL051807;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.BL051807;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL051807Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL051807Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL051807NewRec([FromBody] SalesTransactionBL051807NewRecReq salesTransactionBL051807NewRecReq)
        {
            SalesTransactionBL051807Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL051807 = new SalesTransactionBL051807Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL051807NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL051807NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL051807NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL051807NewRecReq));
                resp.SalesTransactionBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807NewRec(salesTransactionBL051807NewRecReq.BusinessLineCode, salesTransactionBL051807NewRecReq.ContactId, salesTransactionBL051807NewRecReq.AF1BL051807, salesTransactionBL051807NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL051807.Reserved1 != null ? resp.SalesTransactionBL051807.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL051807.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL051807.Reserved1 != null)
                        resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL051807NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL051807FindAF1WithRecIdFilter([FromBody] SalesTransactionBL051807FindAF1WithRecIdReq salesTransactionBL051807FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL051807Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL051807 = new SalesTransactionBL051807Dto()
                {
                    RecId = -1,
                    AF1BL051807 = new List<AF1BL051807Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL051807FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindAF1WithRecIdFilter(salesTransactionBL051807FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL051807.Reserved1 != null ? resp.SalesTransactionBL051807.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL051807.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL051807.Reserved1 != null)
                        resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto
                        {
                            RecId = -1,
                            AF1BL051807 = new List<AF1BL051807Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto
                {
                    RecId = -1,
                    AF1BL051807 = new List<AF1BL051807Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL051807UpdAF1Rec([FromBody] SalesTransactionBL051807UpdAF1RecReq salesTransactionBL051807UpdAF1RecReq)
        {
            SalesTransactionBL051807Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL051807 = new SalesTransactionBL051807Dto()
                {
                    RecId = -1,
                    AF1BL051807 = new List<AF1BL051807Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL051807UpdAF1RecReq));
                resp.SalesTransactionBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807UpdAF1Rec(salesTransactionBL051807UpdAF1RecReq.RecId, salesTransactionBL051807UpdAF1RecReq.AF1BL051807, salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL051807.Reserved1 != null ? resp.SalesTransactionBL051807.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL051807.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL051807.Reserved1 != null)
                        resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto()
                        {
                            RecId = -1,
                            AF1BL051807 = new List<AF1BL051807Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL051807UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto()
                {
                    RecId = -1,
                    AF1BL051807 = new List<AF1BL051807Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL051807FindCQWithRecIdFilter([FromBody] SalesTransactionBL051807FindCQWithRecIdFilterReq salesTransactionBL051807FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL051807CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQDetailsBL051807 = new List<CQDetailsBL051807Dto>
                {
                },
                CQSummaryBL051807 = new List<CQSummaryBL051807Dto>
                {
                },
                CQPivotBL051807 = new List<dynamic>
                {
                },
                CQBenefitBL051807 = new List<dynamic>
                {
                },
                CQBillsBL051807 = new List<dynamic>
                {
                },
                CQHeaderBL051807 = new List<CQHeader051807Dto>
                {
                },
                CQCategoryBL051807 = new List<CQCategory051807Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL051807FindCQWithRecIdFilterReq));
                resp.CQDetailsBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQDetailsWithRecIdFilter(salesTransactionBL051807FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQSummaryBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQSummaryWithRecIdFilter(salesTransactionBL051807FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQPivotWithRecIdFilter(salesTransactionBL051807FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQBenefitWithRecIdFilter(salesTransactionBL051807FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQBillsWithRecIdFilter(salesTransactionBL051807FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQHeaderWithRecIdFilter(salesTransactionBL051807FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQCategoryBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQCategoryWithRecIdFilter(salesTransactionBL051807FindCQWithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL051807[0].Reserved1 != null ? resp.CQDetailsBL051807[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL051807[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQDetailsBL051807[0].Reserved1 != null)
                        resp.CQDetailsBL051807 = new List<CQDetailsBL051807Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQDetailsBL051807 = new List<CQDetailsBL051807Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult SalesTransactionBL051807FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL051807FindCQShortFullListWithRecIdFilterReq salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL051807CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL051807 = new List<CQFullListBL051807Dto>()
                {
                },
                CQShortListBL051807 = new List<CQShortListBL051807Dto>()
                {
                },
                CQHeaderBL051807 = new List<CQHeader051807Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQFullListWithRecIdFilter(salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQShortListWithRecIdFilter(salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQHeaderWithRecIdFilter(salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL051807.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL051807[0].Reserved1 != null ? resp.CQFullListBL051807[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL051807[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL051807[0].Reserved1 != null)
                        resp.CQFullListBL051807 = new List<CQFullListBL051807Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL051807 = new List<CQFullListBL051807Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL051807FindSlipWithRecIdFilter([FromBody] SalesTransactionBL051807FindAF1WithRecIdReq salesTransactionBL051807FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL051807SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL051807 = new SalesTransactionBL051807Dto()
                {
                    RecId = -1,
                    AF1BL051807 = new List<AF1BL051807Dto>()
                },
                CQHeaderBL051807 = new List<CQHeader051807Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL051807FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindAF1WithRecIdFilter(salesTransactionBL051807FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL051807 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL051807FindCQHeaderWithRecIdFilter(salesTransactionBL051807FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL051807.Reserved1 != null ? resp.SalesTransactionBL051807.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL051807.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL051807.Reserved1 != null)
                        resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto
                        {
                            RecId = -1,
                            AF1BL051807 = { new AF1BL051807Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL051807FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL051807FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL051807 = new SalesTransactionBL051807Dto
                {
                    RecId = -1,
                    AF1BL051807 = { new AF1BL051807Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}