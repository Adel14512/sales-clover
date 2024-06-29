using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL021502;
using Evaluation.CAL.DTO.BL021502Consolidation;
using Evaluation.CAL.Request.BL021502Consolidation;
using Evaluation.CAL.Response.BL021502Consolidation;
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
    public class PolicyBL021502Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL021502Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PolicyBL021502NewRec([FromBody] PolicyBL021502NewRecReq policyBL021502NewRecReq)
        {
            PolicyBL021502Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL021502Dto>() { },
                SalesTransactionBL021502 = new SalesTransactionBL021502Dto()
                {
                    RecId = -1,
                    AF1BL021502 = new List<AF1BL021502Dto>()
                },
                paymentScheduleBL021502 = new List<PaymentScheduleBL021502Dto>(),
                policyRelatedDoc021502 = new List<PolicyRelatedDocBL021502Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL021502NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL021502NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL021502NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL021502NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL021502NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL021502NewRecReq.WebRequestCommon.CorrelationId, policyBL021502NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL021502NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL021502NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL021502NewRec
                    (policyBL021502NewRecReq.SalesTransactionId,
                    policyBL021502NewRecReq.ProductId,
                    policyBL021502NewRecReq.Combination, policyBL021502NewRecReq.BusinessLineCode,
                    policyBL021502NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL021502 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL021502FindAF1WithRecIdFilter(policyBL021502NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL021502 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL021502(policyBL021502NewRecReq.SalesTransactionId, policyBL021502NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc021502 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL021502(policyBL021502NewRecReq.SalesTransactionId, policyBL021502NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL021502NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL021502Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL021502NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL021502NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL021502Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL021502UpdRec([FromBody] PolicyRelatedDocBL021502UpdRecReq policyRelatedDocBL021502UpdRecReq)
        {
            PolicyRelatedDocBL021502Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL021502Dto = new PolicyRelatedDocBL021502Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL021502UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL021502UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL021502UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL021502UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL021502UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL021502UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL021502UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL021502UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL021502UpdRecReq));
                resp.PolicyRelatedDocBL021502Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL021502UpdRec
                    (policyRelatedDocBL021502UpdRecReq.RecId,
                    policyRelatedDocBL021502UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL021502UpdRecReq.AttachDocName,
                      policyRelatedDocBL021502UpdRecReq.AttachDocExt,
                    policyRelatedDocBL021502UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL021502Dto.Reserved1 != null ? resp.PolicyRelatedDocBL021502Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL021502Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL021502UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL021502Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL021502Dto = new PolicyRelatedDocBL021502Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL021502UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL021502UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL021502Dto = new PolicyRelatedDocBL021502Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL021502NewRec([FromBody] PolicyRelatedDocBL021502NewRecReq policyRelatedDocBL021502NewRecReq)
        {
            PolicyRelatedDocBL021502Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL021502Dto = new PolicyRelatedDocBL021502Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL021502NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL021502NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL021502NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL021502NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL021502NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL021502NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL021502NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL021502NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL021502NewRecReq));
                resp.PolicyRelatedDocBL021502Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL021502NewRec(
                    policyRelatedDocBL021502NewRecReq.SalesTransactionId,
                    policyRelatedDocBL021502NewRecReq.TicketId,
                    policyRelatedDocBL021502NewRecReq.ParentPolicyId,
                    policyRelatedDocBL021502NewRecReq.PolicyId,
                    policyRelatedDocBL021502NewRecReq.BusinessLineCode,
                    policyRelatedDocBL021502NewRecReq.DocumentType,
                    policyRelatedDocBL021502NewRecReq.AttachDocBinary,
                    policyRelatedDocBL021502NewRecReq.AttachDocName,
                    policyRelatedDocBL021502NewRecReq.AttachDocExt,
                    policyRelatedDocBL021502NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL021502Dto.Reserved1 != null ? resp.PolicyRelatedDocBL021502Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL021502Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL021502NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL021502Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL021502Dto = new PolicyRelatedDocBL021502Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL021502NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL021502NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL021502Dto = new PolicyRelatedDocBL021502Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL021502UpdRec([FromBody] PolicyBL021502UpdRecReq policyBL021502UpdRecReq)
        {
            PolicyBL021502UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL021502 = new List<PolicyBL021502Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL021502UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL021502UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL021502UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL021502UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL021502UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL021502UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL021502UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL021502UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL021502UpdRecReq));
                resp.PolicyBL021502 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL021502UpdRec
                    (policyBL021502UpdRecReq.SalesTransactionId,
                    policyBL021502UpdRecReq.TicketId,
                     policyBL021502UpdRecReq.ParentPolicyId,
                      policyBL021502UpdRecReq.PolicyId,
                       policyBL021502UpdRecReq.BusinessLineCode,
                        policyBL021502UpdRecReq.GrossPremiumGP,
                        policyBL021502UpdRecReq.CommisionFromGPPer,
                        policyBL021502UpdRecReq.CommisionFromGPAmount,
                        policyBL021502UpdRecReq.VATOnCommisionPer,
                        policyBL021502UpdRecReq.VATOnCommisionAmount,
                        policyBL021502UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL021502UpdRecReq.BuiltInPropTaxesPer,
                        policyBL021502UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL021502UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL021502UpdRecReq.InsurerLoadingPer,
                        policyBL021502UpdRecReq.InsurerLoadingAmount,
                        policyBL021502UpdRecReq.NetPremiumAmount,
                        policyBL021502UpdRecReq.WebRequestCommon.UserName,
                policyBL021502UpdRecReq.PolicyNumber,
                        policyBL021502UpdRecReq.PolicyEffectiveDate,
                policyBL021502UpdRecReq.PolicyExpiryDate,
                        policyBL021502UpdRecReq.PolicyIssuedDate,
                        policyBL021502UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL021502[0].Reserved1 != null ?
                        resp.PolicyBL021502[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL021502[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL021502UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL021502[0].Reserved1 != null)
                        resp.PolicyBL021502 = new List<PolicyBL021502Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL021502UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL021502UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL021502 = new List<PolicyBL021502Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL021502FindAllWithParentPolicyId([FromBody] PolicyBL021502FindParentPolicyIdRecReq policyBL021502FindParentPolicyIdRecReq)
        {
            PolicyBL021502Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL021502Dto>() { },
                SalesTransactionBL021502 = new SalesTransactionBL021502Dto()
                {
                    RecId = -1,
                    AF1BL021502 = new List<AF1BL021502Dto>()
                },
                paymentScheduleBL021502 = new List<PaymentScheduleBL021502Dto>(),
                policyRelatedDoc021502 = new List<PolicyRelatedDocBL021502Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL021502FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL021502FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL021502FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL021502FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL021502FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL021502FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL021502FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL021502FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL021502FindAllWithParentPolicyId(policyBL021502FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL021502 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL021502FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL021502 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL021502(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc021502 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL021502(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL021502FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL021502Dto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBL021502FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL021502Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}