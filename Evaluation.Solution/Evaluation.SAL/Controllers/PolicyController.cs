using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL080501;
using Evaluation.CAL.DTO.Consolidation;
using Evaluation.CAL.Request.Consolidation;
using Evaluation.CAL.Response.Consolidation;
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
    public class PolicyController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PolicyNewRec([FromBody] PolicyNewRecReq policyNewRecReq)
        {
            PolicyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyDto>() { },
                SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
                },
                paymentSchedule = new List<PaymentScheduleDto>(),
                policyRelatedDoc = new List<PolicyRelatedDocDto>()
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
                    resp.WebResponseCommon.CorrelationId = policyNewRecReq == null ? Guid.NewGuid().ToString() :
                        policyNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyNewRecReq.WebRequestCommon.CorrelationId, policyNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyNewRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyNewRec(policyNewRecReq.SalesTransactionId, policyNewRecReq.ProductId,
                    policyNewRecReq.Combination, policyNewRecReq.BusinessLineCode, policyNewRecReq.WebRequestCommon.UserName);
                resp.SalesTransactionBL080501 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL080501FindAF1WithRecIdFilter(policyNewRecReq.SalesTransactionId);
                resp.paymentSchedule = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentSchedule(policyNewRecReq.SalesTransactionId, policyNewRecReq.BusinessLineCode);
                resp.policyRelatedDoc = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDoc(policyNewRecReq.SalesTransactionId, policyNewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyDto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyNewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyDto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocUpdRec([FromBody] PolicyRelatedDocUpdRecReq policyRelatedDocUpdRecReq)
        {
            PolicyRelatedDocResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDoc = new PolicyRelatedDocDto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocUpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocUpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocUpdRecReq));
                resp.PolicyRelatedDoc = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocUpdRec
                    (policyRelatedDocUpdRecReq.RecId,
                    policyRelatedDocUpdRecReq.AttachDocBinary,
                     policyRelatedDocUpdRecReq.AttachDocName,
                      policyRelatedDocUpdRecReq.AttachDocExt,
                    policyRelatedDocUpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDoc.Reserved1 != null ? resp.PolicyRelatedDoc.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDoc.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDoc.Reserved1 != null)
                        resp.PolicyRelatedDoc = new PolicyRelatedDocDto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocUpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocUpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDoc = new PolicyRelatedDocDto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocNewRec([FromBody] PolicyRelatedDocNewRecReq policyRelatedDocNewRecReq)
        {
            PolicyRelatedDocResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDoc = new PolicyRelatedDocDto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocNewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocNewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocNewRecReq));
                resp.PolicyRelatedDoc = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocNewRec(
                    policyRelatedDocNewRecReq.SalesTransactionId,
                    policyRelatedDocNewRecReq.TicketId,
                    policyRelatedDocNewRecReq.ParentPolicyId,
                      policyRelatedDocNewRecReq.PolicyId,
                    policyRelatedDocNewRecReq.BusinessLineCode,
                    policyRelatedDocNewRecReq.DocumentType,
                    policyRelatedDocNewRecReq.AttachDocBinary,
                    policyRelatedDocNewRecReq.AttachDocName,
                    policyRelatedDocNewRecReq.AttachDocExt,
                    policyRelatedDocNewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDoc.Reserved1 != null ? resp.PolicyRelatedDoc.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDoc.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDoc.Reserved1 != null)
                        resp.PolicyRelatedDoc = new PolicyRelatedDocDto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocNewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocNewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDoc = new PolicyRelatedDocDto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyUpdRec([FromBody] PolicyUpdRecReq policyUpdRecReq)
        {
            PolicyUpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyDto>()
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
                    resp.WebResponseCommon.CorrelationId = policyUpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyUpdRecReq.WebRequestCommon.CorrelationId,
                    policyUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyUpdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyUpdRec
                    (policyUpdRecReq.SalesTransactionId,
                    policyUpdRecReq.TicketId,
                     policyUpdRecReq.ParentPolicyId,
                      policyUpdRecReq.PolicyId,
                       policyUpdRecReq.BusinessLineCode,
                        policyUpdRecReq.GrossPremiumGP,
                        policyUpdRecReq.CommisionFromGPPer,
                        policyUpdRecReq.CommisionFromGPAmount,
                        policyUpdRecReq.VATOnCommisionPer,
                        policyUpdRecReq.VATOnCommisionAmount,
                        policyUpdRecReq.BuiltInFixedTaxesAmount,
                        policyUpdRecReq.BuiltInPropTaxesPer,
                        policyUpdRecReq.BuiltInPropTaxesAmount,
                        policyUpdRecReq.BuiltInCostOfPolicyAmount,
                        policyUpdRecReq.InsurerLoadingPer,
                        policyUpdRecReq.InsurerLoadingAmount,
                        policyUpdRecReq.NetPremiumAmount,
                        policyUpdRecReq.WebRequestCommon.UserName,
                        policyUpdRecReq.PolicyNumber,
                        policyUpdRecReq.PolicyEffectiveDate,
                        policyUpdRecReq.PolicyExpiryDate,
                        policyUpdRecReq.PolicyIssuedDate,
                        policyUpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ?
                        resp.Policy[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyDto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocNewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyUpdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyFindAllWithParentPolicyId([FromBody] PolicyBl080501FindParentPolicyIdRecReq policyBl080501FindParentPolicyIdRecReq)
        {
            PolicyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyDto>() { },
                SalesTransactionBL080501 = new SalesTransactionBL080501Dto()
                {
                    RecId = -1,
                    AF1BL080501 = new AF1BL080501Dtco()
                },
                paymentSchedule = new List<PaymentScheduleDto>(),
                policyRelatedDoc = new List<PolicyRelatedDocDto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBl080501FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBl080501FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBl080501FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyFindAllWithParentPolicyId(policyBl080501FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL080501 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL080501FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentSchedule = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentSchedule(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDoc(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyDto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyDto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
