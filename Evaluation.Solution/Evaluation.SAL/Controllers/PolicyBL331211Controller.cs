using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL331211;
using Evaluation.CAL.DTO.BL331211Consolidation;
using Evaluation.CAL.Request.BL331211Consolidation;
using Evaluation.CAL.Response.BL331211Consolidation;
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
    public class PolicyBL331211Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL331211Controller(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PolicyBL331211NewRec([FromBody] PolicyBL331211NewRecReq policyBL331211NewRecReq)
        {
            PolicyBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL331211Dto>() { },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
                },
                paymentScheduleBL331211 = new List<PaymentScheduleBL331211Dto>(),
                policyRelatedDoc331211 = new List<PolicyRelatedDocBL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL331211NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL331211NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL331211NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL331211NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL331211NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL331211NewRecReq.WebRequestCommon.CorrelationId, policyBL331211NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL331211NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL331211NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL331211NewRec
                    (policyBL331211NewRecReq.SalesTransactionId,
                    policyBL331211NewRecReq.InsurerCode,
                    policyBL331211NewRecReq.ThirdPartyAdminCode, policyBL331211NewRecReq.BusinessLineCode,
                    policyBL331211NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL331211FindAF1WithRecIdFilter(policyBL331211NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL331211 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL331211(policyBL331211NewRecReq.SalesTransactionId, policyBL331211NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc331211 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL331211(policyBL331211NewRecReq.SalesTransactionId, policyBL331211NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL331211NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL331211Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL331211NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL331211NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL331211Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL331211UpdRec([FromBody] PolicyRelatedDocBL331211UpdRecReq policyRelatedDocBL331211UpdRecReq)
        {
            PolicyRelatedDocBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL331211Dto = new PolicyRelatedDocBL331211Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL331211UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL331211UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL331211UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL331211UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL331211UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL331211UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL331211UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL331211UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL331211UpdRecReq));
                resp.PolicyRelatedDocBL331211Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL331211UpdRec
                    (policyRelatedDocBL331211UpdRecReq.RecId,
                    policyRelatedDocBL331211UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL331211UpdRecReq.AttachDocName,
                      policyRelatedDocBL331211UpdRecReq.AttachDocExt,
                    policyRelatedDocBL331211UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL331211Dto.Reserved1 != null ? resp.PolicyRelatedDocBL331211Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL331211Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL331211UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL331211Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL331211Dto = new PolicyRelatedDocBL331211Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL331211UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL331211UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL331211Dto = new PolicyRelatedDocBL331211Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL331211NewRec([FromBody] PolicyRelatedDocBL331211NewRecReq policyRelatedDocBL331211NewRecReq)
        {
            PolicyRelatedDocBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL331211Dto = new PolicyRelatedDocBL331211Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL331211NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL331211NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL331211NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL331211NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL331211NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL331211NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL331211NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL331211NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL331211NewRecReq));
                resp.PolicyRelatedDocBL331211Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL331211NewRec(
                    policyRelatedDocBL331211NewRecReq.SalesTransactionId,
                    policyRelatedDocBL331211NewRecReq.TicketId,
                    policyRelatedDocBL331211NewRecReq.ParentPolicyId,
                    policyRelatedDocBL331211NewRecReq.PolicyId,
                    policyRelatedDocBL331211NewRecReq.BusinessLineCode,
                    policyRelatedDocBL331211NewRecReq.DocumentType,
                    policyRelatedDocBL331211NewRecReq.AttachDocBinary,
                    policyRelatedDocBL331211NewRecReq.AttachDocName,
                    policyRelatedDocBL331211NewRecReq.AttachDocExt,
                    policyRelatedDocBL331211NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL331211Dto.Reserved1 != null ? resp.PolicyRelatedDocBL331211Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL331211Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL331211NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL331211Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL331211Dto = new PolicyRelatedDocBL331211Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL331211NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL331211NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL331211Dto = new PolicyRelatedDocBL331211Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL331211UpdRec([FromBody] PolicyBL331211UpdRecReq policyBL331211UpdRecReq)
        {
            PolicyBL331211UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL331211 = new List<PolicyBL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL331211UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL331211UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL331211UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL331211UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL331211UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL331211UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL331211UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL331211UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL331211UpdRecReq));
                resp.PolicyBL331211 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL331211UpdRec
                    (policyBL331211UpdRecReq.SalesTransactionId,
                    policyBL331211UpdRecReq.TicketId,
                     policyBL331211UpdRecReq.ParentPolicyId,
                      policyBL331211UpdRecReq.PolicyId,
                       policyBL331211UpdRecReq.BusinessLineCode,
                        policyBL331211UpdRecReq.GrossPremiumGP,
                        policyBL331211UpdRecReq.CommisionFromGPPer,
                        policyBL331211UpdRecReq.CommisionFromGPAmount,
                        policyBL331211UpdRecReq.VATOnCommisionPer,
                        policyBL331211UpdRecReq.VATOnCommisionAmount,
                        policyBL331211UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL331211UpdRecReq.BuiltInPropTaxesPer,
                        policyBL331211UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL331211UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL331211UpdRecReq.InsurerLoadingPer,
                        policyBL331211UpdRecReq.InsurerLoadingAmount,
                        policyBL331211UpdRecReq.NetPremiumAmount,
                        policyBL331211UpdRecReq.WebRequestCommon.UserName,
                policyBL331211UpdRecReq.PolicyNumber,
                        policyBL331211UpdRecReq.PolicyEffectiveDate,
                policyBL331211UpdRecReq.PolicyExpiryDate,
                policyBL331211UpdRecReq.PolicyIssuedDate,
                policyBL331211UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL331211[0].Reserved1 != null ?
                        resp.PolicyBL331211[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL331211[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL331211UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL331211[0].Reserved1 != null)
                        resp.PolicyBL331211 = new List<PolicyBL331211Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL331211UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL331211UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL331211 = new List<PolicyBL331211Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL331211FindAllWithParentPolicyId([FromBody] PolicyBL331211FindParentPolicyIdRecReq policyBL331211FindParentPolicyIdRecReq)
        {
            PolicyBL331211Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL331211Dto>() { },
                SalesTransactionBL331211 = new SalesTransactionBL331211Dto()
                {
                    RecId = -1,
                    AF1BL331211 = new List<AF1BL331211Dto>()
                },
                paymentScheduleBL331211 = new List<PaymentScheduleBL331211Dto>(),
                policyRelatedDoc331211 = new List<PolicyRelatedDocBL331211Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL331211FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL331211FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL331211FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL331211FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL331211FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL331211FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL331211FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL331211FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL331211FindAllWithParentPolicyId(policyBL331211FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL331211 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL331211FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL331211 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL331211(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc331211 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL331211(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL331211FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL331211Dto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBL331211FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL331211Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
