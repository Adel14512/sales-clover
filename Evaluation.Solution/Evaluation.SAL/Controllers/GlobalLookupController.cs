using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.Global;
using Evaluation.CAL.Request.Global;
using Evaluation.CAL.Response.Global;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GlobalLookupController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public GlobalLookupController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult GlobalLookupFindAll(GlobalLookupFindAllReq lookupFindAllReq)
        {
            GlobalLookupFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Client = new List<ClientDto>(),
                Master = new List<MasterDto>()

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
                    resp.WebResponseCommon.CorrelationId = lookupFindAllReq == null ? Guid.NewGuid().ToString() :
                        lookupFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        lookupFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        lookupFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        lookupFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(lookupFindAllReq.WebRequestCommon.CorrelationId, lookupFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint Global LookupFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(lookupFindAllReq));

                List<GlobalLookupDto> lookupList = InstManagerAccessPoint.GetNewAccessPoint().GlobalLookupFindAll();
                if (lookupList != null && lookupList.Count > 0)
                {
                    var list = lookupList.FindAll(e => e.TableName == "clients").ToList();
                    var clientList = new List<ClientDto>();
                    foreach (var item in list)
                    {
                        clientList.Add(new ClientDto
                        {
                            Code = item.Code,
                            Description = item.Description,
                            Type = item.Type,
                            MasterId = item.MasterId,
                            IsDefault = item.IsDefault
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "Mastersn").ToList();
                    var masterList = new List<MasterDto>();
                    foreach (var item in list)
                    {
                        masterList.Add(new MasterDto
                        {
                            Code = item.Code,
                            Description = item.Description,
                            Type = item.Type,
                            IsDefault = item.IsDefault
                        });
                    }

                    resp.Client = clientList;
                    resp.Master = masterList;
                }
                if (lookupList != null && lookupList.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = lookupList[0].Reserved1 != null ? lookupList[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = lookupList == null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = lookupFindAllReq.WebRequestCommon.CorrelationId;
                    if (lookupList[0].Reserved1 != null)
                    {
                        resp.Client = new List<ClientDto>();
                        resp.Master = new List<MasterDto>();
                    }
                }

                else
                {
                    //resp.
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint Global LookupFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = lookupFindAllReq.WebRequestCommon.CorrelationId;
                //resp.Lookup = new List<LookupDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult ClientCodeWithRecIdFilter([FromBody] ClientCodeFindWithRecIdReq clientCodeFindWithRecIdReq)
        {
            ClientCodeFindResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                }
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
                    resp.WebResponseCommon.CorrelationId = clientCodeFindWithRecIdReq == null ? Guid.NewGuid().ToString() :
                        clientCodeFindWithRecIdReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        clientCodeFindWithRecIdReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        clientCodeFindWithRecIdReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        clientCodeFindWithRecIdReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(clientCodeFindWithRecIdReq.WebRequestCommon.CorrelationId, clientCodeFindWithRecIdReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ClientCodeWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(clientCodeFindWithRecIdReq));
                resp.Client = InstManagerAccessPoint.GetNewAccessPoint().
                    ClientCodeFindWithRecid(clientCodeFindWithRecIdReq.RecId);

                if (resp != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Client[0].Reserved1 != null ? resp.Client[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Client[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = clientCodeFindWithRecIdReq.WebRequestCommon.CorrelationId;
                    if (resp.Client[0].Reserved1 != null)
                        resp.Client = new List<ClientCodeDto>()
                        {
                        };
                    //{
                    //    Code= regionNewRecReq.Region.Code,
                    //    Description= regionNewRecReq.Region.Description,
                    //    IsActive= regionNewRecReq.Region.IsActive                            
                    //};
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ClientCodeWithRecIdFilter is completed");
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
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
                resp.WebResponseCommon.CorrelationId = clientCodeFindWithRecIdReq.WebRequestCommon.CorrelationId;
                resp.Client = new List<ClientCodeDto>() { };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                return Ok(resp);
            }
        }
    }
}