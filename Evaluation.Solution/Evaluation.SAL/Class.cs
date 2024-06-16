using Evaluation.CAL.DTO.Kyc;
using static Evaluation.CAL.Class1;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System;

namespace Evaluation.SAL
{
    public class Class
    {
        //public async void ValidateKyc(KycDto kyc)
        //{
        //    // Replace these values with your actual API endpoint URL, credentials, and POST data
        //    string apiUrl = "https://localhost:7074/api/ValidateKyc/ShuftiPro";
        //    //string username = "8yr1U3aZVw1hj7IrZPAwPxOCXKRDLFmy1EpQw7uxXpkFrAOm691668524833";
        //    //string password = "7xBPps6tHGmrPCEj7psgcLRFvudNulNd";

        //    #region MyRequest
        //    KycReq1 data = new KycReq1
        //    {
        //        reference = "121017413001",
        //        country = "LB",
        //        dob = "",
        //        email = "",
        //        first_name = "WALID",
        //        language = "EN",
        //        last_name = "BADAOUI",
        //        middle_name = ""

        //    };
        //    #endregion


        //    // Serialize the data object to JSON format
        //    string jsonData = System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = false });
        //    VerificationResponse res = new VerificationResponse();
        //    // Create an instance of HttpClient
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            // Convert the username and password to Base64
        //            //string base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

        //            // Set the Authorization header with the basic authentication credentials
        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");

        //            // Set the content type
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            // Create the HttpContent for the POST data
        //            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //            // Make a POST request to the API
        //            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

        //            // Check if the request was successful
        //            //if (response.IsSuccessStatusCode)
        //            //{
        //            // Read the response content as a string
        //            //string responseData = await response.Content.ReadAsStringAsync();

        //            if (response.IsSuccessStatusCode)
        //            {
        //                // Read the response content as a string
        //                string responseData = await response.Content.ReadAsStringAsync();
        //                res = System.Text.Json.JsonSerializer.Deserialize<VerificationResponse>(responseData);
        //                // Process the response data as needed
        //                //Console.WriteLine(responseData);

        //                status = res.@event;
        //            }
        //            else
        //            {
        //                //Console.WriteLine("Error: Failed to post data to the API. Status code: " + response.StatusCode);
        //                string responseData = await response.Content.ReadAsStringAsync();
        //                res = System.Text.Json.JsonSerializer.Deserialize<VerificationResponse>(responseData);
        //                status = res.@event;
        //            }
        //            //return "";
        //            // Process the response data as needed
        //            //Console.WriteLine(res);
        //            //}
        //            //else
        //            //{
        //            //    Console.WriteLine("Error: Failed to post data to the API. Status code: " + response.Content.ToString());
        //            //}

        //        }

        //        catch (Exception ex)
        //        {
        //            //Console.WriteLine("Error: " + ex.Message);
        //        }
        //    }
        //}
    }
}
