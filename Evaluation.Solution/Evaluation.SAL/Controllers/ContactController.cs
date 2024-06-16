using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public IConfiguration _Configuration { get; }

        public ContactController(IConfiguration configuration, ILoggerManager logger)
        {
            _Configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ContactFindWithAnyValue([FromBody] ContactChannelFindAnyReq contactChannelFindAnyReq)
        {
            ContactChannelFindAnyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Contact = new List<ContactDto>()
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
                    resp.WebResponseCommon.CorrelationId = contactChannelFindAnyReq == null ? Guid.NewGuid().ToString() :
                        contactChannelFindAnyReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        contactChannelFindAnyReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        contactChannelFindAnyReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        contactChannelFindAnyReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(contactChannelFindAnyReq.WebRequestCommon.CorrelationId, contactChannelFindAnyReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ContactFindAny is started");
                _logger.LogDebug(JsonConvert.SerializeObject(contactChannelFindAnyReq));
                resp.Contact = InstManagerAccessPoint.GetNewAccessPoint().ContactFindWithAnyValue(contactChannelFindAnyReq.SearchValue);

                if (resp != null && resp.Contact.Count == 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "No content";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelFindAnyReq.WebRequestCommon.CorrelationId;
                    resp.Contact = new List<ContactDto>()
                    {
                    };
                }

                if (resp != null && resp.Contact.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "Enquiry succeeded";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelFindAnyReq.WebRequestCommon.CorrelationId;
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ContactFindAny is completed");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = contactChannelFindAnyReq.WebRequestCommon.CorrelationId;
                resp.Contact = new List<ContactDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ContactFindWithAnyFilter([FromBody] ContactChannelSearchWithFilterReq contactChannelSearchWithFilterReq)
        {
            ContactChannelFindAnyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Contact = new List<ContactDto>()
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
                    resp.WebResponseCommon.CorrelationId = contactChannelSearchWithFilterReq == null ? Guid.NewGuid().ToString() :
                        contactChannelSearchWithFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        contactChannelSearchWithFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        contactChannelSearchWithFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        contactChannelSearchWithFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(contactChannelSearchWithFilterReq.WebRequestCommon.CorrelationId, contactChannelSearchWithFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ContactFindAny is started");
                _logger.LogDebug(JsonConvert.SerializeObject(contactChannelSearchWithFilterReq));
                resp.Contact = InstManagerAccessPoint.GetNewAccessPoint().ContactFindWithAnyFilter(contactChannelSearchWithFilterReq);

                if (resp != null && resp.Contact.Count == 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "No content";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelSearchWithFilterReq.WebRequestCommon.CorrelationId;
                    resp.Contact = new List<ContactDto>()
                    {
                    };
                }

                if (resp != null && resp.Contact.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "Enquiry succeeded";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelSearchWithFilterReq.WebRequestCommon.CorrelationId;
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ContactSearchWithFilter is completed");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = contactChannelSearchWithFilterReq.WebRequestCommon.CorrelationId;
                resp.Contact = new List<ContactDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ContactFindWithRecIdFilter([FromBody] ContactFindWithRecIdFilterReq contactFindWithRecIdFilterReq)
        {
            ContactChannelFindAnyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Contact = new List<ContactDto>()
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
                    resp.WebResponseCommon.CorrelationId = contactFindWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        contactFindWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        contactFindWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        contactFindWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        contactFindWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(contactFindWithRecIdFilterReq.WebRequestCommon.CorrelationId, contactFindWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ContactFindWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(contactFindWithRecIdFilterReq));
                resp.Contact = InstManagerAccessPoint.GetNewAccessPoint().ContactFindWithRecIdFilter(contactFindWithRecIdFilterReq.RecId);

                if (resp != null && resp.Contact.Count == 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "No content";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = contactFindWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    resp.Contact = new List<ContactDto>()
                    {
                    };
                }

                if (resp != null && resp.Contact.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "Enquiry succeeded";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = contactFindWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ContactFindWithRecIdFilter is completed");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = contactFindWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.Contact = new List<ContactDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult ContactNewRec([FromBody] ContactChannelNewRecReq contactChannelNewRecReq)
        {
            ContactChannelFindAnyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Contact = new List<ContactDto>()
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
                    resp.WebResponseCommon.CorrelationId = contactChannelNewRecReq == null ? Guid.NewGuid().ToString() :
                        contactChannelNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        contactChannelNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        contactChannelNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        contactChannelNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(contactChannelNewRecReq.WebRequestCommon.CorrelationId, contactChannelNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ContactNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(contactChannelNewRecReq));
                resp.Contact = InstManagerAccessPoint.GetNewAccessPoint().ContactChannelNewRec(contactChannelNewRecReq.Contact, contactChannelNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Contact.Count == 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "No content";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelNewRecReq.WebRequestCommon.CorrelationId;
                    resp.Contact = new List<ContactDto>()
                    {
                    };
                }

                if (resp != null && resp.Contact.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "New record created";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelNewRecReq.WebRequestCommon.CorrelationId;
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ContactNewRec is completed");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = contactChannelNewRecReq.WebRequestCommon.CorrelationId;
                resp.Contact = new List<ContactDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        public IActionResult ContactUpdRec([FromBody] ContactChannelUpdRecReq contactChannelUpdRecReq)
        {
            ContactChannelFindAnyResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Contact = new List<ContactDto>()
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
                    resp.WebResponseCommon.CorrelationId = contactChannelUpdRecReq == null ? Guid.NewGuid().ToString() :
                        contactChannelUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        contactChannelUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        contactChannelUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        contactChannelUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }

                _logger.SetCorrelationId(contactChannelUpdRecReq.WebRequestCommon.CorrelationId, contactChannelUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ContactUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(contactChannelUpdRecReq));
                resp.Contact = InstManagerAccessPoint.GetNewAccessPoint().ContactChannelUpdRec(contactChannelUpdRecReq.Contact, contactChannelUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Contact.Count == 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "No content";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status204NoContent.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelUpdRecReq.WebRequestCommon.CorrelationId;
                    resp.Contact = new List<ContactDto>()
                    {
                    };
                }

                if (resp != null && resp.Contact.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = "Record updated";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = contactChannelUpdRecReq.WebRequestCommon.CorrelationId;
                }

                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ContactUpdRec is completed");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = contactChannelUpdRecReq.WebRequestCommon.CorrelationId;
                resp.Contact = new List<ContactDto>()
                {
                };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
