using Evaluation.UIL.Cross.Cutting;
using Evaluation.UIL.Request;
using Evaluation.UIL.Response;
using Evaluation.UIL.Wrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Dynamic;
using System.IO;
using System.Net;

namespace Evaluation.UIL.Consume.Api
{
    public static class ApiService
    {
        public static UserResp CheckUserCred(UserCredReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/CheckUserCred";

                var result = HttpClientHelper.CallRestClient(url, "POST", request);
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
                Logger.Error(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        public static UserResp IsUserAvailable(UserSignedReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/IsUserAvailable";

                var result = HttpClientHelper.CallRestClient(url, "POST", request);
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
                Logger.Error(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        public static UserResp RegisterUser(UserRegisterReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/RegisterUser";

                var result = HttpClientHelper.CallRestClient(url, "POST", request);
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
                Logger.Error(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        public static UserResp UpdateUserPassword(UserChangePasswordReq request)
        {
            var resp = new UserResp();
            try
            {
                var url = Global.WebApiBaseUrl + "Login/UpdateUserPassword";

                var result = HttpClientHelper.CallRestClient(url, "POST", request);
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
                Logger.Error(string.Empty, ex);
                //resp.HttpStatus = HttpStatusCode.ExpectationFailed;
                //resp.Message = ex.Message;
                //resp.MessageSource = ex.ToString();
            }

            return resp;
        }

        private static dynamic HandleHttpResponse(WebException ex)
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
                Logger.Error(string.Empty, ex);
                resp.HttpStatus = HttpStatusCode.RequestTimeout;
                resp.Message = ex.Message;
                resp.MessageSource = ex.ToString();
            }

            return resp;
        }
    }
}
