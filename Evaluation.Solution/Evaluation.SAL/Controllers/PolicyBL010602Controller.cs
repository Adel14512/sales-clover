using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL010602;
using Evaluation.CAL.DTO.BL010602Consolidation;
using Evaluation.CAL.Request.BL010602Consolidation;
using Evaluation.CAL.Response.BL010602Consolidation;
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
    public class PolicyBL010602Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL010602Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PolicyBL010602NewRec([FromBody] PolicyBL010602NewRecReq policyBL010602NewRecReq)
        {
            PolicyBL010602Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL010602Dto>() { },
                SalesTransactionBL010602 = new SalesTransactionBL010602Dto()
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
                },
                paymentScheduleBL010602 = new List<PaymentScheduleBL010602Dto>(),
                policyRelatedDoc010602 = new List<PolicyRelatedDocBL010602Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL010602NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL010602NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL010602NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL010602NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL010602NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL010602NewRecReq.WebRequestCommon.CorrelationId, policyBL010602NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL010602NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL010602NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL010602NewRec
                    (policyBL010602NewRecReq.SalesTransactionId,
                    policyBL010602NewRecReq.ProductId,
                    policyBL010602NewRecReq.Combination, policyBL010602NewRecReq.BusinessLineCode,
                    policyBL010602NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL010602 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL010602FindAF1WithRecIdFilter(policyBL010602NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL010602 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL010602(policyBL010602NewRecReq.SalesTransactionId, policyBL010602NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc010602 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL010602(policyBL010602NewRecReq.SalesTransactionId, policyBL010602NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL010602NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL010602Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL010602NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL010602NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL010602Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL010602UpdRec([FromBody] PolicyRelatedDocBL010602UpdRecReq policyRelatedDocBL010602UpdRecReq)
        {
            PolicyRelatedDocBL010602Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL010602Dto = new PolicyRelatedDocBL010602Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL010602UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL010602UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL010602UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL010602UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL010602UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL010602UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL010602UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL010602UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL010602UpdRecReq));
                resp.PolicyRelatedDocBL010602Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL010602UpdRec
                    (policyRelatedDocBL010602UpdRecReq.RecId,
                    policyRelatedDocBL010602UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL010602UpdRecReq.AttachDocName,
                      policyRelatedDocBL010602UpdRecReq.AttachDocExt,
                    policyRelatedDocBL010602UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL010602Dto.Reserved1 != null ? resp.PolicyRelatedDocBL010602Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL010602Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL010602UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL010602Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL010602Dto = new PolicyRelatedDocBL010602Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL010602UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL010602UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL010602Dto = new PolicyRelatedDocBL010602Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL010602NewRec([FromBody] PolicyRelatedDocBL010602NewRecReq policyRelatedDocBL010602NewRecReq)
        {
            PolicyRelatedDocBL010602Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL010602Dto = new PolicyRelatedDocBL010602Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL010602NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL010602NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL010602NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL010602NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL010602NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL010602NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL010602NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL010602NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL010602NewRecReq));
                resp.PolicyRelatedDocBL010602Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL010602NewRec(
                    policyRelatedDocBL010602NewRecReq.SalesTransactionId,
                    policyRelatedDocBL010602NewRecReq.TicketId,
                    policyRelatedDocBL010602NewRecReq.ParentPolicyId,
                    policyRelatedDocBL010602NewRecReq.PolicyId,
                    policyRelatedDocBL010602NewRecReq.BusinessLineCode,
                    policyRelatedDocBL010602NewRecReq.DocumentType,
                    policyRelatedDocBL010602NewRecReq.AttachDocBinary,
                    policyRelatedDocBL010602NewRecReq.AttachDocName,
                    policyRelatedDocBL010602NewRecReq.AttachDocExt,
                    policyRelatedDocBL010602NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL010602Dto.Reserved1 != null ? resp.PolicyRelatedDocBL010602Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL010602Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL010602NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL010602Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL010602Dto = new PolicyRelatedDocBL010602Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL010602NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL010602NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL010602Dto = new PolicyRelatedDocBL010602Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL010602UpdRec([FromBody] PolicyBL010602UpdRecReq policyBL010602UpdRecReq)
        {
            PolicyBL010602UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL010602 = new List<PolicyBL010602Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL010602UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL010602UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL010602UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL010602UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL010602UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL010602UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL010602UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL010602UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL010602UpdRecReq));
                resp.PolicyBL010602 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL010602UpdRec
                    (policyBL010602UpdRecReq.SalesTransactionId,
                    policyBL010602UpdRecReq.TicketId,
                     policyBL010602UpdRecReq.ParentPolicyId,
                      policyBL010602UpdRecReq.PolicyId,
                       policyBL010602UpdRecReq.BusinessLineCode,
                        policyBL010602UpdRecReq.GrossPremiumGP,
                        policyBL010602UpdRecReq.CommisionFromGPPer,
                        policyBL010602UpdRecReq.CommisionFromGPAmount,
                        policyBL010602UpdRecReq.VATOnCommisionPer,
                        policyBL010602UpdRecReq.VATOnCommisionAmount,
                        policyBL010602UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL010602UpdRecReq.BuiltInPropTaxesPer,
                        policyBL010602UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL010602UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL010602UpdRecReq.InsurerLoadingPer,
                        policyBL010602UpdRecReq.InsurerLoadingAmount,
                        policyBL010602UpdRecReq.NetPremiumAmount,
                        policyBL010602UpdRecReq.WebRequestCommon.UserName,
                policyBL010602UpdRecReq.PolicyNumber,
                        policyBL010602UpdRecReq.PolicyEffectiveDate,
                policyBL010602UpdRecReq.PolicyExpiryDate,
                        policyBL010602UpdRecReq.PolicyIssuedDate,
                        policyBL010602UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL010602[0].Reserved1 != null ?
                        resp.PolicyBL010602[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL010602[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL010602UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL010602[0].Reserved1 != null)
                        resp.PolicyBL010602 = new List<PolicyBL010602Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL010602UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL010602UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL010602 = new List<PolicyBL010602Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL010602FindAllWithParentPolicyId([FromBody] PolicyBL010602FindParentPolicyIdRecReq policyBL010602FindParentPolicyIdRecReq)
        {
            PolicyBL010602Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL010602Dto>() { },
                SalesTransactionBL010602 = new SalesTransactionBL010602Dto()
                {
                    RecId = -1,
                    AF1BL010602 = new AF1BL010602Dtco()
                },
                paymentScheduleBL010602 = new List<PaymentScheduleBL010602Dto>(),
                policyRelatedDoc010602 = new List<PolicyRelatedDocBL010602Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL010602FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL010602FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL010602FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL010602FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL010602FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL010602FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL010602FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL010602FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL010602FindAllWithParentPolicyId(policyBL010602FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL010602 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL010602FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL010602 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL010602(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc010602 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL010602(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL010602FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL010602Dto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBL010602FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL010602Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
