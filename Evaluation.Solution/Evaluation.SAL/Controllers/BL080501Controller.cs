using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL080501;
using Evaluation.CAL.Request.BL080501;
using Evaluation.CAL.Response.BL080501;
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
    public class BL080501Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL080501Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL080501NewRec([FromBody] SalesTransactionBL080501NewRecReq salesTransactionBL080501NewRecReq)
        {
            SalesTransactionBL080501Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL080501 = new SalesTransactionBL080501Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL080501NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501NewRecReq));
                resp.SalesTransactionBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501NewRec(salesTransactionBL080501NewRecReq.BusinessLineCode, salesTransactionBL080501NewRecReq.ContactId,
                    salesTransactionBL080501NewRecReq.ClientId, salesTransactionBL080501NewRecReq.MasterId,
                    salesTransactionBL080501NewRecReq.AF1BL080501, salesTransactionBL080501NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL080501.Reserved1 != null ? resp.SalesTransactionBL080501.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL080501.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL080501.Reserved1 != null)
                        resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL080501FindAF1WithRecIdFilter([FromBody] SalesTransactionBL080501FindAF1WithRecIdFilterReq salesTransactionBL080501FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL080501Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindAF1WithRecIdFilter(salesTransactionBL080501FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL080501.Reserved1 != null ? resp.SalesTransactionBL080501.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL080501.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL080501.Reserved1 != null)
                        resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto
                        {
                            RecId = -1,
                            AF1BL080501 = new AF1BL080501Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL080501UpdAF1Rec([FromBody] SalesTransactionBL080501UpdAF1RecReq salesTransactionBL080501UpdAF1RecReq)
        {
            SalesTransactionBL080501Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501UpdAF1RecReq));
                resp.SalesTransactionBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501UpdAF1Rec(salesTransactionBL080501UpdAF1RecReq.RecId,
                    salesTransactionBL080501UpdAF1RecReq.ClientId, salesTransactionBL080501UpdAF1RecReq.MasterId,
                    salesTransactionBL080501UpdAF1RecReq.AF1BL080501, salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL080501.Reserved1 != null ? resp.SalesTransactionBL080501.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL080501.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL080501.Reserved1 != null)
                        resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto
                        {
                            RecId = -1,
                            AF1BL080501 = new AF1BL080501Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL080501UpdGlobalRec([FromBody] SalesTransactionBL080501UpdGlobalRecReq
            salesTransactionBL080501UpdGlobalRecReq)
        {
            SalesTransactionBL080501Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501UpdGlobalRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.CorrelationId,
                    salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501UpdGlobalRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501UpdGlobalRecReq));
                resp.SalesTransactionBL080501 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL080501UpdGlobalRec(
                    salesTransactionBL080501UpdGlobalRecReq.RecId,
                    salesTransactionBL080501UpdGlobalRecReq.ClientId,
                    salesTransactionBL080501UpdGlobalRecReq.MasterId,
                    salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.UserName, salesTransactionBL080501UpdGlobalRecReq.PolicyId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL080501.Reserved1 != null ? resp.SalesTransactionBL080501.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL080501.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.
                        CorrelationId;
                    if (resp.SalesTransactionBL080501.Reserved1 != null)
                        resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto
                        {
                            RecId = -1,
                            AF1BL080501 = new AF1BL080501Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501UpdGlobalRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501UpdGlobalRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL080501FindCQWithRecIdFilter([FromBody] SalesTransactionBL080501FindCQWithRecIdFilterReq salesTransactionBL080501FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL080501CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQDetailsBL080501 = new List<CQDetailsBL080501Dto>
                {
                },
                CQSummaryBL080501 = new List<CQSummaryBL080501Dto>
                {
                },
                CQPivotBL080501 = new List<dynamic>
                {
                },
                CQBenefitBL080501 = new List<dynamic>
                {
                },
                CQBillsBL080501 = new List<dynamic>
                {
                },
                CQHeaderBL080501 = new List<CQHeader080501>
                {
                },
                CQCategoryBL080501 = new List<CQCategory080501>
                {
                },
                CQBenefitComapreBL080501 = new List<dynamic> { }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501FindCQWithRecIdFilterReq));
                resp.CQDetailsBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQDetailsWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQSummaryBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQSummaryWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQPivotWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQBenefitWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQBillsWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQHeaderWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQCategoryBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQCategoryWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitComapreBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQBenefitCompareWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL080501.Count == 0 ? resp.CQDetailsBL080501[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL080501[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQDetailsBL080501[0].Reserved1 != null)
                //        resp.CQDetailsBL080501 = new List<CQDetailsBL080501Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQDetailsBL080501 = new List<CQDetailsBL080501Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL080501FindCQShortWithRecIdFilter([FromBody] SalesTransactionBL080501FindCQWithRecIdFilterReq salesTransactionBL080501FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL080501CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQDetailsBL080501 = new List<CQDetailsBL080501Dto>
                {
                },
                CQSummaryBL080501 = new List<CQSummaryBL080501Dto>
                {
                },
                CQPivotBL080501 = new List<dynamic>
                {
                },
                CQBenefitBL080501 = new List<dynamic>
                {
                },
                CQBillsBL080501 = new List<dynamic>
                {
                },
                CQHeaderBL080501 = new List<CQHeader080501>
                {
                },
                CQCategoryBL080501 = new List<CQCategory080501>
                {
                },
                CQBenefitComapreBL080501 = new List<dynamic> { }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindCQShortWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501FindCQWithRecIdFilterReq));
                resp.CQDetailsBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQDetailsWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQSummaryBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQSummaryWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQShortPivotWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQShortBenefitWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQShortBillsWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQHeaderWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQCategoryBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQCategoryWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitComapreBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQShortBenefitCompareWithRecIdFilter(salesTransactionBL080501FindCQWithRecIdFilterReq.SalesTransactionId);

                resp.WebResponseCommon.SuccessIndicator = "Success";
                resp.WebResponseCommon.ReturnMessage = "Enquiry Succeeded";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;

                //if (resp != null)// && resp.Region.Count == 1)
                //{
                //    resp.WebResponseCommon.SuccessIndicator = "Success";
                //    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL080501.Count == 0 ? resp.CQDetailsBL080501[0].Reserved1 : "Enquiry Succeeded";
                //    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL080501[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                //    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                //    if (resp.CQDetailsBL080501[0].Reserved1 != null)
                //        resp.CQDetailsBL080501 = new List<CQDetailsBL080501Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindCQShortWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQDetailsBL080501 = new List<CQDetailsBL080501Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult SalesTransactionBL080501FindSlipWithRecIdFilter([FromBody] SalesTransactionBL080501FindAF1WithRecIdFilterReq salesTransactionBL080501FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL080501SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
                },
                CQHeaderBL080501 = new List<CQHeader080501>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindSlipWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindAF1WithRecIdFilter(salesTransactionBL080501FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQHeaderWithRecIdFilter(salesTransactionBL080501FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL080501.Reserved1 != null ? resp.SalesTransactionBL080501.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL080501.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL080501.Reserved1 != null)
                        resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto
                        {
                            RecId = -1,
                            AF1BL080501 = new AF1BL080501Dtco()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindSlipWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL080501 = new SalesTransactionBL080501Dto
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult SalesTransactionBL080501FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL080501FindCQShortFullListWithRecIdFilterReq salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL080501CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL080501 = new List<CQFullListBL080501Dto>()
                {
                },
                CQShortListBL080501 = new List<CQShortListBL080501Dto>()
                {
                },
                CQHeaderBL080501 = new List<CQHeader080501>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQFullListWithRecIdFilter(salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQShortListWithRecIdFilter(salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL080501 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501FindCQHeaderWithRecIdFilter(salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL080501.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL080501[0].Reserved1 != null ? resp.CQFullListBL080501[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL080501[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL080501[0].Reserved1 != null)
                        resp.CQFullListBL080501 = new List<CQFullListBL080501Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL080501FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL080501FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL080501 = new List<CQFullListBL080501Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}
