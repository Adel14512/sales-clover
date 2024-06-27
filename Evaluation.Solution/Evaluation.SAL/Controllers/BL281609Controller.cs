using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.BL281609;
using Evaluation.CAL.Response.BL281609;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.BL281609;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL281609Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL281609Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL281609NewRec([FromBody] SalesTransactionBL281609NewRecReq salesTransactionBL281609NewRecReq)
        {
            SalesTransactionBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL281609 = new SalesTransactionBL281609Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL281609NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609NewRecReq));
                resp.SalesTransactionBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609NewRec(salesTransactionBL281609NewRecReq.BusinessLineCode, salesTransactionBL281609NewRecReq.ContactId, salesTransactionBL281609NewRecReq.AF1BL281609, salesTransactionBL281609NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL281609.Reserved1 != null ? resp.SalesTransactionBL281609.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL281609.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL281609.Reserved1 != null)
                        resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL281609FindAF1WithRecIdFilter([FromBody] SalesTransactionBL281609FindAF1WithRecIdReq salesTransactionBL281609FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindAF1WithRecIdFilter(salesTransactionBL281609FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL281609.Reserved1 != null ? resp.SalesTransactionBL281609.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL281609.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL281609.Reserved1 != null)
                        resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto
                        {
                            RecId = -1,
                            AF1BL281609 = new List<AF1BL281609Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL281609UpdAF1Rec([FromBody] SalesTransactionBL281609UpdAF1RecReq salesTransactionBL281609UpdAF1RecReq)
        {
            SalesTransactionBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609UpdAF1RecReq));
                resp.SalesTransactionBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609UpdAF1Rec(salesTransactionBL281609UpdAF1RecReq.RecId, salesTransactionBL281609UpdAF1RecReq.AF1BL281609, salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL281609.Reserved1 != null ? resp.SalesTransactionBL281609.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL281609.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL281609.Reserved1 != null)
                        resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                        {
                            RecId = -1,
                            AF1BL281609 = new List<AF1BL281609Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL281609FindCQWithRecIdFilter([FromBody] SalesTransactionBL281609FindCQWithRecIdFilterReq salesTransactionBL281609FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL281609CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL281609 = new List<CQDetailsBL281609Dto>
                //{
                //},
                //CQSummaryBL281609 = new List<CQSummaryBL281609Dto>
                //{
                //},
                CQPivotBL281609 = new List<dynamic>
                {
                },
                CQBenefitBL281609 = new List<dynamic>
                {
                },
                CQBillsBL281609 = new List<dynamic>
                {
                },
                CQHeaderBL281609 = new List<CQHeader281609Dto>
                {
                },
                //CQCategoryBL281609 = new List<CQCategory281609Dto>
                //{
                //},
                CQBenefitComapreBL281609 = new List<dynamic> { }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQDetailsWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQSummaryWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQPivotWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                resp.CQBenefitBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQBenefitWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                resp.CQBillsBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQBillsWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                resp.CQHeaderBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQHeaderWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);//ok
                //resp.CQCategoryBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQCategoryWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitComapreBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQBenefitCompareWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);//ok

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQPivotBL281609[0].Reserved1 != null ? resp.CQPivotBL281609[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQPivotBL281609[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQPivotBL281609[0].Reserved1 != null)
                        resp.CQPivotBL281609 = new List<dynamic>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL281609 = new List<dynamic>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL281609FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL281609FindCQShortFullListWithRecIdFilterReq salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL281609CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL281609 = new List<CQFullListBL281609Dto>()
                {
                },
                CQShortListBL281609 = new List<CQShortListBL281609Dto>()
                {
                },
                CQHeaderBL281609 = new List<CQHeader281609Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQFullListWithRecIdFilter(salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQShortListWithRecIdFilter(salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQHeaderWithRecIdFilter(salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL281609.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL281609[0].Reserved1 != null ? resp.CQFullListBL281609[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL281609[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL281609[0].Reserved1 != null)
                        resp.CQFullListBL281609 = new List<CQFullListBL281609Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL281609 = new List<CQFullListBL281609Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL281609FindSlipWithRecIdFilter([FromBody] SalesTransactionBL281609FindAF1WithRecIdReq salesTransactionBL281609FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL281609SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
                },
                CQHeaderBL281609 = new List<CQHeader281609Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindAF1WithRecIdFilter(salesTransactionBL281609FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQHeaderWithRecIdFilter(salesTransactionBL281609FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL281609.Reserved1 != null ? resp.SalesTransactionBL281609.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL281609.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL281609.Reserved1 != null)
                        resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto
                        {
                            RecId = -1,
                            AF1BL281609 = { new AF1BL281609Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto
                {
                    RecId = -1,
                    AF1BL281609 = { new AF1BL281609Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL281609FindCQShortWithRecIdFilter([FromBody] SalesTransactionBL281609FindCQWithRecIdFilterReq salesTransactionBL281609FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL281609CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL281609 = new List<CQDetailsBL281609Dto>
                //{
                //},
                //CQSummaryBL281609 = new List<CQSummaryBL281609Dto>
                //{
                //},
                CQPivotBL281609 = new List<dynamic>
                {
                },
                CQBenefitBL281609 = new List<dynamic>
                {
                },
                CQBillsBL281609 = new List<dynamic>
                {
                },
                CQHeaderBL281609 = new List<CQHeader281609Dto>
                {
                },
                //CQCategoryBL281609 = new List<CQCategory281609Dto>
                //{
                //},
                CQBenefitComapreBL281609 = new List<dynamic> { }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindCQShortWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQDetailsWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQSummaryWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQShortPivotWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQShortBenefitWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQShortBillsWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQHeaderWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQCategoryWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitComapreBL281609 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL281609FindCQShortBenefitCompareWithRecIdFilter(salesTransactionBL281609FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL281609.Count == 0 ? resp.CQDetailsBL281609[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL281609[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQDetailsBL281609[0].Reserved1 != null)
                //        resp.CQDetailsBL281609 = new List<CQDetailsBL281609Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609FindCQShortWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL281609 = new List<dynamic>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL281609UpdGlobalRec([FromBody] SalesTransactionBL281609UpdGlobalRecReq
salesTransactionBL281609UpdGlobalRecReq)
        {
            SalesTransactionBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609UpdGlobalRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.CorrelationId,
                    salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609UpdGlobalRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL281609UpdGlobalRecReq));
                resp.SalesTransactionBL281609 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL281609UpdGlobalRec(
                    salesTransactionBL281609UpdGlobalRecReq.RecId,
                    salesTransactionBL281609UpdGlobalRecReq.ClientId,
                    salesTransactionBL281609UpdGlobalRecReq.MasterId,
                    salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.UserName, salesTransactionBL281609UpdGlobalRecReq.PolicyId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL281609.Reserved1 != null ? resp.SalesTransactionBL281609.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL281609.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.
                        CorrelationId;
                    if (resp.SalesTransactionBL281609.Reserved1 != null)
                        resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto
                        {
                            RecId = -1,
                            AF1BL281609 = new List<AF1BL281609Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL281609UpdGlobalRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL281609UpdGlobalRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}