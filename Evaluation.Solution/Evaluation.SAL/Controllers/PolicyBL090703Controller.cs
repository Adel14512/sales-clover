using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL090703;
using Evaluation.CAL.DTO.BL090703Consolidation;
using Evaluation.CAL.Request.BL090703Consolidation;
using Evaluation.CAL.Response.BL090703Consolidation;
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
    public class PolicyBL090703Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL090703Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PolicyBL090703NewRec([FromBody] PolicyBL090703NewRecReq policyBL090703NewRecReq)
        {
            PolicyBL090703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL090703Dto>() { },
                SalesTransactionBL090703 = new SalesTransactionBL090703Dto()
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
                },
                paymentScheduleBL090703 = new List<PaymentScheduleBL090703Dto>(),
                policyRelatedDoc090703 = new List<PolicyRelatedDocBL090703Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL090703NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL090703NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL090703NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL090703NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL090703NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL090703NewRecReq.WebRequestCommon.CorrelationId, policyBL090703NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL090703NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL090703NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL090703NewRec
                    (policyBL090703NewRecReq.SalesTransactionId,
                    policyBL090703NewRecReq.ProductId,
                    policyBL090703NewRecReq.Combination, policyBL090703NewRecReq.BusinessLineCode,
                    policyBL090703NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL090703 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL090703FindAF1WithRecIdFilter(policyBL090703NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL090703 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL090703(policyBL090703NewRecReq.SalesTransactionId, policyBL090703NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc090703 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL090703(policyBL090703NewRecReq.SalesTransactionId, policyBL090703NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL090703NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL090703Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL090703NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL090703NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL090703Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL090703UpdRec([FromBody] PolicyRelatedDocBL090703UpdRecReq policyRelatedDocBL090703UpdRecReq)
        {
            PolicyRelatedDocBL090703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL090703Dto = new PolicyRelatedDocBL090703Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL090703UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL090703UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL090703UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL090703UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL090703UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL090703UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL090703UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL090703UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL090703UpdRecReq));
                resp.PolicyRelatedDocBL090703Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL090703UpdRec
                    (policyRelatedDocBL090703UpdRecReq.RecId,
                    policyRelatedDocBL090703UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL090703UpdRecReq.AttachDocName,
                      policyRelatedDocBL090703UpdRecReq.AttachDocExt,
                    policyRelatedDocBL090703UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL090703Dto.Reserved1 != null ? resp.PolicyRelatedDocBL090703Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL090703Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL090703UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL090703Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL090703Dto = new PolicyRelatedDocBL090703Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL090703UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL090703UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL090703Dto = new PolicyRelatedDocBL090703Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL090703NewRec([FromBody] PolicyRelatedDocBL090703NewRecReq policyRelatedDocBL090703NewRecReq)
        {
            PolicyRelatedDocBL090703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL090703Dto = new PolicyRelatedDocBL090703Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL090703NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL090703NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL090703NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL090703NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL090703NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL090703NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL090703NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL090703NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL090703NewRecReq));
                resp.PolicyRelatedDocBL090703Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL090703NewRec(
                    policyRelatedDocBL090703NewRecReq.SalesTransactionId,
                    policyRelatedDocBL090703NewRecReq.TicketId,
                    policyRelatedDocBL090703NewRecReq.ParentPolicyId,
                    policyRelatedDocBL090703NewRecReq.PolicyId,
                    policyRelatedDocBL090703NewRecReq.BusinessLineCode,
                    policyRelatedDocBL090703NewRecReq.DocumentType,
                    policyRelatedDocBL090703NewRecReq.AttachDocBinary,
                    policyRelatedDocBL090703NewRecReq.AttachDocName,
                    policyRelatedDocBL090703NewRecReq.AttachDocExt,
                    policyRelatedDocBL090703NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL090703Dto.Reserved1 != null ? resp.PolicyRelatedDocBL090703Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL090703Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL090703NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL090703Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL090703Dto = new PolicyRelatedDocBL090703Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL090703NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL090703NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL090703Dto = new PolicyRelatedDocBL090703Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL090703UpdRec([FromBody] PolicyBL090703UpdRecReq policyBL090703UpdRecReq)
        {
            PolicyBL090703UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL090703 = new List<PolicyBL090703Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL090703UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL090703UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL090703UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL090703UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL090703UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL090703UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL090703UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL090703UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL090703UpdRecReq));
                resp.PolicyBL090703 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL090703UpdRec
                    (policyBL090703UpdRecReq.SalesTransactionId,
                    policyBL090703UpdRecReq.TicketId,
                     policyBL090703UpdRecReq.ParentPolicyId,
                      policyBL090703UpdRecReq.PolicyId,
                       policyBL090703UpdRecReq.BusinessLineCode,
                        policyBL090703UpdRecReq.GrossPremiumGP,
                        policyBL090703UpdRecReq.CommisionFromGPPer,
                        policyBL090703UpdRecReq.CommisionFromGPAmount,
                        policyBL090703UpdRecReq.VATOnCommisionPer,
                        policyBL090703UpdRecReq.VATOnCommisionAmount,
                        policyBL090703UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL090703UpdRecReq.BuiltInPropTaxesPer,
                        policyBL090703UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL090703UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL090703UpdRecReq.InsurerLoadingPer,
                        policyBL090703UpdRecReq.InsurerLoadingAmount,
                        policyBL090703UpdRecReq.NetPremiumAmount,
                        policyBL090703UpdRecReq.WebRequestCommon.UserName,
                policyBL090703UpdRecReq.PolicyNumber,
                        policyBL090703UpdRecReq.PolicyEffectiveDate,
                policyBL090703UpdRecReq.PolicyExpiryDate,
                        policyBL090703UpdRecReq.PolicyIssuedDate,
                        policyBL090703UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL090703[0].Reserved1 != null ?
                        resp.PolicyBL090703[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL090703[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL090703UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL090703[0].Reserved1 != null)
                        resp.PolicyBL090703 = new List<PolicyBL090703Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL090703UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL090703UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL090703 = new List<PolicyBL090703Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL090703FindAllWithParentPolicyId([FromBody] PolicyBL090703FindParentPolicyIdRecReq policyBL090703FindParentPolicyIdRecReq)
        {
            PolicyBL090703Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL090703Dto>() { },
                SalesTransactionBL090703 = new SalesTransactionBL090703Dto()
                {
                    RecId = -1,
                    AF1BL090703 = new AF1BL090703Dtco()
                },
                paymentScheduleBL090703 = new List<PaymentScheduleBL090703Dto>(),
                policyRelatedDoc090703 = new List<PolicyRelatedDocBL090703Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL090703FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL090703FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL090703FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL090703FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL090703FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL090703FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL090703FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL090703FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL090703FindAllWithParentPolicyId(policyBL090703FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL090703 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL090703FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL090703 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL090703(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc090703 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL090703(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL090703FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL090703Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL090703FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL090703Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}