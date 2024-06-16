using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL010602;
using Evaluation.CAL.DTO.BL010602Consolidation;
using Evaluation.CAL.DTO.Kyc;
using Evaluation.CAL.Request.BL010602Consolidation;
using Evaluation.CAL.Request.Kyc;
using Evaluation.CAL.Response.BL010602Consolidation;
using Evaluation.CAL.Response.Kyc;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using static Evaluation.CAL.Class1;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Evaluation.CAL;
using System.Text.Json;
using Evaluation.SAL;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KycController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        string status = string.Empty;
        string declinedReason = string.Empty;
        public KycController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> ClientFindAll(ClientReq clientReq)
        {
            KycResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Kyc = new List<KycDto>()
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
                    resp.WebResponseCommon.CorrelationId = clientReq == null ? Guid.NewGuid().ToString() :
                        clientReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        clientReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        clientReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        clientReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(clientReq.WebRequestCommon.CorrelationId, clientReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ClientFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(clientReq));
                resp.Kyc = InstManagerAccessPoint.GetNewAccessPoint().ClientFindAll();

                foreach (var kyc in resp.Kyc)
                {
                    status = string.Empty;
                    declinedReason = string.Empty;
                    await ValidateKyc(kyc);
                    InstManagerAccessPoint.GetNewAccessPoint().KycUpd(kyc.ShuftiReference, status, declinedReason);
                }

                if (resp != null && resp.Kyc != null && resp.Kyc.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Kyc[0].Reserved1 != null ? resp.Kyc[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Kyc[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = clientReq.WebRequestCommon.CorrelationId;
                    if (resp.Kyc[0].Reserved1 != null)
                        resp.Kyc = new List<KycDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ClientFindAll is completed");
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
                resp.WebResponseCommon.CorrelationId = clientReq.WebRequestCommon.CorrelationId;
                resp.Kyc = new List<KycDto>();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        private async Task ValidateKyc(KycDto kyc)
        {
            // Replace these values with your actual API endpoint URL, credentials, and POST data
            string apiUrl = "https://localhost:7074/api/ValidateKyc/ShuftiPro";
            //string username = "8yr1U3aZVw1hj7IrZPAwPxOCXKRDLFmy1EpQw7uxXpkFrAOm691668524833";
            //string password = "7xBPps6tHGmrPCEj7psgcLRFvudNulNd";

            #region MyRequest
            KycReq data = new KycReq
            {
                reference = kyc.ShuftiReference,
                country = kyc.Country,
                dob = kyc.DOB,
                email = kyc.Email,
                first_name = kyc.FirstName,
                language = kyc.Language,
                last_name = kyc.LastName,
                middle_name = kyc.MiddleName

            };
            #endregion


            // Serialize the data object to JSON format
            string jsonData = System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = false });
            VerificationResponse res = new VerificationResponse();
            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Convert the username and password to Base64
                    //string base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

                    // Set the Authorization header with the basic authentication credentials
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");

                    // Set the content type
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create the HttpContent for the POST data
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Make a POST request to the API
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Check if the request was successful
                    //if (response.IsSuccessStatusCode)
                    //{
                    // Read the response content as a string
                    //string responseData = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseData = await response.Content.ReadAsStringAsync();
                        res = System.Text.Json.JsonSerializer.Deserialize<VerificationResponse>(responseData);
                        // Process the response data as needed
                        //Console.WriteLine(responseData);

                        status = res.@event;
                        declinedReason = res.declined_reason;
                    }
                    else
                    {
                        //Console.WriteLine("Error: Failed to post data to the API. Status code: " + response.StatusCode);
                        string responseData = await response.Content.ReadAsStringAsync();
                        res = System.Text.Json.JsonSerializer.Deserialize<VerificationResponse>(responseData);
                        status = res.@event;
                        declinedReason = res.declined_reason;
                    }
                    //return "";
                    // Process the response data as needed
                    //Console.WriteLine(res);
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Error: Failed to post data to the API. Status code: " + response.Content.ToString());
                    //}

                }

                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
