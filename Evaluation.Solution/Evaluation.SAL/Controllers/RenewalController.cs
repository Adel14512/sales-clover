using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.Product;
using Evaluation.CAL.Response.Product;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.Product;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Request.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.Response.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.DTO.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.Request.Renewal;
using Evaluation.CAL.Response.Renewal;
using Evaluation.CAL.DTO.Renewal;
using Evaluation.CAL.DTO.BL080501;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RenewalController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public RenewalController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult RenewalParameterFindAll(RenewalParameterReq renewalParameterReq)
        {
            RenewalParameterResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                RenewalParameter = new List<RenewalParameterDto>()
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
                    resp.WebResponseCommon.CorrelationId = renewalParameterReq == null ? Guid.NewGuid().ToString() :
                        renewalParameterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        renewalParameterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        renewalParameterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        renewalParameterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(renewalParameterReq.WebRequestCommon.CorrelationId, renewalParameterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint RenewalParameterFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(renewalParameterReq));

                resp.RenewalParameter = InstManagerAccessPoint.GetNewAccessPoint().RenewalParameterFindAll();

                if (resp != null && resp.RenewalParameter != null && resp.RenewalParameter.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.RenewalParameter[0].Reserved1 != null ? resp.RenewalParameter[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.RenewalParameter[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = renewalParameterReq.WebRequestCommon.CorrelationId;
                    if (resp.RenewalParameter[0].Reserved1 != null)
                        resp.RenewalParameter = new List<RenewalParameterDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint RenewalParameterFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = renewalParameterReq.WebRequestCommon.CorrelationId;
                resp.RenewalParameter = new List<RenewalParameterDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult RenewalPolicyFindAll(RenewalPolicyReq renewalPolicyReq)
        {
            RenewalPolicyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                RenewalPolicy = new List<RenewalPolicyDto>()
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
                    resp.WebResponseCommon.CorrelationId = renewalPolicyReq == null ? Guid.NewGuid().ToString() :
                        renewalPolicyReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        renewalPolicyReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        renewalPolicyReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        renewalPolicyReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(renewalPolicyReq.WebRequestCommon.CorrelationId, renewalPolicyReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint RenewalPolicyFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(renewalPolicyReq));

                resp.RenewalPolicy = InstManagerAccessPoint.GetNewAccessPoint().RenewalPolicyFindAll();

                if (resp != null && resp.RenewalPolicy != null && resp.RenewalPolicy.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.RenewalPolicy[0].Reserved1 != null ? resp.RenewalPolicy[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.RenewalPolicy[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = renewalPolicyReq.WebRequestCommon.CorrelationId;
                    if (resp.RenewalPolicy[0].Reserved1 != null)
                        resp.RenewalPolicy = new List<RenewalPolicyDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint RenewalPolicyFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = renewalPolicyReq.WebRequestCommon.CorrelationId;
                resp.RenewalPolicy = new List<RenewalPolicyDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult RenewalProcessFindAll(RenewalProcessReq renewalProcessReq)
        {
            RenewalProcessResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                RenewalProcess = new List<RenewalProcessDto>()
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
                    resp.WebResponseCommon.CorrelationId = renewalProcessReq == null ? Guid.NewGuid().ToString() :
                        renewalProcessReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        renewalProcessReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        renewalProcessReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        renewalProcessReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(renewalProcessReq.WebRequestCommon.CorrelationId, renewalProcessReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint RenewalProcessFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(renewalProcessReq));

                resp.RenewalProcess = InstManagerAccessPoint.GetNewAccessPoint().RenewalProcessFindAll();

                if (resp != null && resp.RenewalProcess != null && resp.RenewalProcess.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.RenewalProcess[0].Reserved1 != null ? resp.RenewalProcess[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.RenewalProcess[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = renewalProcessReq.WebRequestCommon.CorrelationId;

                    var distinctPolicy = resp.RenewalProcess
                        .GroupBy(p => new { p.BusinessLineCode, p.PolicyId })
                        .Select(g => g.First())
                        .ToList();

                    foreach (var item in distinctPolicy)
                    {
                        var policyFilter = resp.RenewalProcess.Where(p => p.PolicyId == item.PolicyId).ToList();
                        if (item.BusinessLineCode == "080501" && policyFilter != null && policyFilter.Count > 0)
                        {
                            AF1BL080501Dtco aF1BL080501 = new AF1BL080501Dtco();
                            aF1BL080501.Ambulatory = policyFilter[0].Ambulatory;
                            aF1BL080501.ClassOfCoveragCode = policyFilter[0].ClassOfCoveragCode;
                            aF1BL080501.DoctorVisit = policyFilter[0].DoctorVisit;
                            aF1BL080501.NetworkLevelCode = policyFilter[0].NetworkLevelCode;
                            aF1BL080501.NSSF = policyFilter[0].NSSF;
                            aF1BL080501.PrescriptionMedecine = policyFilter[0].PrescriptionMedecine;
                            aF1BL080501.ResidenceCode = policyFilter[0].ResidenceCode;
                            List<AF1BL080501Dto> aF1BL080501List = new List<AF1BL080501Dto>();
                            foreach (var itemPolicy in policyFilter)
                            {
                                AF1BL080501Dto aF1BL080501Dto = new AF1BL080501Dto();
                                aF1BL080501Dto.FirstName = itemPolicy.FirstName;
                                aF1BL080501Dto.LastName = item.LastName;
                                aF1BL080501Dto.DOB = item.DOB;
                                aF1BL080501Dto.MiddleName = item.MiddleName;
                                aF1BL080501Dto.GenderCode = item.GenderCode;
                                aF1BL080501Dto.RelationCode = item.RelationCode;
                                aF1BL080501Dto.NationalityCode = item.NationalityCode;
                                aF1BL080501Dto.MaritalStatusCode = item.MaritalStatusCode;
                                aF1BL080501List.Add(aF1BL080501Dto);
                            }
                            aF1BL080501.AF1BL080501List = aF1BL080501List;
                            InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL080501NewRec(policyFilter[0].BusinessLineCode, policyFilter[0].ContactId, policyFilter[0].ClientId, policyFilter[0].MasterId, aF1BL080501, "SYSADMIN", policyFilter[0].PolicyId);
                        }
                    }

                    if (resp.RenewalProcess[0].Reserved1 != null)
                        resp.RenewalProcess = new List<RenewalProcessDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint RenewalProcessFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = renewalProcessReq.WebRequestCommon.CorrelationId;
                resp.RenewalProcess = new List<RenewalProcessDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
