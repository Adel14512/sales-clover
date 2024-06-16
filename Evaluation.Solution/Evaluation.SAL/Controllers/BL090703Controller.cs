using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL090703;
using Evaluation.CAL.Request.BL090703;
using Evaluation.CAL.Response.BL090703;
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
    public class BL090703Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL090703Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL090703NewRec([FromBody] SalesTransactionBL090703NewRecReq salesTransactionBL090703NewRecReq)
        {
            SalesTransactionBL090703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL090703 = new SalesTransactionBL090703Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL090703NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL090703NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL090703NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL090703NewRecReq));
                resp.SalesTransactionBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703NewRec(salesTransactionBL090703NewRecReq.BusinessLineCode, salesTransactionBL090703NewRecReq.ContactId, salesTransactionBL090703NewRecReq.ClientId, salesTransactionBL090703NewRecReq.MasterId, salesTransactionBL090703NewRecReq.AF1BL090703, salesTransactionBL090703NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL090703.Reserved1 != null ? resp.SalesTransactionBL090703.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL090703.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL090703.Reserved1 != null)
                        resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL090703NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL090703FindAF1WithRecIdFilter([FromBody] SalesTransactionBL090703FindAF1WithRecIdFilterReq salesTransactionBL090703FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL090703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL090703 = new SalesTransactionBL090703Dto()
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL090703FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindAF1WithRecIdFilter(salesTransactionBL090703FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL090703.Reserved1 != null ? resp.SalesTransactionBL090703.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL090703.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL090703.Reserved1 != null)
                        resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto
                        {
                            RecId = -1,
                            AF1BL090703 = new AF1BL090703Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL090703UpdAF1Rec([FromBody] SalesTransactionBL090703UpdAF1RecReq salesTransactionBL090703UpdAF1RecReq)
        {
            SalesTransactionBL090703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL090703 = new SalesTransactionBL090703Dto()
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL090703UpdAF1RecReq));
                resp.SalesTransactionBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703UpdAF1Rec(salesTransactionBL090703UpdAF1RecReq.RecId, salesTransactionBL090703UpdAF1RecReq.ClientId, salesTransactionBL090703UpdAF1RecReq.MasterId, salesTransactionBL090703UpdAF1RecReq.AF1BL090703, salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL090703.Reserved1 != null ? resp.SalesTransactionBL090703.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL090703.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL090703.Reserved1 != null)
                        resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto
                        {
                            RecId = -1,
                            AF1BL090703 = new AF1BL090703Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL090703UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto()
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL090703FindCQWithRecIdFilter([FromBody] SalesTransactionBL090703FindCQWithRecIdFilterReq salesTransactionBL090703FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL090703CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL090703 = new List<CQDetailsBL090703Dto>
                //{
                //},
                //CQSummaryBL090703 = new List<CQSummaryBL090703Dto>
                //{
                //},
                CQPivotBL090703 = new List<dynamic>
                {
                },
                CQBenefitBL090703 = new List<dynamic>
                {
                },
                CQBillsBL090703 = new List<dynamic>
                {
                },
                CQHeaderBL090703 = new List<CQHeader090703Dto>
                {
                },
                //CQCategoryBL090703 = new List<CQCategory090703Dto>
                //{
                //},
                CQBenefitComapreBL090703 = new List<dynamic> { }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL090703FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQDetailsWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQSummaryWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQPivotWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQBenefitWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQBillsWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQHeaderWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQCategoryWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitComapreBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQBenefitCompareWithRecIdFilter(salesTransactionBL090703FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL090703[0].Reserved1 != null ? resp.CQDetailsBL090703[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL090703[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQDetailsBL090703[0].Reserved1 != null)
                //        resp.CQDetailsBL090703 = new List<CQDetailsBL090703Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL090703 = new List<dynamic>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL090703FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL090703FindCQShortFullListWithRecIdFilterReq salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL090703CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL090703 = new List<CQFullListBL090703Dto>()
                {
                },
                CQShortListBL090703 = new List<CQShortListBL090703Dto>()
                {
                },
                CQHeaderBL090703 = new List<CQHeader090703Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQFullListWithRecIdFilter(salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQShortListWithRecIdFilter(salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQHeaderWithRecIdFilter(salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL090703.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL090703[0].Reserved1 != null ? resp.CQFullListBL090703[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL090703[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL090703[0].Reserved1 != null)
                        resp.CQFullListBL090703 = new List<CQFullListBL090703Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL090703 = new List<CQFullListBL090703Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL090703FindSlipWithRecIdFilter([FromBody] SalesTransactionBL090703FindAF1WithRecIdFilterReq salesTransactionBL090703FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL090703SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL090703 = new SalesTransactionBL090703Dto()
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
                },
                CQHeaderBL090703 = new List<CQHeader090703Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL090703FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindAF1WithRecIdFilter(salesTransactionBL090703FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL090703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL090703FindCQHeaderWithRecIdFilter(salesTransactionBL090703FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL090703.Reserved1 != null ? resp.SalesTransactionBL090703.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL090703.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL090703.Reserved1 != null)
                        resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto
                        {
                            RecId = -1,
                            AF1BL090703 = new AF1BL090703Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL090703FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL090703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL090703 = new SalesTransactionBL090703Dto
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}