using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL301401;
using Evaluation.CAL.DTO.BL301401Consolidation;
using Evaluation.CAL.Request.BL301401Consolidation;
using Evaluation.CAL.Request.Consolidation;
using Evaluation.CAL.Response.BL301401Consolidation;
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
    public class PolicyBL301401Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL301401Controller(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PolicyBL301401NewRec([FromBody] PolicyBL301401NewRecReq policyBL301401NewRecReq)
        {
            PolicyBL301401Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL301401Dto>() { },
                SalesTransactionBL301401 = new SalesTransactionBL301401Dto()
                {
                    RecId = -1,
                    AF1BL301401 = new List<AF1BL301401Dto>()
                },
                paymentScheduleBL301401 = new List<PaymentScheduleBL301401Dto>(),
                policyRelatedDoc301401 = new List<PolicyRelatedDocBL301401Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL301401NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL301401NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL301401NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL301401NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL301401NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL301401NewRecReq.WebRequestCommon.CorrelationId, policyBL301401NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL301401NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL301401NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL301401NewRec
                    (policyBL301401NewRecReq.SalesTransactionId,
                    policyBL301401NewRecReq.ProductId,
                    policyBL301401NewRecReq.Combination, policyBL301401NewRecReq.BusinessLineCode,
                    policyBL301401NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL301401 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL301401FindAF1WithRecIdFilter(policyBL301401NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL301401 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL301401(policyBL301401NewRecReq.SalesTransactionId, policyBL301401NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc301401 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL301401(policyBL301401NewRecReq.SalesTransactionId, policyBL301401NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL301401NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL301401Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL301401NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL301401NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL301401Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL301401UpdRec([FromBody] PolicyRelatedDocBL301401UpdRecReq policyRelatedDocBL301401UpdRecReq)
        {
            PolicyRelatedDocBL301401Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL301401Dto = new PolicyRelatedDocBL301401Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL301401UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL301401UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL301401UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL301401UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL301401UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL301401UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL301401UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL301401UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL301401UpdRecReq));
                resp.PolicyRelatedDocBL301401Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL301401UpdRec
                    (policyRelatedDocBL301401UpdRecReq.RecId,
                    policyRelatedDocBL301401UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL301401UpdRecReq.AttachDocName,
                      policyRelatedDocBL301401UpdRecReq.AttachDocExt,
                    policyRelatedDocBL301401UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL301401Dto.Reserved1 != null ? resp.PolicyRelatedDocBL301401Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL301401Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL301401UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL301401Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL301401Dto = new PolicyRelatedDocBL301401Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL301401UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL301401UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL301401Dto = new PolicyRelatedDocBL301401Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL301401NewRec([FromBody] PolicyRelatedDocBL301401NewRecReq policyRelatedDocBL301401NewRecReq)
        {
            PolicyRelatedDocBL301401Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL301401Dto = new PolicyRelatedDocBL301401Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL301401NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL301401NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL301401NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL301401NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL301401NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL301401NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL301401NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL301401NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL301401NewRecReq));
                resp.PolicyRelatedDocBL301401Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL301401NewRec(
                    policyRelatedDocBL301401NewRecReq.SalesTransactionId,
                    policyRelatedDocBL301401NewRecReq.TicketId,
                    policyRelatedDocBL301401NewRecReq.ParentPolicyId,
                    policyRelatedDocBL301401NewRecReq.PolicyId,
                    policyRelatedDocBL301401NewRecReq.BusinessLineCode,
                    policyRelatedDocBL301401NewRecReq.DocumentType,
                    policyRelatedDocBL301401NewRecReq.AttachDocBinary,
                    policyRelatedDocBL301401NewRecReq.AttachDocName,
                    policyRelatedDocBL301401NewRecReq.AttachDocExt,
                    policyRelatedDocBL301401NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL301401Dto.Reserved1 != null ? resp.PolicyRelatedDocBL301401Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL301401Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL301401NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL301401Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL301401Dto = new PolicyRelatedDocBL301401Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL301401NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL301401NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL301401Dto = new PolicyRelatedDocBL301401Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL301401UpdRec([FromBody] PolicyBL301401UpdRecReq policyBL301401UpdRecReq)
        {
            PolicyBL301401UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL301401 = new List<PolicyBL301401Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL301401UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL301401UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL301401UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL301401UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL301401UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL301401UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL301401UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL301401UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL301401UpdRecReq));
                resp.PolicyBL301401 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL301401UpdRec
                    (policyBL301401UpdRecReq.SalesTransactionId,
                    policyBL301401UpdRecReq.TicketId,
                     policyBL301401UpdRecReq.ParentPolicyId,
                      policyBL301401UpdRecReq.PolicyId,
                       policyBL301401UpdRecReq.BusinessLineCode,
                        policyBL301401UpdRecReq.GrossPremiumGP,
                        policyBL301401UpdRecReq.CommisionFromGPPer,
                        policyBL301401UpdRecReq.CommisionFromGPAmount,
                        policyBL301401UpdRecReq.VATOnCommisionPer,
                        policyBL301401UpdRecReq.VATOnCommisionAmount,
                        policyBL301401UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL301401UpdRecReq.BuiltInPropTaxesPer,
                        policyBL301401UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL301401UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL301401UpdRecReq.InsurerLoadingPer,
                        policyBL301401UpdRecReq.InsurerLoadingAmount,
                        policyBL301401UpdRecReq.NetPremiumAmount,
                        policyBL301401UpdRecReq.WebRequestCommon.UserName,
                policyBL301401UpdRecReq.PolicyNumber,
                        policyBL301401UpdRecReq.PolicyEffectiveDate,
                policyBL301401UpdRecReq.PolicyExpiryDate,
                        policyBL301401UpdRecReq.PolicyIssuedDate,
                        policyBL301401UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL301401[0].Reserved1 != null ?
                        resp.PolicyBL301401[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL301401[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL301401UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL301401[0].Reserved1 != null)
                        resp.PolicyBL301401 = new List<PolicyBL301401Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL301401UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL301401UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL301401 = new List<PolicyBL301401Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
