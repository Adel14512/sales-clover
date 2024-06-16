using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request;
using Evaluation.UI.Request.Global;
using Evaluation.UI.Response;
using Evaluation.UI.Response.Global;
using Evaluation.UI.Wrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Dynamic;
using System.IO;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public  class ApiService : IApiService
    {

        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        public ApiService(IHttpClientHelper httpClientHelper, ILoggerManager logger, IConfiguration configuration )
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _configuration = configuration;
        }
        public UserResp CheckUserCred(UserCredReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/CheckUserCred";

                var result = _httpClientHelper.CallRestClient(url, "POST", request);
                resp = JsonConvert.DeserializeObject<UserResp>(result);
                //resp.HttpStatus = HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                var response = HandleHttpResponse(ex);
                if (response != null)
                {
                    //resp.HttpStatus = response.HttpStatus;
                    //resp.Message = response.Message;
                    //resp.MessageSource = response.MessageSource;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        public  UserResp IsUserAvailable(UserSignedReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/IsUserAvailable";

                var result = _httpClientHelper.CallRestClient(url, "POST", request);
                resp = JsonConvert.DeserializeObject<UserResp>(result);
                //resp.HttpStatus = HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                var response = HandleHttpResponse(ex);
                if (response != null)
                {
                    //resp.HttpStatus = response.HttpStatus;
                    //resp.Message = response.Message;
                    //resp.MessageSource = response.MessageSource;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        public  UserResp RegisterUser(UserRegisterReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/RegisterUser";

                var result = _httpClientHelper.CallRestClient(url, "POST", request);
                resp = JsonConvert.DeserializeObject<UserResp>(result);
                //resp.HttpStatus = HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                var response = HandleHttpResponse(ex);
                if (response != null)
                {
                    //resp.HttpStatus = response.HttpStatus;
                    //resp.Message = response.Message;
                    //resp.MessageSource = response.MessageSource;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        public  UserResp UpdateUserPassword(UserChangePasswordReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/UpdateUserPassword";

                var result = _httpClientHelper.CallRestClient(url, "POST", request);
                resp = JsonConvert.DeserializeObject<UserResp>(result);
                //resp.HttpStatus = HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                var response = HandleHttpResponse(ex);
                if (response != null)
                {
                    //resp.HttpStatus = response.HttpStatus;
                    //resp.Message = response.Message;
                    //resp.MessageSource = response.MessageSource;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        public dynamic HandleHttpResponse(WebException ex)
        {
            dynamic resp = new ExpandoObject();
            try
            {
                var stream = ex.Response.GetResponseStream();
                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        resp.HttpStatus = HttpStatusCode.Unauthorized;
                        //resp.Message = Constants.UNAUTHORIZEDMESSAGE;
                        resp.MessageSource = ex.ToString();
                        break;

                    case HttpStatusCode.BadRequest:
                        resp.HttpStatus = HttpStatusCode.BadRequest;
                        //resp.Message = Constants.BADREQUESTMESSAGE;
                        resp.MessageSource = ex.ToString();
                        break;
                    case HttpStatusCode.NotFound:
                        using (var reader = new StreamReader(stream))
                        {
                            var stm = reader.ReadToEnd();
                            resp.HttpStatus = HttpStatusCode.NotFound;
                            resp.Message = stm;
                            resp.MessageSource = ex.ToString();
                        }

                        break;
                    default:
                        using (var reader = new StreamReader(stream))
                        {
                            var stm = reader.ReadToEnd();
                            var excpt = JObject.Parse(stm);
                            var message = excpt["Message"].ToString();
                            resp.HttpStatus = HttpStatusCode.InternalServerError;
                            resp.Message = message.Split(new[] { "(|)" }, StringSplitOptions.None).GetValue(0).ToString();
                            resp.MessageSource = message.Split(new[] { "(|)" }, StringSplitOptions.None).GetValue(1).ToString();
                        }

                        break;
                }
            }
            catch
            {
                _logger.LogError(string.Empty, ex);
                resp.HttpStatus = HttpStatusCode.RequestTimeout;
                resp.Message = ex.Message;
                resp.MessageSource = ex.ToString();
            }

            return resp;
        }
     
    }

}
