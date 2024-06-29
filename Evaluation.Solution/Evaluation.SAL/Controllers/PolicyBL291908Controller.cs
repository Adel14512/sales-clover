using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL291908;
using Evaluation.CAL.DTO.BL291908Consolidation;
using Evaluation.CAL.Request.BL291908Consolidation;
using Evaluation.CAL.Response.BL291908Consolidation;
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
    public class PolicyBL291908Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL291908Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PolicyBL291908NewRec([FromBody] PolicyBL291908NewRecReq policyBL291908NewRecReq)
        {
            PolicyBL291908Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL291908Dto>() { },
                SalesTransactionBL291908 = new SalesTransactionBL291908Dto()
                {
                    RecId = -1,
                    AF1BL291908 = new List<AF1BL291908Dto>()
                },
                paymentScheduleBL291908 = new List<PaymentScheduleBL291908Dto>(),
                policyRelatedDoc291908 = new List<PolicyRelatedDocBL291908Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL291908NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL291908NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL291908NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL291908NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL291908NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL291908NewRecReq.WebRequestCommon.CorrelationId, policyBL291908NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL291908NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL291908NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL291908NewRec
                    (policyBL291908NewRecReq.SalesTransactionId,
                    policyBL291908NewRecReq.ProductId,
                    policyBL291908NewRecReq.Combination, policyBL291908NewRecReq.BusinessLineCode,
                    policyBL291908NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL291908 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL291908FindAF1WithRecIdFilter(policyBL291908NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL291908 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL291908(policyBL291908NewRecReq.SalesTransactionId, policyBL291908NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc291908 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL291908(policyBL291908NewRecReq.SalesTransactionId, policyBL291908NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL291908NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL291908Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL291908NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL291908NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL291908Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL291908UpdRec([FromBody] PolicyRelatedDocBL291908UpdRecReq policyRelatedDocBL291908UpdRecReq)
        {
            PolicyRelatedDocBL291908Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL291908Dto = new PolicyRelatedDocBL291908Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL291908UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL291908UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL291908UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL291908UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL291908UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL291908UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL291908UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL291908UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL291908UpdRecReq));
                resp.PolicyRelatedDocBL291908Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL291908UpdRec
                    (policyRelatedDocBL291908UpdRecReq.RecId,
                    policyRelatedDocBL291908UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL291908UpdRecReq.AttachDocName,
                      policyRelatedDocBL291908UpdRecReq.AttachDocExt,
                    policyRelatedDocBL291908UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL291908Dto.Reserved1 != null ? resp.PolicyRelatedDocBL291908Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL291908Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL291908UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL291908Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL291908Dto = new PolicyRelatedDocBL291908Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL291908UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL291908UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL291908Dto = new PolicyRelatedDocBL291908Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL291908NewRec([FromBody] PolicyRelatedDocBL291908NewRecReq policyRelatedDocBL291908NewRecReq)
        {
            PolicyRelatedDocBL291908Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL291908Dto = new PolicyRelatedDocBL291908Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL291908NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL291908NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL291908NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL291908NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL291908NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL291908NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL291908NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL291908NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL291908NewRecReq));
                resp.PolicyRelatedDocBL291908Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL291908NewRec(
                    policyRelatedDocBL291908NewRecReq.SalesTransactionId,
                    policyRelatedDocBL291908NewRecReq.TicketId,
                    policyRelatedDocBL291908NewRecReq.ParentPolicyId,
                    policyRelatedDocBL291908NewRecReq.PolicyId,
                    policyRelatedDocBL291908NewRecReq.BusinessLineCode,
                    policyRelatedDocBL291908NewRecReq.DocumentType,
                    policyRelatedDocBL291908NewRecReq.AttachDocBinary,
                    policyRelatedDocBL291908NewRecReq.AttachDocName,
                    policyRelatedDocBL291908NewRecReq.AttachDocExt,
                    policyRelatedDocBL291908NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL291908Dto.Reserved1 != null ? resp.PolicyRelatedDocBL291908Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL291908Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL291908NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL291908Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL291908Dto = new PolicyRelatedDocBL291908Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL291908NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL291908NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL291908Dto = new PolicyRelatedDocBL291908Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL291908UpdRec([FromBody] PolicyBL291908UpdRecReq policyBL291908UpdRecReq)
        {
            PolicyBL291908UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL291908 = new List<PolicyBL291908Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL291908UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL291908UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL291908UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL291908UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL291908UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL291908UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL291908UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL291908UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL291908UpdRecReq));
                resp.PolicyBL291908 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL291908UpdRec
                    (policyBL291908UpdRecReq.SalesTransactionId,
                    policyBL291908UpdRecReq.TicketId,
                     policyBL291908UpdRecReq.ParentPolicyId,
                      policyBL291908UpdRecReq.PolicyId,
                       policyBL291908UpdRecReq.BusinessLineCode,
                        policyBL291908UpdRecReq.GrossPremiumGP,
                        policyBL291908UpdRecReq.CommisionFromGPPer,
                        policyBL291908UpdRecReq.CommisionFromGPAmount,
                        policyBL291908UpdRecReq.VATOnCommisionPer,
                        policyBL291908UpdRecReq.VATOnCommisionAmount,
                        policyBL291908UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL291908UpdRecReq.BuiltInPropTaxesPer,
                        policyBL291908UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL291908UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL291908UpdRecReq.InsurerLoadingPer,
                        policyBL291908UpdRecReq.InsurerLoadingAmount,
                        policyBL291908UpdRecReq.NetPremiumAmount,
                        policyBL291908UpdRecReq.WebRequestCommon.UserName,
                policyBL291908UpdRecReq.PolicyNumber,
                        policyBL291908UpdRecReq.PolicyEffectiveDate,
                policyBL291908UpdRecReq.PolicyExpiryDate,
                        policyBL291908UpdRecReq.PolicyIssuedDate,
                        policyBL291908UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL291908[0].Reserved1 != null ?
                        resp.PolicyBL291908[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL291908[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL291908UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL291908[0].Reserved1 != null)
                        resp.PolicyBL291908 = new List<PolicyBL291908Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL291908UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL291908UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL291908 = new List<PolicyBL291908Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL291908FindAllWithParentPolicyId([FromBody] PolicyBL291908FindParentPolicyIdRecReq policyBL291908FindParentPolicyIdRecReq)
        {
            PolicyBL291908Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL291908Dto>() { },
                SalesTransactionBL291908 = new SalesTransactionBL291908Dto()
                {
                    RecId = -1,
                    AF1BL291908 = new List<AF1BL291908Dto>()
                },
                paymentScheduleBL291908 = new List<PaymentScheduleBL291908Dto>(),
                policyRelatedDoc291908 = new List<PolicyRelatedDocBL291908Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL291908FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL291908FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL291908FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL291908FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL291908FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL291908FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL291908FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL291908FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL291908FindAllWithParentPolicyId(policyBL291908FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL291908 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL291908FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL291908 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL291908(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc291908 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL291908(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL291908FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL291908Dto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBL291908FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL291908Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}