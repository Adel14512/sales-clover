using AutoMapper;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Response;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Evaluation.UI.Controllers
{

    public class ContactController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGeneralListApi _generalListApi;
        private readonly IContactApi _contactApi;
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IUserApi _userApi;
        public ContactController(IConfiguration configuration, IGeneralListApi generalListApi, IHttpClientHelper httpClientHelper, IContactApi contactApi, IUserApi userApi)
        {
            _configuration = configuration;
            _generalListApi = generalListApi;
            _httpClientHelper = httpClientHelper;
            _contactApi = contactApi;
            _userApi = userApi;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Search()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> WideSearch()
        {
            return View();
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Search(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);

            ContactSearchReq requestBody = JsonConvert.DeserializeObject<ContactSearchReq>(keyValues["contact"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;

            ContactSearchResp contactSearchResp = new ContactSearchResp();
            using (var httpClient = new HttpClient())
            {
                // Set the API endpoint URL
                string apiUrl = _configuration["ApiURL"];

                if (requestBody.IsWideSearch)
                {
                    apiUrl = apiUrl + "api/Contact/ContactFindWithAnyValue";
                }
                else
                {
                    apiUrl = apiUrl + "api/Contact/ContactFindWithAnyFilter";
                }

                // Serialize the request body to JSON
                var requestBodyJson = JsonConvert.SerializeObject(requestBody);

                // Create the request content
                var requestContent = new StringContent(requestBodyJson, System.Text.Encoding.UTF8, "application/json");

                // Make the POST request
                var response = await httpClient.PostAsync(apiUrl, requestContent, ct);

                // Get the response body as a string
                var responseBody = await response.Content.ReadAsStringAsync(ct);

                contactSearchResp = JsonConvert.DeserializeObject<ContactSearchResp>(responseBody);
                // Print the response body to the console
                //Console.WriteLine(responseBody);

            }
            return Ok(contactSearchResp);
        }
        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactController/Create
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Create(CancellationToken ct)
        {
            ContactVM contactVM = new ContactVM();
            GenericEmptyReq request = new GenericEmptyReq();
            var user = await _userApi.GetUserClaims(User.Claims);
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            contactVM.Genders = result.gender;
            contactVM.Regions = result.region;
            contactVM.Channels = result.channel;
            return View(contactVM);
        }

        // POST: ContactController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Create(IFormCollection keyValues, CancellationToken ct)
        {
            ContactCreateReq requestBody = JsonConvert.DeserializeObject<ContactCreateReq>(keyValues["contact"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _contactApi.CreateContactApi(requestBody, ct);
            return Ok(result);
        }

        // GET: ContactController/Edit/5
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Edit(int id, CancellationToken ct)
        {
            ContactVM contactVM = new ContactVM();

            GenericIdReq request2 = new GenericIdReq();
            request2.recId = id;
            contactVM = await _contactApi.GetContactByIDApi(request2, ct);
            

            GenericEmptyReq request = new GenericEmptyReq();
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            contactVM.Genders = result.gender;
            contactVM.Regions = result.region;
            contactVM.Channels = result.channel;



            return View(contactVM);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormCollection collection,CancellationToken ct)
        {
            ContactCreateReq requestBody = JsonConvert.DeserializeObject<ContactCreateReq>(collection["contact"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _contactApi.EditContactApi(requestBody, ct);
            return Ok(result);
        }


        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
