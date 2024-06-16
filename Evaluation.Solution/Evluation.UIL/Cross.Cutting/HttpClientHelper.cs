using Evaluation.UIL.Wrapper;
using Newtonsoft.Json;
using System.IO;
using System.Net;


namespace Evaluation.UIL.Cross.Cutting
{
    /// <summary>
    /// The http client helper class.
    /// </summary>
    public class HttpClientHelper
    {
        /// <summary>
        /// Call the rest client.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="methodType">The methodType.</param>
        /// <param name="body">The body parameter.</param>
        /// <returns>The <see cref="string"/> value.</returns>
        public static string CallRestClient(string url, string methodType, object body = null)
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
        public static string CallRestWebApiClient(string url, string methodType, object body = null)
        {
            string result = null;

            var requestBody = string.Empty;
            if (body != null)
            {
                requestBody = JsonConvert.SerializeObject(body);
            }

            result = RestWebApiCall(requestBody, url, "application / json", methodType);
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
        private static string RestWebApiCall(string jsonBody, string url, string contentType, string methodType)
        {
            var result = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = methodType;
            var encoding = new System.Text.UTF8Encoding();
            var byteArray = encoding.GetBytes(jsonBody);
            httpWebRequest.ContentLength = byteArray.Length;
            httpWebRequest.ContentType = @"application/json";

            using (var dataStream = httpWebRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            Logger.Info("Calling web client");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Logger.Info("Reading response");
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")))
            {
                result = streamReader.ReadToEnd();
            }

            Logger.Info("Reading response completed");
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
        private static string RestCall(string jsonBody, string url, string contentType, string methodType)
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
    }
}