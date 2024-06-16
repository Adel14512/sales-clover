using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Wrapper;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace Evaluation.UI.Cross.Cutting
{
    /// <summary>
    /// The http client helper class.
    /// </summary>
    public class HttpClientHelper : IHttpClientHelper
    {

        private readonly ILoggerManager _logger;
        public HttpClientHelper(ILoggerManager logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Call the rest client.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="methodType">The methodType.</param>
        /// <param name="body">The body parameter.</param>
        /// <returns>The <see cref="string"/> value.</returns>
        public string CallRestClient(string url, string methodType, object body = null)
        {
            string result = null;

            var requestBody = string.Empty;
            if (body != null)
            {
                requestBody = JsonConvert.SerializeObject(body);
            }

            result = RestCall(requestBody, url, "application / json", methodType);
            return result;
        }

        /// <summary>
        /// Call the rest web api client.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="methodType">The methodType.</param>
        /// <param name="body">The body.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string CallRestWebApiClient(string url, string methodType, object body = null)
        {
            string result = null;

            var requestBody = string.Empty;
            if (body != null)
            {
                requestBody = JsonConvert.SerializeObject(body);
            }

            result = RestWebApiCall(requestBody, url, "application/json", methodType);
            return result;
        }

        /// <summary>
        /// The rest web api call.
        /// </summary>
        /// <param name="jsonBody">The jsonBody.</param>
        /// <param name="url">The url.</param>
        /// <param name="contentType">The contentType.</param>
        /// <param name="methodType">The methodType.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string RestWebApiCall(string jsonBody, string url, string contentType, string methodType)
        {
            var result = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = methodType;
            var encoding = new System.Text.UTF8Encoding();
            var byteArray = encoding.GetBytes(jsonBody);
            httpWebRequest.ContentLength = byteArray.Length;
            httpWebRequest.ContentType = contentType;

            using (var dataStream = httpWebRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            _logger.LogInfo("Calling web client");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            _logger.LogInfo("Reading response");
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")))
            {
                result = streamReader.ReadToEnd();
            }

            _logger.LogInfo("Reading response completed");
            return result;
        }

        /// <summary>
        /// The rest call.
        /// </summary>
        /// <param name="jsonBody">The jsonBody.</param>
        /// <param name="url">The url.</param>
        /// <param name="contentType">The contentType.</param>
        /// <param name="methodType">The methodType.</param>
        /// <returns>The <see cref="string"/> value .</returns>
        private string RestCall(string jsonBody, string url, string contentType, string methodType)
        {
            var result = string.Empty;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = methodType;
            ////httpWebRequest.Headers["Authorization"] = string.Empty;
            if (!string.IsNullOrEmpty(jsonBody))
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = jsonBody;
                    streamWriter.Write(jsonBody);
                    streamWriter.Flush();
                    ////streamWriter.Close();
                }
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
        public async Task<List<T>> PostApiRequestAsync<T>(object requestBody, string apiUrl, CancellationToken ct)
        {
            using (var httpClient = new HttpClient())
            {
                // Serialize the request body to JSON
                var requestBodyJson = JsonConvert.SerializeObject(requestBody);

                // Create the request content
                var requestContent = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");
                LoggingToCorrelationId(requestBody);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL77NewRec is started");
                _logger.LogDebug(requestBodyJson);
                // Make the POST request
                var response = await httpClient.PostAsync(apiUrl, requestContent, ct);

                // Get the response body as a string
                var responseBody = await response.Content.ReadAsStringAsync(ct);

                // Deserialize the response body to the specified type
                var responseObj = JsonConvert.DeserializeObject<List<T>>(responseBody);
                _logger.LogDebug(JsonConvert.SerializeObject(responseObj));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL77NewRec is completed");
                // Return the deserialized object
                return responseObj;
            }
        }

        private void LoggingToCorrelationId(object requestBody)
        {
            // Get the type of the requestBody object
            var requestBodyType = requestBody.GetType();

            // Get the WebRequestCommon property using reflection
            var webRequestCommonProperty = requestBodyType.GetProperty("WebRequestCommon");

            // Check if the property exists and is not null
            if (webRequestCommonProperty != null && webRequestCommonProperty.GetValue(requestBody) != null)
            {
                try
                {
                    // Get the value of the CorrelationId property using reflection
                    var correlationIdProperty = webRequestCommonProperty.PropertyType.GetProperty("CorrelationId");
                    //var correlationIdValue = correlationIdProperty?.GetValue(webRequestCommonProperty.GetValue(requestBody));

                    //// Get the value of the UserName property using reflection
                    //var userNameProperty = webRequestCommonProperty.PropertyType.GetProperty("UserName");
                    //var userNameValue = userNameProperty?.GetValue(webRequestCommonProperty.GetValue(requestBody));

                    // Use the values as needed
                    //_logger.SetCorrelationId(correlationIdValue?.ToString(), userNameValue?.ToString());

                    var correlationIdValue = ((Evaluation.UI.Request.GenericEmptyReq)requestBody).WebRequestCommon.CorrelationId;
                    var userNameValue = ((Evaluation.UI.Request.GenericEmptyReq)requestBody).WebRequestCommon.UserName;
                    _logger.SetCorrelationId(correlationIdValue?.ToString(), userNameValue?.ToString());
                }
                catch (Exception ex)
                {

                }

            }
        }

        public async Task<T> PostApiRequestModelAsync<T>(object requestBody, string apiUrl, CancellationToken ct)
        {
            using (var httpClient = new HttpClient())
            {
                // Serialize the request body to JSON
                var requestBodyJson = JsonConvert.SerializeObject(requestBody);

                // Create the request content
                var requestContent = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");
                LoggingToCorrelationId(requestBody);
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL77NewRec is started");
                _logger.LogDebug(requestBodyJson);
                // Make the POST request
                var response = await httpClient.PostAsync(apiUrl, requestContent, ct);

                // Get the response body as a string
                var responseBody = await response.Content.ReadAsStringAsync(ct);

                // Deserialize the response body to the specified type
                var responseObj = JsonConvert.DeserializeObject<T>(responseBody);
                var responseOb1j = JsonConvert.DeserializeObject<object>(responseBody);

                _logger.LogDebug(JsonConvert.SerializeObject(responseBody));
                _logger.LogInfo("Calling the Endpoint SalesTransactionBL77NewRec is completed");

                // Return the deserialized object
                return responseObj;
            }
        }

    }
}