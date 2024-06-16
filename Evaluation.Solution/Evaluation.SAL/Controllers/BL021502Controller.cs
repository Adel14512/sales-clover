using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL021502;
using Evaluation.CAL.Request.BL021502;
using Evaluation.CAL.Response.BL021502;
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
    public class BL021502Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL021502Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL021502NewRec([FromBody] SalesTransactionBL021502NewRecReq salesTransactionBL021502NewRecReq)
        {
            SalesTransactionBL021502Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL021502 = new SalesTransactionBL021502Dto() { RecId = -1 }
            };

            try
            {
                //var lookup = InstManagerAccessPoint.GetNewAccessPoint().LookupFindAll();
                //ModelState.AddModelError("GenderCode", "gender code is not valid");

                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL021502NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL021502NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL021502NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL021502NewRecReq));
                resp.SalesTransactionBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502NewRec(salesTransactionBL021502NewRecReq.BusinessLineCode, salesTransactionBL021502NewRecReq.ContactId, salesTransactionBL021502NewRecReq.AF1BL021502, salesTransactionBL021502NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL021502.Reserved1 != null ? resp.SalesTransactionBL021502.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL021502.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL021502.Reserved1 != null)
                        resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL021502NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL021502FindAF1WithRecIdFilter([FromBody] SalesTransactionBL021502FindAF1WithRecIdReq salesTransactionBL021502FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL021502Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL021502 = new SalesTransactionBL021502Dto()
                {
                    RecId = -1,
                    AF1BL021502 = new List<AF1BL021502Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL021502FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindAF1WithRecIdFilter(salesTransactionBL021502FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL021502.Reserved1 != null ? resp.SalesTransactionBL021502.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL021502.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL021502.Reserved1 != null)
                        resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto
                        {
                            RecId = -1,
                            AF1BL021502 = new List<AF1BL021502Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto
                {
                    RecId = -1,
                    AF1BL021502 = new List<AF1BL021502Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL021502UpdAF1Rec([FromBody] SalesTransactionBL021502UpdAF1RecReq salesTransactionBL021502UpdAF1RecReq)
        {
            SalesTransactionBL021502Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL021502 = new SalesTransactionBL021502Dto()
                {
                    RecId = -1,
                    AF1BL021502 = new List<AF1BL021502Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }

                _logger.SetCorrelationId(salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL021502UpdAF1RecReq));
                resp.SalesTransactionBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502UpdAF1Rec(salesTransactionBL021502UpdAF1RecReq.RecId, salesTransactionBL021502UpdAF1RecReq.AF1BL021502, salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL021502.Reserved1 != null ? resp.SalesTransactionBL021502.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL021502.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL021502.Reserved1 != null)
                        resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto()
                        {
                            RecId = -1,
                            AF1BL021502 = new List<AF1BL021502Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL021502UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto()
                {
                    RecId = -1,
                    AF1BL021502 = new List<AF1BL021502Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL021502FindCQWithRecIdFilter([FromBody] SalesTransactionBL021502FindCQWithRecIdFilterReq salesTransactionBL021502FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL021502CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                //CQDetailsBL021502 = new List<CQDetailsBL021502Dto>
                //{
                //},
                //CQSummaryBL021502 = new List<CQSummaryBL021502Dto>
                //{
                //},
                CQPivotBL021502 = new List<dynamic>
                {
                },
                CQBenefitBL021502 = new List<dynamic>
                {
                },
                CQBillsBL021502 = new List<dynamic>
                {
                },
                CQHeaderBL021502 = new List<CQHeader021502Dto>
                {
                }
                //,
                //CQCategoryBL021502 = new List<CQCategory021502Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL021502FindCQWithRecIdFilterReq));
                //resp.CQDetailsBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQDetailsWithRecIdFilter(salesTransactionBL021502FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQSummaryBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQSummaryWithRecIdFilter(salesTransactionBL021502FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQPivotWithRecIdFilter(salesTransactionBL021502FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQBenefitWithRecIdFilter(salesTransactionBL021502FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQBillsWithRecIdFilter(salesTransactionBL021502FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQHeaderWithRecIdFilter(salesTransactionBL021502FindCQWithRecIdFilterReq.SalesTransactionId);
                //resp.CQCategoryBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQCategoryWithRecIdFilter(salesTransactionBL021502FindCQWithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQPivotBL021502[0].Reserved1 != null ? resp.CQPivotBL021502[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQPivotBL021502[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQPivotBL021502[0].Reserved1 != null)
                        resp.CQPivotBL021502 = new List<dynamic>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQPivotBL021502 = new List<dynamic>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL021502FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL021502FindCQShortFullListWithRecIdFilterReq salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL021502CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL021502 = new List<CQFullListBL021502Dto>()
                {
                },
                CQShortListBL021502 = new List<CQShortListBL021502Dto>()
                {
                },
                CQHeaderBL021502 = new List<CQHeader021502Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQFullListWithRecIdFilter(salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQShortListWithRecIdFilter(salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQHeaderWithRecIdFilter(salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL021502.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL021502[0].Reserved1 != null ? resp.CQFullListBL021502[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL021502[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL021502[0].Reserved1 != null)
                        resp.CQFullListBL021502 = new List<CQFullListBL021502Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL021502 = new List<CQFullListBL021502Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL021502FindSlipWithRecIdFilter([FromBody] SalesTransactionBL021502FindAF1WithRecIdReq salesTransactionBL021502FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL021502SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL021502 = new SalesTransactionBL021502Dto()
                {
                    RecId = -1,
                    AF1BL021502 = new List<AF1BL021502Dto>()
                },
                CQHeaderBL021502 = new List<CQHeader021502Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL021502FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindAF1WithRecIdFilter(salesTransactionBL021502FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL021502 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL021502FindCQHeaderWithRecIdFilter(salesTransactionBL021502FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL021502.Reserved1 != null ? resp.SalesTransactionBL021502.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL021502.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL021502.Reserved1 != null)
                        resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto
                        {
                            RecId = -1,
                            AF1BL021502 = { new AF1BL021502Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL021502FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL021502FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL021502 = new SalesTransactionBL021502Dto
                {
                    RecId = -1,
                    AF1BL021502 = { new AF1BL021502Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}
