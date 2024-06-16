using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL041312;
using Evaluation.CAL.DTO.BL041312Consolidation;
using Evaluation.CAL.Request.BL041312Consolidation;
using Evaluation.CAL.Response.BL041312Consolidation;
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
    public class PolicyBL041312Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public PolicyBL041312Controller(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PolicyBL041312NewRec([FromBody] PolicyBL041312NewRecReq policyBL041312NewRecReq)
        {
            PolicyBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Policy = new List<PolicyBL041312Dto>() { },
                SalesTransactionBL041312 = new SalesTransactionBL041312Dto()
                {
                    RecId = -1,
                    AF1BL041312 = new List<AF1BL041312Dto>()
                },
                paymentScheduleBL041312 = new List<PaymentScheduleBL041312Dto>(),
                policyRelatedDoc041312 = new List<PolicyRelatedDocBL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL041312NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL041312NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL041312NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL041312NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL041312NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL041312NewRecReq.WebRequestCommon.CorrelationId, policyBL041312NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL041312NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL041312NewRecReq));

                resp.Policy = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL041312NewRec
                    (policyBL041312NewRecReq.SalesTransactionId,
                    policyBL041312NewRecReq.InsurerCode,
                    policyBL041312NewRecReq.ThirdPartyAdminCode, 
                    policyBL041312NewRecReq.BusinessLineCode,
                    policyBL041312NewRecReq.WebRequestCommon.UserName);


                resp.SalesTransactionBL041312 = InstManagerAccessPoint.GetNewAccessPoint().
                    SalesTransactionBL041312FindAF1WithRecIdFilter(policyBL041312NewRecReq.SalesTransactionId);


                resp.paymentScheduleBL041312 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyPaymentScheduleBL041312(policyBL041312NewRecReq.SalesTransactionId, policyBL041312NewRecReq.BusinessLineCode);


                resp.policyRelatedDoc041312 = InstManagerAccessPoint.GetNewAccessPoint().
                   PolicyRelatedDocBL041312(policyBL041312NewRecReq.SalesTransactionId, policyBL041312NewRecReq.BusinessLineCode);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Policy[0].Reserved1 != null ? resp.Policy[0].Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Policy[0].Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL041312NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Policy[0].Reserved1 != null)
                        resp.Policy = new List<PolicyBL041312Dto>() { };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL041312NewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = policyBL041312NewRecReq.WebRequestCommon.CorrelationId;
                resp.Policy = new List<PolicyBL041312Dto>() { };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult PolicyRelatedDocBL041312UpdRec([FromBody] PolicyRelatedDocBL041312UpdRecReq policyRelatedDocBL041312UpdRecReq)
        {
            PolicyRelatedDocBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL041312Dto = new PolicyRelatedDocBL041312Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL041312UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL041312UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL041312UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL041312UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL041312UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL041312UpdRecReq.WebRequestCommon.CorrelationId, policyRelatedDocBL041312UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL041312UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL041312UpdRecReq));
                resp.PolicyRelatedDocBL041312Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL041312UpdRec
                    (policyRelatedDocBL041312UpdRecReq.RecId,
                    policyRelatedDocBL041312UpdRecReq.AttachDocBinary,
                     policyRelatedDocBL041312UpdRecReq.AttachDocName,
                      policyRelatedDocBL041312UpdRecReq.AttachDocExt,
                    policyRelatedDocBL041312UpdRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL041312Dto.Reserved1 != null ? resp.PolicyRelatedDocBL041312Dto.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL041312Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL041312UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL041312Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL041312Dto = new PolicyRelatedDocBL041312Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL041312UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL041312UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL041312Dto = new PolicyRelatedDocBL041312Dto()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyRelatedDocBL041312NewRec([FromBody] PolicyRelatedDocBL041312NewRecReq policyRelatedDocBL041312NewRecReq)
        {
            PolicyRelatedDocBL041312Resp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyRelatedDocBL041312Dto = new PolicyRelatedDocBL041312Dto()
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
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL041312NewRecReq == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL041312NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL041312NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyRelatedDocBL041312NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyRelatedDocBL041312NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyRelatedDocBL041312NewRecReq.WebRequestCommon.CorrelationId,
                    policyRelatedDocBL041312NewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL041312NewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyRelatedDocBL041312NewRecReq));
                resp.PolicyRelatedDocBL041312Dto = InstManagerAccessPoint.GetNewAccessPoint().PolicyRelatedDocBL041312NewRec(
                    policyRelatedDocBL041312NewRecReq.SalesTransactionId,
                    policyRelatedDocBL041312NewRecReq.TicketId,
                    policyRelatedDocBL041312NewRecReq.ParentPolicyId,
                    policyRelatedDocBL041312NewRecReq.PolicyId,
                    policyRelatedDocBL041312NewRecReq.BusinessLineCode,
                    policyRelatedDocBL041312NewRecReq.DocumentType,
                    policyRelatedDocBL041312NewRecReq.AttachDocBinary,
                    policyRelatedDocBL041312NewRecReq.AttachDocName,
                    policyRelatedDocBL041312NewRecReq.AttachDocExt,
                    policyRelatedDocBL041312NewRecReq.WebRequestCommon.UserName);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyRelatedDocBL041312Dto.Reserved1 != null ? resp.PolicyRelatedDocBL041312Dto.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyRelatedDocBL041312Dto.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyRelatedDocBL041312NewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyRelatedDocBL041312Dto.Reserved1 != null)
                        resp.PolicyRelatedDocBL041312Dto = new PolicyRelatedDocBL041312Dto
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyRelatedDocBL041312NewRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyRelatedDocBL041312NewRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyRelatedDocBL041312Dto = new PolicyRelatedDocBL041312Dto()
                {
                };
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        public IActionResult PolicyBL041312UpdRec([FromBody] PolicyBL041312UpdRecReq policyBL041312UpdRecReq)
        {
            PolicyBL041312UpdResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                PolicyBL041312 = new List<PolicyBL041312Dto>()
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
                    resp.WebResponseCommon.CorrelationId = policyBL041312UpdRecReq == null ? Guid.NewGuid().ToString() :
                        policyBL041312UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        policyBL041312UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        policyBL041312UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        policyBL041312UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(policyBL041312UpdRecReq.WebRequestCommon.CorrelationId,
                    policyBL041312UpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint PolicyBL041312UpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(policyBL041312UpdRecReq));
                resp.PolicyBL041312 = InstManagerAccessPoint.GetNewAccessPoint().PolicyBL041312UpdRec
                    (policyBL041312UpdRecReq.SalesTransactionId,
                    policyBL041312UpdRecReq.TicketId,
                     policyBL041312UpdRecReq.ParentPolicyId,
                      policyBL041312UpdRecReq.PolicyId,
                       policyBL041312UpdRecReq.BusinessLineCode,
                        policyBL041312UpdRecReq.GrossPremiumGP,
                        policyBL041312UpdRecReq.CommisionFromGPPer,
                        policyBL041312UpdRecReq.CommisionFromGPAmount,
                        policyBL041312UpdRecReq.VATOnCommisionPer,
                        policyBL041312UpdRecReq.VATOnCommisionAmount,
                        policyBL041312UpdRecReq.BuiltInFixedTaxesAmount,
                        policyBL041312UpdRecReq.BuiltInPropTaxesPer,
                        policyBL041312UpdRecReq.BuiltInPropTaxesAmount,
                        policyBL041312UpdRecReq.BuiltInCostOfPolicyAmount,
                        policyBL041312UpdRecReq.InsurerLoadingPer,
                        policyBL041312UpdRecReq.InsurerLoadingAmount,
                        policyBL041312UpdRecReq.NetPremiumAmount,
                        policyBL041312UpdRecReq.WebRequestCommon.UserName,
                policyBL041312UpdRecReq.PolicyNumber,
                        policyBL041312UpdRecReq.PolicyEffectiveDate,
                policyBL041312UpdRecReq.PolicyExpiryDate,
                policyBL041312UpdRecReq.PolicyIssuedDate);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.PolicyBL041312[0].Reserved1 != null ?
                        resp.PolicyBL041312[0].Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.PolicyBL041312[0].Reserved1 != null ?
                        StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = policyBL041312UpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.PolicyBL041312[0].Reserved1 != null)
                        resp.PolicyBL041312 = new List<PolicyBL041312Dto>
                        {
                        };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint PolicyBL041312UpdRec is completed");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = policyBL041312UpdRecReq.WebRequestCommon.CorrelationId;
                resp.PolicyBL041312 = new List<PolicyBL041312Dto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
