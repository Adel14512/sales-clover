using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL051807;
using Evaluation.CAL.DTO.BL051807Consolidation;
using Evaluation.CAL.Request.BL051807Consolidation;
using Evaluation.CAL.Response.BL051807Consolidation;
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
    public class PolicyBL051807Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL051807Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PolicyBL051807NewRec([FromBody] PolicyBL051807NewRecReq policyBL051807NewRecReq)
        {
            PolicyBL051807Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL051807Dto>() { },
                SalesTransactionBL051807 = new SalesTransactionBL051807Dto()
                {
                    RecId = -1,
                    AF1BL051807 = new List<AF1BL051807Dto>()
                },
                paymentScheduleBL051807 = new List<PaymentScheduleBL051807Dto>(),
                policyRelatedDoc051807 = new List<PolicyRelatedDocBL051807Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL051807NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL051807NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL051807NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL051807NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL051807NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL051807NewRecReq.WebRequestCommon.CorrelationId, policyBL051807NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL051807NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL051807NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL051807NewRec
                    (policyBL051807NewRecReq.SalesTransactionId,
                    policyBL051807NewRecReq.ProductId,
                    policyBL051807NewRecReq.Combination, policyBL051807NewRecReq.BusinessLineCode,
                    policyBL051807NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL051807 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL051807FindAF1WithRecIdFilter(policyBL051807NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL051807 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL051807(policyBL051807NewRecReq.SalesTransactionId, policyBL051807NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc051807 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL051807(policyBL051807NewRecReq.SalesTransactionId, policyBL051807NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL051807NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL051807Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL051807NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL051807NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL051807Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL051807UpdRec([FromBody] PolicyRelatedDocBL051807UpdRecReq policyRelatedDocBL051807UpdRecReq)
        {
            PolicyRelatedDocBL051807Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL051807Dto = new PolicyRelatedDocBL051807Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL051807UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL051807UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL051807UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL051807UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL051807UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL051807UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL051807UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL051807UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL051807UpdRecReq));
                resp.PolicyRelatedDocBL051807Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL051807UpdRec
                    (policyRelatedDocBL051807UpdRecReq.RecId,
                    policyRelatedDocBL051807UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL051807UpdRecReq.AttachDocName,
                      policyRelatedDocBL051807UpdRecReq.AttachDocExt,
                    policyRelatedDocBL051807UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL051807Dto.Reserved1 != null ? resp.PolicyRelatedDocBL051807Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL051807Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL051807UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL051807Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL051807Dto = new PolicyRelatedDocBL051807Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL051807UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL051807UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL051807Dto = new PolicyRelatedDocBL051807Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL051807NewRec([FromBody] PolicyRelatedDocBL051807NewRecReq policyRelatedDocBL051807NewRecReq)
        {
            PolicyRelatedDocBL051807Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL051807Dto = new PolicyRelatedDocBL051807Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL051807NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL051807NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL051807NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL051807NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL051807NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL051807NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL051807NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL051807NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL051807NewRecReq));
                resp.PolicyRelatedDocBL051807Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL051807NewRec(
                    policyRelatedDocBL051807NewRecReq.SalesTransactionId,
                    policyRelatedDocBL051807NewRecReq.TicketId,
                    policyRelatedDocBL051807NewRecReq.ParentPolicyId,
                    policyRelatedDocBL051807NewRecReq.PolicyId,
                    policyRelatedDocBL051807NewRecReq.BusinessLineCode,
                    policyRelatedDocBL051807NewRecReq.DocumentType,
                    policyRelatedDocBL051807NewRecReq.AttachDocBinary,
                    policyRelatedDocBL051807NewRecReq.AttachDocName,
                    policyRelatedDocBL051807NewRecReq.AttachDocExt,
                    policyRelatedDocBL051807NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL051807Dto.Reserved1 != null ? resp.PolicyRelatedDocBL051807Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL051807Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL051807NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL051807Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL051807Dto = new PolicyRelatedDocBL051807Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL051807NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL051807NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL051807Dto = new PolicyRelatedDocBL051807Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL051807UpdRec([FromBody] PolicyBL051807UpdRecReq policyBL051807UpdRecReq)
        {
            PolicyBL051807UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL051807 = new List<PolicyBL051807Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL051807UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL051807UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL051807UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL051807UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL051807UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL051807UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL051807UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL051807UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL051807UpdRecReq));
                resp.PolicyBL051807 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL051807UpdRec
                    (policyBL051807UpdRecReq.SalesTransactionId,
                    policyBL051807UpdRecReq.TicketId,
                     policyBL051807UpdRecReq.ParentPolicyId,
                      policyBL051807UpdRecReq.PolicyId,
                       policyBL051807UpdRecReq.BusinessLineCode,
                        policyBL051807UpdRecReq.GrossPremiumGP,
                        policyBL051807UpdRecReq.CommisionFromGPPer,
                        policyBL051807UpdRecReq.CommisionFromGPAmount,
                        policyBL051807UpdRecReq.VATOnCommisionPer,
                        policyBL051807UpdRecReq.VATOnCommisionAmount,
                        policyBL051807UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL051807UpdRecReq.BuiltInPropTaxesPer,
                        policyBL051807UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL051807UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL051807UpdRecReq.InsurerLoadingPer,
                        policyBL051807UpdRecReq.InsurerLoadingAmount,
                        policyBL051807UpdRecReq.NetPremiumAmount,
                        policyBL051807UpdRecReq.WebRequestCommon.UserName,
                policyBL051807UpdRecReq.PolicyNumber,
                        policyBL051807UpdRecReq.PolicyEffectiveDate,
                policyBL051807UpdRecReq.PolicyExpiryDate,
                        policyBL051807UpdRecReq.PolicyIssuedDate,
                        policyBL051807UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL051807[0].Reserved1 != null ?
                        resp.PolicyBL051807[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL051807[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL051807UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL051807[0].Reserved1 != null)
                        resp.PolicyBL051807 = new List<PolicyBL051807Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL051807UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL051807UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL051807 = new List<PolicyBL051807Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL051807FindAllWithParentPolicyId([FromBody] PolicyBL051807FindParentPolicyIdRecReq policyBL051807FindParentPolicyIdRecReq)
        {
            PolicyBL051807Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL051807Dto>() { },
                SalesTransactionBL051807 = new SalesTransactionBL051807Dto()
                {
                    RecId = -1,
                    AF1BL051807 = new List<AF1BL051807Dto>()
                },
                paymentScheduleBL051807 = new List<PaymentScheduleBL051807Dto>(),
                policyRelatedDoc051807 = new List<PolicyRelatedDocBL051807Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL051807FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL051807FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL051807FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL051807FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL051807FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL051807FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL051807FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL051807FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL051807FindAllWithParentPolicyId(policyBL051807FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL051807 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL051807FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL051807 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL051807(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc051807 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL051807(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL051807FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL051807Dto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBL051807FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL051807Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}