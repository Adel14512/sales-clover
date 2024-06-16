using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
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
    public class LookupController : ControllerBase
    {

        //public IConfiguration _Configuration { get; }
        //public ContactController(IConfiguration configuration)
        //{
        //    _Configuration = configuration;
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login([FromBody] UserLogin userLogin)
        //{
        //    var user = Authenticate(userLogin);
        //    if (user != null)
        //    {
        //        var token = Generate(user);
        //        return Ok(token);
        //    }
        //    return NotFound("");
        //    // UserCredDao t = new UserCredDao();
        //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        //}

        //private string Generate(UserModel user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.UserName),
        //        new Claim(ClaimTypes.Email, user.EamilAddress),
        //        new Claim(ClaimTypes.GivenName, user.Givename),
        //        new Claim(ClaimTypes.Surname, user.Surname),
        //        new Claim(ClaimTypes.Role, user.Role)
        //    };

        //    var token = new JwtSecurityToken(_Configuration["Jwt:Issuer"],
        //        _Configuration["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: credentials
        //        );
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private UserModel Authenticate(UserLogin userLogin)
        //{
        //    var currentUser = UserConstants.Users.FirstOrDefault(o => o.UserName.ToLower() ==
        //    userLogin.UserName.ToLower() && o.Password == userLogin.Password);
        //    if (currentUser != null)
        //    {
        //        return currentUser;
        //    }

        //    return null;
        //}

        private readonly ILoggerManager _logger;

        public LookupController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[Authorize]
        public IActionResult RegionFindAll(RegionFindAllReq regionFindAllReq)
        {
            RegionFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Region = new List<RegionDto>()
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
                    resp.WebResponseCommon.CorrelationId = regionFindAllReq == null ? Guid.NewGuid().ToString() :
                        regionFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        regionFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        regionFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        regionFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(regionFindAllReq.WebRequestCommon.CorrelationId, regionFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint RegionFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(regionFindAllReq));
                resp.Region = InstManagerAccessPoint.GetNewAccessPoint().RegionFindAll();

                if (resp != null && resp.Region != null && resp.Region.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Region[0].Reserved1 != null ? resp.Region[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Region[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId;
                    if (resp.Region[0].Reserved1 != null)
                        resp.Region = new List<RegionDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint RegionFindAll is completed");
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
                resp.WebResponseCommon.CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId;
                resp.Region = new List<RegionDto>();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult RegionNewRec(RegionNewRecReq regionNewRecReq)
        {
            RegionResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Region = new RegionDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = regionNewRecReq == null ? Guid.NewGuid().ToString() :
                        regionNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        regionNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        regionNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        regionNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(regionNewRecReq.WebRequestCommon.CorrelationId, regionNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint RegionNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(regionNewRecReq));
                resp.Region = InstManagerAccessPoint.GetNewAccessPoint().RegionNewRec(regionNewRecReq.Region, regionNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Region != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Region.Reserved1 != null ? resp.Region.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Region.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = regionNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Region.Reserved1 != null)
                        resp.Region = new CAL.DTO.RegionDto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint RegionNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = regionNewRecReq.WebRequestCommon.CorrelationId;
                resp.Region = new CAL.DTO.RegionDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult RegionUpdRec(RegionUpdRecReq regionUpdRecReq)
        {
            RegionResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Region = new RegionDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = regionUpdRecReq == null ? Guid.NewGuid().ToString() :
                            regionUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            regionUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            regionUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            regionUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(regionUpdRecReq.WebRequestCommon.CorrelationId, regionUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint RegionUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(regionUpdRecReq));
                resp.Region = InstManagerAccessPoint.GetNewAccessPoint().RegionUpdRec(regionUpdRecReq.Region, regionUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Region != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Region.Reserved1 != null ? resp.Region.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.Region.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = regionUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Region.Reserved1 != null)
                        resp.Region = new RegionDto() { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint RegionUpdRec is completed");

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
                resp.WebResponseCommon.CorrelationId = regionUpdRecReq.WebRequestCommon.CorrelationId;
                resp.Region = new RegionDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult GenderFindAll(GenderFindAllReq genderFindAllReq)
        {
            GenderFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Gender = new List<CAL.DTO.GenderDto>()
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request";
                    resp.WebResponseCommon.CorrelationId = genderFindAllReq == null ? Guid.NewGuid().ToString() :
                        genderFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        genderFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        genderFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        genderFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(genderFindAllReq.WebRequestCommon.CorrelationId, genderFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint GenderFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(genderFindAllReq));

                resp.Gender = InstManagerAccessPoint.GetNewAccessPoint().GenderFindAll();

                if (resp != null && resp.Gender != null && resp.Gender.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Gender[0].Reserved1 != null ? resp.Gender[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Gender[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = genderFindAllReq.WebRequestCommon.CorrelationId;
                    if (resp.Gender[0].Reserved1 != null)
                        resp.Gender = new List<GenderDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint GenderFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = genderFindAllReq.WebRequestCommon.CorrelationId;
                resp.Gender = new List<GenderDto>();
                //CorrelationId = genderFindAllReq.WebRequestCommon.CorrelationId
                //Region = InstManagerAccessPoint.GetNewAccessPoint().RegionFindAll()
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult GenderNewRec(GenderNewRecReq genderNewRecReq)
        {
            GenderResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Gender = new GenderDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = genderNewRecReq == null ? Guid.NewGuid().ToString() :
                        genderNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        genderNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        genderNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        genderNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(genderNewRecReq.WebRequestCommon.CorrelationId, genderNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint GenderNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(genderNewRecReq));

                resp.Gender = InstManagerAccessPoint.GetNewAccessPoint().GenderNewRec(genderNewRecReq.Gender, genderNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Gender != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Gender.Reserved1 != null ? resp.Gender.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Gender.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = genderNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Gender.Reserved1 != null)
                        resp.Gender = new GenderDto() { RecId = -1 };
                }
                //else
                //{
                //    //
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint GenderNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = genderNewRecReq.WebRequestCommon.CorrelationId;
                resp.Gender = new GenderDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult GenderUpdRec(GenderUpdRecReq genderUpdRecReq)
        {
            GenderResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Gender = new GenderDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = genderUpdRecReq == null ? Guid.NewGuid().ToString() :
                            genderUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            genderUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            genderUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            genderUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(genderUpdRecReq.WebRequestCommon.CorrelationId, genderUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint GenderUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(genderUpdRecReq));

                resp.Gender = InstManagerAccessPoint.GetNewAccessPoint().GenderUpdRec(genderUpdRecReq.Gender, genderUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Gender != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Gender.Reserved1 != null ? resp.Gender.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.Gender.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = genderUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Gender.Reserved1 != null)
                        resp.Gender = new GenderDto() { RecId = -1 };
                }
                //else
                //{
                //    //
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint GenderUpdRec is completed");

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
                resp.WebResponseCommon.CorrelationId = genderUpdRecReq.WebRequestCommon.CorrelationId;
                resp.Gender = new GenderDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ChannelFindAll(ChannelFindAllReq channelFindAllReq)
        {
            ChannelFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },

                Channel = new List<ChannelDto>()
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
                    resp.WebResponseCommon.CorrelationId = channelFindAllReq == null ? Guid.NewGuid().ToString() :
                        channelFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        channelFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        channelFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        channelFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(channelFindAllReq.WebRequestCommon.CorrelationId, channelFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ChannelFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(channelFindAllReq));

                resp.Channel = InstManagerAccessPoint.GetNewAccessPoint().ChannelFindAll();

                if (resp != null && resp.Channel != null && resp.Channel.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Channel[0].Reserved1 != null ? resp.Channel[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Channel[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId;
                    if (resp.Channel[0].Reserved1 != null)
                        resp.Channel = new List<ChannelDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ChannelFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId;
                resp.Channel = new List<ChannelDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ChannelNewRec(ChannelNewRecReq ChannelNewRecReq)
        {
            ChannelResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Channel = new ChannelDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = ChannelNewRecReq == null ? Guid.NewGuid().ToString() :
                        ChannelNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        ChannelNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        ChannelNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        ChannelNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(ChannelNewRecReq.WebRequestCommon.CorrelationId, ChannelNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ChannelNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(ChannelNewRecReq));

                resp.Channel = InstManagerAccessPoint.GetNewAccessPoint().ChannelNewRec(ChannelNewRecReq.Channel, ChannelNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Channel != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Channel.Reserved1 != null ? resp.Channel.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.Channel.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = ChannelNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Channel.Reserved1 != null)
                        resp.Channel = new ChannelDto() { RecId = -1 };
                }
                //else
                //{
                //    //
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ChannelNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = ChannelNewRecReq.WebRequestCommon.CorrelationId;
                resp.Channel = new ChannelDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ChannelUpdRec(ChannelUpdRecReq channelUpdRecReq)
        {
            ChannelResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Channel = new ChannelDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = channelUpdRecReq == null ? Guid.NewGuid().ToString() :
                            channelUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            channelUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            channelUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            channelUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(channelUpdRecReq.WebRequestCommon.CorrelationId, channelUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ChannelUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(channelUpdRecReq));

                resp.Channel = InstManagerAccessPoint.GetNewAccessPoint().ChannelUpdRec(channelUpdRecReq.Channel, channelUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.Channel != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Channel.Reserved1 != null ? resp.Channel.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.Channel.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = channelUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.Channel.Reserved1 != null)
                        resp.Channel = new ChannelDto() { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ChannelUpdRec is completed");

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
                resp.WebResponseCommon.CorrelationId = channelUpdRecReq.WebRequestCommon.CorrelationId;
                resp.Channel = new ChannelDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult LookupFindAll(LookupFindAllReq lookupFindAllReq)
        {
            LookupFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },

                Channel = new List<ChannelDto>(),
                Gender = new List<GenderDto>(),
                Region = new List<RegionDto>(),
                MaritalStatus = new List<MaritalStatusDto>(),
                Relaion = new List<RelationDto>(),
                ProductClassOfCoverage = new List<ProductClassOfCoverageDto>(),
                StayTripOption = new List<StayTripOptionDto>(),
                TerritorialScope = new List<TerritorialScope>(),
                NetworkLevel = new List<NetworkLevelDto>()
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
                _logger.LogInfo("Calling the Endpoint LookupFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(lookupFindAllReq));

                List<LookupDto> lookupList = InstManagerAccessPoint.GetNewAccessPoint().LookupFindAll();
                if (lookupList != null && lookupList.Count > 0)
                {
                    var list = lookupList.FindAll(e => e.TableName == "t_Channel").ToList();
                    var channelList = new List<ChannelDto>();
                    foreach (var item in list)
                    {
                        channelList.Add(new ChannelDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive,
                            Type = item.Type
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Region").ToList();
                    var regionList = new List<RegionDto>();
                    foreach (var item in list)
                    {
                        regionList.Add(new RegionDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive,
                            IsDefault = item.IsDefault
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Gender").ToList();
                    var genderList = new List<GenderDto>();
                    foreach (var item in list)
                    {
                        genderList.Add(new GenderDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_MaritalStatus").ToList();
                    var maritalStatusList = new List<MaritalStatusDto>();
                    foreach (var item in list)
                    {
                        maritalStatusList.Add(new MaritalStatusDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Relation").ToList();
                    var relationList = new List<RelationDto>();
                    foreach (var item in list)
                    {
                        relationList.Add(new RelationDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_ProductClassOfCoverage").ToList();
                    var productClassOfCoverageList = new List<ProductClassOfCoverageDto>();
                    foreach (var item in list)
                    {
                        productClassOfCoverageList.Add(new ProductClassOfCoverageDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_StayTripOption").ToList();
                    var stayTripOptionList = new List<StayTripOptionDto>();
                    foreach (var item in list)
                    {
                        stayTripOptionList.Add(new StayTripOptionDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_TerritorialScope").ToList();
                    var territorialScopeList = new List<TerritorialScope>();
                    foreach (var item in list)
                    {
                        territorialScopeList.Add(new TerritorialScope
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_ProductDetailsPOI_NetworkLevel").ToList();
                    var netorkLevelList = new List<NetworkLevelDto>();
                    foreach (var item in list)
                    {
                        netorkLevelList.Add(new NetworkLevelDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive,
                            IsDefault = item.IsDefault
                        });
                    }

                    resp.Channel = channelList;
                    resp.Region = regionList;
                    resp.Gender = genderList;
                    resp.MaritalStatus = maritalStatusList;
                    resp.Relaion = relationList;
                    resp.ProductClassOfCoverage = productClassOfCoverageList;
                    resp.StayTripOption = stayTripOptionList;
                    resp.TerritorialScope = territorialScopeList;
                    resp.NetworkLevel = netorkLevelList;
                    //resp.Channel = channelList;
                }
                if (lookupList != null && lookupList.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = lookupList[0].Reserved1 != null ? lookupList[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = lookupList == null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = lookupFindAllReq.WebRequestCommon.CorrelationId;
                    if (lookupList[0].Reserved1 != null)
                    {
                        resp.Channel = new List<ChannelDto>();
                        resp.Gender = new List<GenderDto>();
                        resp.Region = new List<RegionDto>();
                        resp.MaritalStatus = new List<MaritalStatusDto>();
                        resp.Relaion = new List<RelationDto>();
                        resp.ProductClassOfCoverage = new List<ProductClassOfCoverageDto>();
                        resp.StayTripOption = new List<StayTripOptionDto>();
                        resp.TerritorialScope = new List<TerritorialScope>();
                        resp.NetworkLevel = new List<NetworkLevelDto>();
                    }
                }

                else
                {
                    //resp.
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint LookupFindAll is completed");

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
        //[AuthorizeAttribute]
        public IActionResult LeadLookupFindAll(LeadLookupFindAllReq leadLookupFindAllReq)
        {
            LeadLookupFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },

                LeadSale = new List<LeadSaleDto>(),
                LeadSource = new List<LeadSourceDto>(),
                LeadStatus = new List<LeadStatusDto>(),
                Region = new List<RegionDto>()
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
                    resp.WebResponseCommon.CorrelationId = leadLookupFindAllReq == null ? Guid.NewGuid().ToString() :
                        leadLookupFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        leadLookupFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        leadLookupFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        leadLookupFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(leadLookupFindAllReq.WebRequestCommon.CorrelationId, leadLookupFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint LeadLookupFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(leadLookupFindAllReq));

                List<LeadLookupDto> lookupList = InstManagerAccessPoint.GetNewAccessPoint().LeadLookupFindAll();
                if (lookupList != null && lookupList.Count > 0)
                {
                    var list = lookupList.FindAll(e => e.TableName == "t_LeadSale").ToList();
                    var leadSaleList = new List<LeadSaleDto>();
                    foreach (var item in list)
                    {
                        leadSaleList.Add(new LeadSaleDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_LeadSource").ToList();
                    var leadSourceList = new List<LeadSourceDto>();
                    foreach (var item in list)
                    {
                        leadSourceList.Add(new LeadSourceDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive,
                            IsDefault = item.IsDefault
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_LeadStatus").ToList();
                    var leadStatusList = new List<LeadStatusDto>();
                    foreach (var item in list)
                    {
                        leadStatusList.Add(new LeadStatusDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Region").ToList();
                    var regionList = new List<RegionDto>();
                    foreach (var item in list)
                    {
                        regionList.Add(new RegionDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = item.IsActive
                        });
                    }

                    resp.LeadSale = leadSaleList;
                    resp.LeadSource = leadSourceList;
                    resp.LeadStatus = leadStatusList;
                    resp.Region = regionList;
                    //resp.Channel = channelList;
                }
                if (lookupList != null && lookupList.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = lookupList[0].Reserved1 != null ? lookupList[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = lookupList == null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = leadLookupFindAllReq.WebRequestCommon.CorrelationId;
                    if (lookupList[0].Reserved1 != null)
                    {
                        resp.LeadSale = new List<LeadSaleDto>();
                        resp.LeadSource = new List<LeadSourceDto>();
                        resp.LeadStatus = new List<LeadStatusDto>();
                        resp.Region = new List<RegionDto>();
                    }
                }

                else
                {
                    //resp.
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint LeadLookupFindAll is completed");

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
                resp.WebResponseCommon.CorrelationId = leadLookupFindAllReq.WebRequestCommon.CorrelationId;
                //resp.Lookup = new List<LookupDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult MaritalStatusFindAll(MaritalStatusFindAllReq maritalStatusFindAllReq)
        {
            MaritalStatusFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                MaritalStatus = new List<MaritalStatusDto>()
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
                    resp.WebResponseCommon.CorrelationId = maritalStatusFindAllReq == null ? Guid.NewGuid().ToString() :
                        maritalStatusFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        maritalStatusFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        maritalStatusFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        maritalStatusFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(maritalStatusFindAllReq.WebRequestCommon.CorrelationId, maritalStatusFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint MaritalStatusFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(maritalStatusFindAllReq));
                resp.MaritalStatus = InstManagerAccessPoint.GetNewAccessPoint().MaritalStatusFindAll();

                if (resp != null && resp.MaritalStatus != null && resp.MaritalStatus.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.MaritalStatus[0].Reserved1 != null ? resp.MaritalStatus[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.MaritalStatus[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = maritalStatusFindAllReq.WebRequestCommon.CorrelationId;
                    if (resp.MaritalStatus[0].Reserved1 != null)
                        resp.MaritalStatus = new List<MaritalStatusDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint MaritalStatusFindAll is completed");
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
                resp.WebResponseCommon.CorrelationId = maritalStatusFindAllReq.WebRequestCommon.CorrelationId;
                resp.MaritalStatus = new List<MaritalStatusDto>();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult MaritalStatusNewRec(MaritalStatusNewRecReq maritalStatusNewRecReq)
        {
            MaritalStatusResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                MaritalStatus = new MaritalStatusDto() { RecId = -1 }
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
                    resp.WebResponseCommon.CorrelationId = maritalStatusNewRecReq == null ? Guid.NewGuid().ToString() :
                        maritalStatusNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        maritalStatusNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        maritalStatusNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        maritalStatusNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(maritalStatusNewRecReq.WebRequestCommon.CorrelationId, maritalStatusNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint MaritalStatusNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(maritalStatusNewRecReq));
                resp.MaritalStatus = InstManagerAccessPoint.GetNewAccessPoint().MaritalStatusNewRec(maritalStatusNewRecReq.MaritalStatus, maritalStatusNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.MaritalStatus != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.MaritalStatus.Reserved1 != null ? resp.MaritalStatus.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.MaritalStatus.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = maritalStatusNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.MaritalStatus.Reserved1 != null)
                        resp.MaritalStatus = new MaritalStatusDto() { RecId = -1 };
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
                _logger.LogInfo("Calling the Endpoint MaritalStatusNewRec is completed");

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
                resp.WebResponseCommon.CorrelationId = maritalStatusNewRecReq.WebRequestCommon.CorrelationId;
                resp.MaritalStatus = new MaritalStatusDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult MaritalStatusUpdRec(MaritalStatusUpdRecReq maritalStatusUpdRecReq)
        {
            MaritalStatusResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                MaritalStatus = new MaritalStatusDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = maritalStatusUpdRecReq == null ? Guid.NewGuid().ToString() :
                            maritalStatusUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            maritalStatusUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            maritalStatusUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            maritalStatusUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(maritalStatusUpdRecReq.WebRequestCommon.CorrelationId, maritalStatusUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint MaritalStatusUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(maritalStatusUpdRecReq));
                resp.MaritalStatus = InstManagerAccessPoint.GetNewAccessPoint().MaritalStatusUpdRec(maritalStatusUpdRecReq.MaritalStatus, maritalStatusUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.MaritalStatus != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.MaritalStatus.Reserved1 != null ? resp.MaritalStatus.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.MaritalStatus.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = maritalStatusUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.MaritalStatus.Reserved1 != null)
                        resp.MaritalStatus = new MaritalStatusDto { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint MaritalStatusUpdRec is completed");

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
                resp.WebResponseCommon.CorrelationId = maritalStatusUpdRecReq.WebRequestCommon.CorrelationId;
                resp.MaritalStatus = new MaritalStatusDto() { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        //[HttpPost]
        //[AuthorizeAttribute]
        //public IActionResult AF1BL80NewRec(AF1BL80NewRecReq aF1BL80NewRecReq)
        //{
        //    AF1BL80Resp resp;
        //    resp = new()
        //    {
        //        WebResponseCommon = new()
        //        {
        //        },
        //        AF1BL80 = new CAL.DTO.AF1BL80Dto() { RecId = -1 }
        //    };
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
        //            resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage));
        //            resp.WebResponseCommon.CorrelationId = aF1BL80NewRecReq == null ? Guid.NewGuid().ToString() :
        //                 aF1BL80NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
        //                 aF1BL80NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

        //            return Ok(resp);
        //        }
        //        _logger.SetCorrelationId(aF1BL80NewRecReq.WebRequestCommon.CorrelationId, aF1BL80NewRecReq.WebRequestCommon.UserName);
        //        _logger.LogInfo("Calling the Endpoint AF1BL80NewRec is started");
        //        _logger.LogDebug(JsonConvert.SerializeObject(aF1BL80NewRecReq));

        //        resp.AF1BL80 = InstManagerAccessPoint.GetNewAccessPoint().AF1BL80NewRec(aF1BL80NewRecReq.AF1BL80, aF1BL80NewRecReq.WebRequestCommon.UserName);

        //        if (resp != null)// && resp.Region.Count == 1)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnMessage = resp.AF1BL80.Reserved1 != null ? resp.AF1BL80.Reserved1 : "New record created";
        //            resp.WebResponseCommon.ReturnCode = resp.AF1BL80.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
        //            resp.WebResponseCommon.CorrelationId = aF1BL80NewRecReq.WebRequestCommon.CorrelationId;
        //            if (resp.AF1BL80.Reserved1 != null)
        //                resp.AF1BL80 = new CAL.DTO.AF1BL80Dto() { RecId = -1 };
        //        }
        //        else
        //        {
        //            //
        //        }
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));

        //        _logger.LogInfo("Calling the Endpoint AF1BL80NewRec is completed");

        //        return Ok(resp);
        //        // UserCredDao t = new UserCredDao();
        //        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error", ex);
        //        resp.WebResponseCommon.SuccessIndicator = "Error";
        //        resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
        //        resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
        //        resp.WebResponseCommon.CorrelationId = aF1BL80NewRecReq.WebRequestCommon.CorrelationId;
        //        resp.AF1BL80 = new CAL.DTO.AF1BL80Dto() { RecId = -1 };
        //        //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
        //        return Ok(resp);
        //    }
        //}
    }
}
