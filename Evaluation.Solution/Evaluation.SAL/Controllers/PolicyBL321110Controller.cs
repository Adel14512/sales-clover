using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL321110;
using Evaluation.CAL.DTO.BL321110Consolidation;
using Evaluation.CAL.Request.BL321110Consolidation;
using Evaluation.CAL.Response.BL321110Consolidation;
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
    public class PolicyBL321110Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL321110Controller(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PolicyBL321110NewRec([FromBody] PolicyBL321110NewRecReq policyBL321110NewRecReq)
        {
            PolicyBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL321110Dto>() { },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
                },
                paymentScheduleBL321110 = new List<PaymentScheduleBL321110Dto>(),
                policyRelatedDoc321110 = new List<PolicyRelatedDocBL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL321110NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL321110NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL321110NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL321110NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL321110NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL321110NewRecReq.WebRequestCommon.CorrelationId, policyBL321110NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL321110NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL321110NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL321110NewRec
                    (policyBL321110NewRecReq.SalesTransactionId,
                    policyBL321110NewRecReq.InsurerCode,
                    policyBL321110NewRecReq.ThirdPartyAdminCode, policyBL321110NewRecReq.BusinessLineCode,
                    policyBL321110NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL321110FindAF1WithRecIdFilter(policyBL321110NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL321110 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL321110(policyBL321110NewRecReq.SalesTransactionId, policyBL321110NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc321110 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL321110(policyBL321110NewRecReq.SalesTransactionId, policyBL321110NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL321110NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL321110Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL321110NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL321110NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL321110Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL321110UpdRec([FromBody] PolicyRelatedDocBL321110UpdRecReq policyRelatedDocBL321110UpdRecReq)
        {
            PolicyRelatedDocBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL321110Dto = new PolicyRelatedDocBL321110Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL321110UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL321110UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL321110UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL321110UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL321110UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL321110UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL321110UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL321110UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL321110UpdRecReq));
                resp.PolicyRelatedDocBL321110Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL321110UpdRec
                    (policyRelatedDocBL321110UpdRecReq.RecId,
                    policyRelatedDocBL321110UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL321110UpdRecReq.AttachDocName,
                      policyRelatedDocBL321110UpdRecReq.AttachDocExt,
                    policyRelatedDocBL321110UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL321110Dto.Reserved1 != null ? resp.PolicyRelatedDocBL321110Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL321110Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL321110UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL321110Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL321110Dto = new PolicyRelatedDocBL321110Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL321110UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL321110UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL321110Dto = new PolicyRelatedDocBL321110Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL321110NewRec([FromBody] PolicyRelatedDocBL321110NewRecReq policyRelatedDocBL321110NewRecReq)
        {
            PolicyRelatedDocBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL321110Dto = new PolicyRelatedDocBL321110Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL321110NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL321110NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL321110NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL321110NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL321110NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL321110NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL321110NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL321110NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL321110NewRecReq));
                resp.PolicyRelatedDocBL321110Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL321110NewRec(
                    policyRelatedDocBL321110NewRecReq.SalesTransactionId,
                    policyRelatedDocBL321110NewRecReq.TicketId,
                    policyRelatedDocBL321110NewRecReq.ParentPolicyId,
                    policyRelatedDocBL321110NewRecReq.PolicyId,
                    policyRelatedDocBL321110NewRecReq.BusinessLineCode,
                    policyRelatedDocBL321110NewRecReq.DocumentType,
                    policyRelatedDocBL321110NewRecReq.AttachDocBinary,
                    policyRelatedDocBL321110NewRecReq.AttachDocName,
                    policyRelatedDocBL321110NewRecReq.AttachDocExt,
                    policyRelatedDocBL321110NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL321110Dto.Reserved1 != null ? resp.PolicyRelatedDocBL321110Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL321110Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL321110NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL321110Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL321110Dto = new PolicyRelatedDocBL321110Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL321110NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL321110NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL321110Dto = new PolicyRelatedDocBL321110Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL321110UpdRec([FromBody] PolicyBL321110UpdRecReq policyBL321110UpdRecReq)
        {
            PolicyBL321110UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL321110 = new List<PolicyBL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL321110UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL321110UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL321110UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL321110UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL321110UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL321110UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL321110UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL321110UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL321110UpdRecReq));
                resp.PolicyBL321110 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL321110UpdRec
                    (policyBL321110UpdRecReq.SalesTransactionId,
                    policyBL321110UpdRecReq.TicketId,
                     policyBL321110UpdRecReq.ParentPolicyId,
                      policyBL321110UpdRecReq.PolicyId,
                       policyBL321110UpdRecReq.BusinessLineCode,
                        policyBL321110UpdRecReq.GrossPremiumGP,
                        policyBL321110UpdRecReq.CommisionFromGPPer,
                        policyBL321110UpdRecReq.CommisionFromGPAmount,
                        policyBL321110UpdRecReq.VATOnCommisionPer,
                        policyBL321110UpdRecReq.VATOnCommisionAmount,
                        policyBL321110UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL321110UpdRecReq.BuiltInPropTaxesPer,
                        policyBL321110UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL321110UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL321110UpdRecReq.InsurerLoadingPer,
                        policyBL321110UpdRecReq.InsurerLoadingAmount,
                        policyBL321110UpdRecReq.NetPremiumAmount,
                        policyBL321110UpdRecReq.WebRequestCommon.UserName,
                policyBL321110UpdRecReq.PolicyNumber,
                        policyBL321110UpdRecReq.PolicyEffectiveDate,
                policyBL321110UpdRecReq.PolicyExpiryDate,
                policyBL321110UpdRecReq.PolicyIssuedDate);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL321110[0].Reserved1 != null ?
                        resp.PolicyBL321110[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL321110[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL321110UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL321110[0].Reserved1 != null)
                        resp.PolicyBL321110 = new List<PolicyBL321110Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL321110UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL321110UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL321110 = new List<PolicyBL321110Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        public IActionResult PolicyBL321110FindAllWithParentPolicyId([FromBody] PolicyBL321110FindParentPolicyIdRecReq policyBL321110FindParentPolicyIdRecReq)
        {
            PolicyBL321110Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL321110Dto>() { },
                SalesTransactionBL321110 = new SalesTransactionBL321110Dto()
                {
                    RecId = -1,
                    AF1BL321110 = new List<AF1BL321110Dto>()
                },
                paymentScheduleBL321110 = new List<PaymentScheduleBL321110Dto>(),
                policyRelatedDoc321110 = new List<PolicyRelatedDocBL321110Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL321110FindParentPolicyIdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL321110FindParentPolicyIdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL321110FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL321110FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL321110FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL321110FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId, policyBL321110FindParentPolicyIdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyFindAllWithParentPolicyId is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL321110FindParentPolicyIdRecReq));
                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL321110FindAllWithParentPolicyId(policyBL321110FindParentPolicyIdRecReq.ParentPolicyId);
                if (resp.Policy == null)
                    return Ok(resp);
                if (resp.Policy.Count == 0)
                    return Ok(resp);
                resp.SalesTransactionBL321110 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL321110FindAF1WithRecIdFilter(resp.Policy[0].SalesTransactionId);
                resp.paymentScheduleBL321110 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL321110(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);
                resp.policyRelatedDoc321110 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL321110(resp.Policy[0].SalesTransactionId, resp.Policy[0].BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL321110FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL321110Dto>() { };
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
                resp.WebResponseCommon.CorrelationId = policyBL321110FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL321110Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
