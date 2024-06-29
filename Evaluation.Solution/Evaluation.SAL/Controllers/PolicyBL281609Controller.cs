using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL281609;
using Evaluation.CAL.DTO.BL281609Consolidation;
using Evaluation.CAL.Request.BL281609Consolidation;
using Evaluation.CAL.Response.BL281609Consolidation;
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
    public class PolicyBL281609Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL281609Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PolicyBL281609NewRec([FromBody] PolicyBL281609NewRecReq policyBL281609NewRecReq)
        {
            PolicyBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL281609Dto>() { },
                SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
                },
                paymentScheduleBL281609 = new List<PaymentScheduleBL281609Dto>(),
                policyRelatedDoc281609 = new List<PolicyRelatedDocBL281609Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL281609NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL281609NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL281609NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL281609NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL281609NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL281609NewRecReq.WebRequestCommon.CorrelationId, policyBL281609NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL281609NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL281609NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL281609NewRec
                    (policyBL281609NewRecReq.SalesTransactionId,
                    policyBL281609NewRecReq.ProductId,
                    policyBL281609NewRecReq.Combination, policyBL281609NewRecReq.BusinessLineCode,
                    policyBL281609NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL281609 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL281609FindAF1WithRecIdFilter(policyBL281609NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL281609 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL281609(policyBL281609NewRecReq.SalesTransactionId, policyBL281609NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc281609 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL281609(policyBL281609NewRecReq.SalesTransactionId, policyBL281609NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL281609NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL281609Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL281609NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL281609NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL281609Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL281609UpdRec([FromBody] PolicyRelatedDocBL281609UpdRecReq policyRelatedDocBL281609UpdRecReq)
        {
            PolicyRelatedDocBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL281609Dto = new PolicyRelatedDocBL281609Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL281609UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL281609UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL281609UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL281609UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL281609UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL281609UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL281609UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL281609UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL281609UpdRecReq));
                resp.PolicyRelatedDocBL281609Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL281609UpdRec
                    (policyRelatedDocBL281609UpdRecReq.RecId,
                    policyRelatedDocBL281609UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL281609UpdRecReq.AttachDocName,
                      policyRelatedDocBL281609UpdRecReq.AttachDocExt,
                    policyRelatedDocBL281609UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL281609Dto.Reserved1 != null ? resp.PolicyRelatedDocBL281609Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL281609Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL281609UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL281609Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL281609Dto = new PolicyRelatedDocBL281609Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL281609UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL281609UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL281609Dto = new PolicyRelatedDocBL281609Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL281609NewRec([FromBody] PolicyRelatedDocBL281609NewRecReq policyRelatedDocBL281609NewRecReq)
        {
            PolicyRelatedDocBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL281609Dto = new PolicyRelatedDocBL281609Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL281609NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL281609NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL281609NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL281609NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL281609NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL281609NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL281609NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL281609NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL281609NewRecReq));
                resp.PolicyRelatedDocBL281609Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL281609NewRec(
                    policyRelatedDocBL281609NewRecReq.SalesTransactionId,
                    policyRelatedDocBL281609NewRecReq.TicketId,
                    policyRelatedDocBL281609NewRecReq.ParentPolicyId,
                    policyRelatedDocBL281609NewRecReq.PolicyId,
                    policyRelatedDocBL281609NewRecReq.BusinessLineCode,
                    policyRelatedDocBL281609NewRecReq.DocumentType,
                    policyRelatedDocBL281609NewRecReq.AttachDocBinary,
                    policyRelatedDocBL281609NewRecReq.AttachDocName,
                    policyRelatedDocBL281609NewRecReq.AttachDocExt,
                    policyRelatedDocBL281609NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL281609Dto.Reserved1 != null ? resp.PolicyRelatedDocBL281609Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL281609Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL281609NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL281609Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL281609Dto = new PolicyRelatedDocBL281609Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL281609NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL281609NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL281609Dto = new PolicyRelatedDocBL281609Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL281609UpdRec([FromBody] PolicyBL281609UpdRecReq policyBL281609UpdRecReq)
        {
            PolicyBL281609UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL281609 = new List<PolicyBL281609Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL281609UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL281609UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL281609UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL281609UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL281609UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL281609UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL281609UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL281609UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL281609UpdRecReq));
                resp.PolicyBL281609 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL281609UpdRec
                    (policyBL281609UpdRecReq.SalesTransactionId,
                    policyBL281609UpdRecReq.TicketId,
                     policyBL281609UpdRecReq.ParentPolicyId,
                      policyBL281609UpdRecReq.PolicyId,
                       policyBL281609UpdRecReq.BusinessLineCode,
                        policyBL281609UpdRecReq.GrossPremiumGP,
                        policyBL281609UpdRecReq.CommisionFromGPPer,
                        policyBL281609UpdRecReq.CommisionFromGPAmount,
                        policyBL281609UpdRecReq.VATOnCommisionPer,
                        policyBL281609UpdRecReq.VATOnCommisionAmount,
                        policyBL281609UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL281609UpdRecReq.BuiltInPropTaxesPer,
                        policyBL281609UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL281609UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL281609UpdRecReq.InsurerLoadingPer,
                        policyBL281609UpdRecReq.InsurerLoadingAmount,
                        policyBL281609UpdRecReq.NetPremiumAmount,
                        policyBL281609UpdRecReq.WebRequestCommon.UserName,
                policyBL281609UpdRecReq.PolicyNumber,
                        policyBL281609UpdRecReq.PolicyEffectiveDate,
                policyBL281609UpdRecReq.PolicyExpiryDate,
                        policyBL281609UpdRecReq.PolicyIssuedDate,
                        policyBL281609UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL281609[0].Reserved1 != null ?
                        resp.PolicyBL281609[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL281609[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL281609UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL281609[0].Reserved1 != null)
                        resp.PolicyBL281609 = new List<PolicyBL281609Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL281609UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL281609UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL281609 = new List<PolicyBL281609Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL281609FindAllWithParentPolicyId([FromBody] PolicyBL281609FindParentPolicyIdRecReq policyBL281609FindParentPolicyIdRecReq)
        {
            PolicyBL281609Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL281609Dto>() { },
                SalesTransactionBL281609 = new SalesTransactionBL281609Dto()
                {
                    RecId = -1,
                    AF1BL281609 = new List<AF1BL281609Dto>()
                },
                paymentScheduleBL281609 = new List<PaymentScheduleBL281609Dto>(),
                policyRelatedDoc281609 = new List<PolicyRelatedDocBL281609Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL281609FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL281609FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL281609FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL281609FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL281609FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL281609FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL281609FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL281609FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL281609FindAllWithParentPolicyId(policyBL281609FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL281609 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL281609FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL281609 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL281609(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc281609 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL281609(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL281609FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL281609Dto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBL281609FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL281609Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}