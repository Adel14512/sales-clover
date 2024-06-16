using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.BL311703;
using Evaluation.CAL.Response.BL311703;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.BL311703;
using Evaluation.CAL.DTO.BL331211;
using Evaluation.CAL.Request.BL331211;
using Evaluation.CAL.Response.BL331211;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL311703Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL311703Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SalesTransactionBL311703NewRec([FromBody] SalesTransactionBL311703NewRecReq salesTransactionBL311703NewRecReq)
        {
            SalesTransactionBL311703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL311703 = new SalesTransactionBL311703Dto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703NewRecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL311703NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL311703NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL311703NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL311703NewRecReq));
                resp.SalesTransactionBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703NewRec(salesTransactionBL311703NewRecReq.BusinessLineCode, salesTransactionBL311703NewRecReq.ContactId, salesTransactionBL311703NewRecReq.AF1BL311703, salesTransactionBL311703NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL311703.Reserved1 != null ? resp.SalesTransactionBL311703.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL311703.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL311703.Reserved1 != null)
                        resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL311703NewRecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL311703FindAF1WithRecIdFilter([FromBody] SalesTransactionBL311703FindAF1WithRecIdReq salesTransactionBL311703FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL311703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL311703 = new SalesTransactionBL311703Dto()
                {
                    RecId = -1,
                    AF1BL311703 = new List<AF1BL311703Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL311703FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindAF1WithRecIdFilter(salesTransactionBL311703FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL311703.Reserved1 != null ? resp.SalesTransactionBL311703.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL311703.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL311703.Reserved1 != null)
                        resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto
                        {
                            RecId = -1,
                            AF1BL311703 = new List<AF1BL311703Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto
                {
                    RecId = -1,
                    AF1BL311703 = new List<AF1BL311703Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL311703UpdAF1Rec([FromBody] SalesTransactionBL311703UpdAF1RecReq salesTransactionBL311703UpdAF1RecReq)
        {
            SalesTransactionBL311703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL311703 = new SalesTransactionBL311703Dto()
                {
                    RecId = -1,
                    AF1BL311703 = new List<AF1BL311703Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703UpdAF1RecReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703UpdAF1RecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.CorrelationId, salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703UpdAF1Rec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL311703UpdAF1RecReq));
                resp.SalesTransactionBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703UpdAF1Rec(salesTransactionBL311703UpdAF1RecReq.RecId, salesTransactionBL311703UpdAF1RecReq.AF1BL311703, salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL311703.Reserved1 != null ? resp.SalesTransactionBL311703.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL311703.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL311703.Reserved1 != null)
                        resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto()
                        {
                            RecId = -1,
                            AF1BL311703 = new List<AF1BL311703Dto>()
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703UpdAF1Rec is completed");

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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL311703UpdAF1RecReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto()
                {
                    RecId = -1,
                    AF1BL311703 = new List<AF1BL311703Dto>()
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL311703FindCQWithRecIdFilter([FromBody] SalesTransactionBL311703FindCQWithRecIdFilterReq salesTransactionBL311703FindCQWithRecIdFilterReq)
        {
            SalesTransactionBL311703CQResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQDetailsBL311703 = new List<CQDetailsBL311703Dto>
                {
                },
                CQSummaryBL311703 = new List<CQSummaryBL311703Dto>
                {
                },
                CQPivotBL311703 = new List<dynamic>
                {
                },
                CQBenefitBL311703 = new List<dynamic>
                {
                },
                CQBillsBL311703 = new List<dynamic>
                {
                },
                CQHeaderBL311703 = new List<CQHeader311703Dto>
                {
                },
                CQCategoryBL311703 = new List<CQCategory311703Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindCQWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindCQWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL311703FindCQWithRecIdFilterReq));
                resp.CQDetailsBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQDetailsWithRecIdFilter(salesTransactionBL311703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQSummaryBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQSummaryWithRecIdFilter(salesTransactionBL311703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQPivotBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQPivotWithRecIdFilter(salesTransactionBL311703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBenefitBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQBenefitWithRecIdFilter(salesTransactionBL311703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQBillsBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQBillsWithRecIdFilter(salesTransactionBL311703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQHeaderWithRecIdFilter(salesTransactionBL311703FindCQWithRecIdFilterReq.SalesTransactionId);
                resp.CQCategoryBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQCategoryWithRecIdFilter(salesTransactionBL311703FindCQWithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQDetailsBL311703[0].Reserved1 != null ? resp.CQDetailsBL311703[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQDetailsBL311703[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQDetailsBL311703[0].Reserved1 != null)
                        resp.CQDetailsBL311703 = new List<CQDetailsBL311703Dto>
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindCQWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindCQWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQDetailsBL311703 = new List<CQDetailsBL311703Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult SalesTransactionBL311703FindShortFullWithRecIdFilter([FromBody] SalesTransactionBL311703FindCQShortFullListWithRecIdFilterReq salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq)
        {
            SalesTransactionBL311703CQShortFulListResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                CQFullListBL311703 = new List<CQFullListBL311703Dto>()
                {
                },
                CQShortListBL311703 = new List<CQShortListBL311703Dto>()
                {
                },
                CQHeaderBL311703 = new List<CQHeader311703Dto>
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindShortFullWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq));
                resp.CQFullListBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQFullListWithRecIdFilter(salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQShortListBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQShortListWithRecIdFilter(salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQHeaderWithRecIdFilter(salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId);

                if (resp != null && resp.CQFullListBL311703.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.CQFullListBL311703[0].Reserved1 != null ? resp.CQFullListBL311703[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.CQFullListBL311703[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.CQFullListBL311703[0].Reserved1 != null)
                        resp.CQFullListBL311703 = new List<CQFullListBL311703Dto>
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
                    resp.WebResponseCommon.ReturnMessage = "RecId (" + salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.SalesTransactionId + ") is missing";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindShortFullWithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindCQShortFullListWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.CQFullListBL311703 = new List<CQFullListBL311703Dto>
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult SalesTransactionBL311703FindSlipWithRecIdFilter([FromBody] SalesTransactionBL311703FindAF1WithRecIdReq salesTransactionBL311703FindAF1WithRecIdFilterReq)
        {
            SalesTransactionBL311703SlipResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                SalesTransactionBL311703 = new SalesTransactionBL311703Dto()
                {
                    RecId = -1,
                    AF1BL311703 = new List<AF1BL311703Dto>()
                },
                CQHeaderBL311703 = new List<CQHeader311703Dto>()
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
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindAF1WithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindAF1WithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL311703FindAF1WithRecIdFilterReq));
                resp.SalesTransactionBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindAF1WithRecIdFilter(salesTransactionBL311703FindAF1WithRecIdFilterReq.SalesTransactionId);
                resp.CQHeaderBL311703 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL311703FindCQHeaderWithRecIdFilter(salesTransactionBL311703FindAF1WithRecIdFilterReq.SalesTransactionId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL311703.Reserved1 != null ? resp.SalesTransactionBL311703.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL311703.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.SalesTransactionBL311703.Reserved1 != null)
                        resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto
                        {
                            RecId = -1,
                            AF1BL311703 = { new AF1BL311703Dto { } }
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
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL311703FindAF1WithRecIdFilter is completed");
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
                resp.WebResponseCommon.CorrelationId = salesTransactionBL311703FindAF1WithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.SalesTransactionBL311703 = new SalesTransactionBL311703Dto
                {
                    RecId = -1,
                    AF1BL311703 = { new AF1BL311703Dto { } }
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}