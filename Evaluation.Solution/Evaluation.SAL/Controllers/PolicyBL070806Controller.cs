using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL070806;
using Evaluation.CAL.DTO.BL070806Consolidation;
using Evaluation.CAL.Request.BL070806Consolidation;
using Evaluation.CAL.Response.BL070806Consolidation;
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
    public class PolicyBL070806Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL070806Controller(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult PolicyBL070806NewRec([FromBody] PolicyBL070806NewRecReq policyBL070806NewRecReq)
        {
            PolicyBL070806Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL070806Dto>() { },
                SalesTransactionBL070806 = new SalesTransactionBL070806Dto()
                {
                    RecId = -1,
                    AF1BL070806 = new AF1BL070806Dtco()
                },
                paymentScheduleBL070806 = new List<PaymentScheduleBL070806Dto>(),
                policyRelatedDoc070806 = new List<PolicyRelatedDocBL070806Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL070806NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL070806NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL070806NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL070806NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL070806NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL070806NewRecReq.WebRequestCommon.CorrelationId, policyBL070806NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL070806NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL070806NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL070806NewRec
                    (policyBL070806NewRecReq.SalesTransactionId,
                    policyBL070806NewRecReq.ProductId,
                    policyBL070806NewRecReq.Combination, policyBL070806NewRecReq.BusinessLineCode,
                    policyBL070806NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL070806 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL070806FindAF1WithRecIdFilter(policyBL070806NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL070806 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL070806(policyBL070806NewRecReq.SalesTransactionId, policyBL070806NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc070806 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL070806(policyBL070806NewRecReq.SalesTransactionId, policyBL070806NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL070806NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL070806Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL070806NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL070806NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL070806Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL070806UpdRec([FromBody] PolicyRelatedDocBL070806UpdRecReq policyRelatedDocBL070806UpdRecReq)
        {
            PolicyRelatedDocBL070806Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL070806Dto = new PolicyRelatedDocBL070806Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL070806UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL070806UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL070806UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL070806UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL070806UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL070806UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL070806UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL070806UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL070806UpdRecReq));
                resp.PolicyRelatedDocBL070806Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL070806UpdRec
                    (policyRelatedDocBL070806UpdRecReq.RecId,
                    policyRelatedDocBL070806UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL070806UpdRecReq.AttachDocName,
                      policyRelatedDocBL070806UpdRecReq.AttachDocExt,
                    policyRelatedDocBL070806UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL070806Dto.Reserved1 != null ? resp.PolicyRelatedDocBL070806Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL070806Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL070806UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL070806Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL070806Dto = new PolicyRelatedDocBL070806Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL070806UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL070806UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL070806Dto = new PolicyRelatedDocBL070806Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL070806NewRec([FromBody] PolicyRelatedDocBL070806NewRecReq policyRelatedDocBL070806NewRecReq)
        {
            PolicyRelatedDocBL070806Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL070806Dto = new PolicyRelatedDocBL070806Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL070806NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL070806NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL070806NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL070806NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL070806NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL070806NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL070806NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL070806NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL070806NewRecReq));
                resp.PolicyRelatedDocBL070806Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL070806NewRec(
                    policyRelatedDocBL070806NewRecReq.SalesTransactionId,
                    policyRelatedDocBL070806NewRecReq.TicketId,
                    policyRelatedDocBL070806NewRecReq.ParentPolicyId,
                    policyRelatedDocBL070806NewRecReq.PolicyId,
                    policyRelatedDocBL070806NewRecReq.BusinessLineCode,
                    policyRelatedDocBL070806NewRecReq.DocumentType,
                    policyRelatedDocBL070806NewRecReq.AttachDocBinary,
                    policyRelatedDocBL070806NewRecReq.AttachDocName,
                    policyRelatedDocBL070806NewRecReq.AttachDocExt,
                    policyRelatedDocBL070806NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL070806Dto.Reserved1 != null ? resp.PolicyRelatedDocBL070806Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL070806Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL070806NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL070806Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL070806Dto = new PolicyRelatedDocBL070806Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL070806NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL070806NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL070806Dto = new PolicyRelatedDocBL070806Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL070806UpdRec([FromBody] PolicyBL070806UpdRecReq policyBL070806UpdRecReq)
        {
            PolicyBL070806UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL070806 = new List<PolicyBL070806Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL070806UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL070806UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL070806UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL070806UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL070806UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL070806UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL070806UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL070806UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL070806UpdRecReq));
                resp.PolicyBL070806 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL070806UpdRec
                    (policyBL070806UpdRecReq.SalesTransactionId,
                    policyBL070806UpdRecReq.TicketId,
                     policyBL070806UpdRecReq.ParentPolicyId,
                      policyBL070806UpdRecReq.PolicyId,
                       policyBL070806UpdRecReq.BusinessLineCode,
                        policyBL070806UpdRecReq.GrossPremiumGP,
                        policyBL070806UpdRecReq.CommisionFromGPPer,
                        policyBL070806UpdRecReq.CommisionFromGPAmount,
                        policyBL070806UpdRecReq.VATOnCommisionPer,
                        policyBL070806UpdRecReq.VATOnCommisionAmount,
                        policyBL070806UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL070806UpdRecReq.BuiltInPropTaxesPer,
                        policyBL070806UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL070806UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL070806UpdRecReq.InsurerLoadingPer,
                        policyBL070806UpdRecReq.InsurerLoadingAmount,
                        policyBL070806UpdRecReq.NetPremiumAmount,
                        policyBL070806UpdRecReq.WebRequestCommon.UserName,
                policyBL070806UpdRecReq.PolicyNumber,
                        policyBL070806UpdRecReq.PolicyEffectiveDate,
                policyBL070806UpdRecReq.PolicyExpiryDate,
                        policyBL070806UpdRecReq.PolicyIssuedDate,
                        policyBL070806UpdRecReq.PolicyHolder);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL070806[0].Reserved1 != null ?
                        resp.PolicyBL070806[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL070806[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL070806UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL070806[0].Reserved1 != null)
                        resp.PolicyBL070806 = new List<PolicyBL070806Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL070806UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL070806UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL070806 = new List<PolicyBL070806Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}