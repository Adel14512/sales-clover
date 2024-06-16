using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL070806;
using Evaluation.CAL.Request.BL070806;
using Evaluation.CAL.Response.BL070806;
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
    public class BL070806Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL070806Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL070806NewRec([FromBody] SalesTransactionBL070806NewRecReq salesTransactionBL070806NewRecReq)
        {
            SalesTransactionBL070806Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL070806 = new SalesTransactionBL070806Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL070806NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806NewRecReq));
                resp.SalesTransactionBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806NewRec(salesTransactionBL070806NewRecReq.BusinessLineCode, salesTransactionBL070806NewRecReq.ContactId,
                    salesTransactionBL070806NewRecReq.ClientId, salesTransactionBL070806NewRecReq.MasterId, salesTransactionBL070806NewRecReq.AF1BL070806, salesTransactionBL070806NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL070806.Reserved1 != null ? resp.SalesTransactionBL070806.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL070806.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL070806.Reserved1 != null)
                        resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL070806FindAF1WithRecIdFilter([FromBody] SalesTransactionBL070806FindAF1WithRecIdFilterReq salesTransactionBL070806FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL070806Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL070806 = new SalesTransactionBL070806Dto()
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindAF1WithRecIdFilter(salesTransactionBL070806FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL070806.Reserved1 != null ? resp.SalesTransactionBL070806.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL070806.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL070806.Reserved1 != null)
                        resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto
                        {
                            RecId = -1,
                            AF1BL070806 = new AF1BL070806Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL070806UpdAF1Rec([FromBody] SalesTransactionBL070806UpdAF1RecReq salesTransactionBL070806UpdAF1RecReq)
        {
            SalesTransactionBL070806Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL070806 = new SalesTransactionBL070806Dto()
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806UpdAF1RecReq));
                resp.SalesTransactionBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806UpdAF1Rec(salesTransactionBL070806UpdAF1RecReq.RecId, salesTransactionBL070806UpdAF1RecReq.ClientId, salesTransactionBL070806UpdAF1RecReq.MasterId, salesTransactionBL070806UpdAF1RecReq.AF1BL070806, salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL070806.Reserved1 != null ? resp.SalesTransactionBL070806.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL070806.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL070806.Reserved1 != null)
                        resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto
                        {
                            RecId = -1,
                            AF1BL070806 = new AF1BL070806Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto()
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL070806FindCQWithRecIdFilter([FromBody] SalesTransactionBL070806FindCQWithRecIdFilterReq salesTransactionBL070806FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL070806CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL070806 = new List<CQDetailsBL070806Dto>
                //{
                //},
                //CQSummaryBL070806 = new List<CQSummaryBL070806Dto>
                //{
                //},
                CQPivotBL070806 = new List<dynamic>
                {
                },
                CQBenefitBL070806 = new List<dynamic>
                {
                },
                CQBillsBL070806 = new List<dynamic>
                {
                },
                CQHeaderBL070806 = new List<CQHeader070806Dto>
                {
                },
                //CQCategoryBL070806 = new List<CQCategory070806Dto>
                //{
                //},
                CQBenefitComapreBL070806 = new List<dynamic> { }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQDetailsWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQSummaryWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQPivotWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQBenefitWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQBillsWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQHeaderWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQCategoryWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitComapreBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQBenefitCompareWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL070806[0].Reserved1 != null ? resp.CQDetailsBL070806[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL070806[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQDetailsBL070806[0].Reserved1 != null)
                //        resp.CQDetailsBL070806 = new List<CQDetailsBL070806Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL070806 = new List<dynamic>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL070806FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL070806FindCQShortFullListWithRecIdFilterReq salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL070806CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL070806 = new List<CQFullListBL070806Dto>()
                {
                },
                CQShortListBL070806 = new List<CQShortListBL070806Dto>()
                {
                },
                CQHeaderBL070806 = new List<CQHeader070806Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQFullListWithRecIdFilter(salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQShortListWithRecIdFilter(salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQHeaderWithRecIdFilter(salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL070806.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL070806[0].Reserved1 != null ? resp.CQFullListBL070806[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL070806[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL070806[0].Reserved1 != null)
                        resp.CQFullListBL070806 = new List<CQFullListBL070806Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL070806 = new List<CQFullListBL070806Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL070806FindSlipWithRecIdFilter([FromBody] SalesTransactionBL070806FindAF1WithRecIdFilterReq salesTransactionBL070806FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL070806SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL070806 = new SalesTransactionBL070806Dto()
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
                },
                CQHeaderBL070806 = new List<CQHeader070806Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindSlipWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindAF1WithRecIdFilter(salesTransactionBL070806FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQHeaderWithRecIdFilter(salesTransactionBL070806FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL070806.Reserved1 != null ? resp.SalesTransactionBL070806.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL070806.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL070806.Reserved1 != null)
                        resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto
                        {
                            RecId = -1,
                            AF1BL070806 = new AF1BL070806Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindSlipWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL070806FindCQShortWithRecIdFilter([FromBody] SalesTransactionBL070806FindCQWithRecIdFilterReq salesTransactionBL070806FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL070806CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL070806 = new List<CQDetailsBL070806Dto>
                //{
                //},
                //CQSummaryBL070806 = new List<CQSummaryBL070806Dto>
                //{
                //},
                CQPivotBL070806 = new List<dynamic>
                {
                },
                CQBenefitBL070806 = new List<dynamic>
                {
                },
                CQBillsBL070806 = new List<dynamic>
                {
                },
                CQHeaderBL070806 = new List<CQHeader070806Dto>
                {
                },
                //CQCategoryBL070806 = new List<CQCategory070806Dto>
                //{
                //},
                CQBenefitComapreBL070806 = new List<dynamic> { }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindCQShortWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQDetailsWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQSummaryWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQShortPivotWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQShortBenefitWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQShortBillsWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQHeaderWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQCategoryWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitComapreBL070806 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL070806FindCQShortBenefitCompareWithRecIdFilter(salesTransactionBL070806FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL070806.Count == 0 ? resp.CQDetailsBL070806[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL070806[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQDetailsBL070806[0].Reserved1 != null)
                //        resp.CQDetailsBL070806 = new List<CQDetailsBL070806Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806FindCQShortWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL070806 = new List<dynamic>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL070806UpdGlobalRec([FromBody] SalesTransactionBL070806UpdGlobalRecReq
    salesTransactionBL070806UpdGlobalRecReq)
        {
            SalesTransactionBL070806Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL070806 = new SalesTransactionBL070806Dto()
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806UpdGlobalRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.CorrelationId,
                    salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806UpdGlobalRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL070806UpdGlobalRecReq));
                resp.SalesTransactionBL070806 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL070806UpdGlobalRec(
                    salesTransactionBL070806UpdGlobalRecReq.RecId,
                    salesTransactionBL070806UpdGlobalRecReq.ClientId,
                    salesTransactionBL070806UpdGlobalRecReq.MasterId,
                    salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL070806.Reserved1 != null ? resp.SalesTransactionBL070806.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL070806.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.
                        CorrelationId;
                    if (resp.SalesTransactionBL070806.Reserved1 != null)
                        resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto
                        {
                            RecId = -1,
                            AF1BL070806 = new AF1BL070806Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL070806UpdGlobalRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL070806UpdGlobalRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL070806 = new SalesTransactionBL070806Dto()
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}