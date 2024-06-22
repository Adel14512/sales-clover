﻿using Evaluation.BAL.AccessPoint;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RenwalController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public RenwalController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult RenewalParameterFindAll(RenewalParameterReq renewalParameterReq)
        {
            RenwalParameterResp resp;
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
    }
}
