using Evaluation.UI.Response.BL030904;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL010602;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Request.BL030904;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL051807;
using Evaluation.UI.Request.BL080501;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Request.BL291908;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL311703;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Request.BL77;
using Evaluation.UI.Response.BL010602;
using Evaluation.UI.Response.BL021502;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL051807;
using Evaluation.UI.Response.BL080501;
using Evaluation.UI.Response.BL281609;
using Evaluation.UI.Response.BL291908;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Response.BL311703;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Util;
using Evaluation.UI.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Evaluation.UI.Request.Global;
using Evaluation.UI.Request.BL090703;
using Evaluation.UI.Response.BL090703;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Request.BL061005;
using Evaluation.UI.Response.BL061005;
using Evaluation.UI.Consume.Api;
using Evaluation.UI.Response.Product;
using Evaluation.UI.Request.Product;

namespace Evaluation.UI.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IGeneralListApi _generalListApi;
        private readonly ITransactionApi _transactionApi;
        private readonly IContactApi _contactApi;
        private readonly ILoggerManager _logger;
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly IProductApi _productApi;

        public BusinessController(IGeneralListApi generalListApi, ITransactionApi transactionApi, IContactApi contactApi, IGlobal global, IUserApi userApi, IProductApi productApi)
        {
            _generalListApi = generalListApi;
            _transactionApi = transactionApi;
            _contactApi = contactApi;
            _global = global;
            _userApi = userApi;
            _productApi = productApi;
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> BL77(string id, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 2);
            BL77VM bl77 = new BL77VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            //if(countrnx != null && countrnx != 0)
            //if (Convert.ToInt32(paramDecode[4]) != null && Convert.ToInt32(paramDecode[4]) != 0)
            //{
            //SalesTransactionBL77FindWithColFilterReq salesTransactionBL77FindWithColFilterReq = new SalesTransactionBL77FindWithColFilterReq();
            //salesTransactionBL77FindWithColFilterReq.ContactId = Convert.ToInt32(paramDecode[0]);
            ////salesTransactionBL77FindWithColFilterReq.ContactId = contactId;
            ////salesTransactionBL77FindWithColFilterReq.BusinessLineId = businessline;
            //salesTransactionBL77FindWithColFilterReq.BusinessLineCode = paramDecode[3];
            //SalesTransactionBL77RecResp salesTransactionBL77RecResp = await _transactionApi.GetBl77(salesTransactionBL77FindWithColFilterReq, ct);
            //bl77.SalesTransactionBL77Dto = salesTransactionBL77RecResp.SalesTransactionBL77;
            // }

            GenericEmptyReq request = new GenericEmptyReq();
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            bl77.Genders = result.gender;
            bl77.Regions = result.region;
            bl77.Channels = result.channel;
            bl77.MaritalStatuses = result.maritalStatus;
            bl77.ContactVM = contactVM;

            return View(bl77);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateBL77(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL77NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL77NewRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateBl77(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditBL77(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL77UpdRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL77UpdRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateBl77(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_8(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_8VM aF1_8VM = new AF1_8VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL080501FindAF1WithRecIdFilterReq req = new SalesTransactionBL080501FindAF1WithRecIdFilterReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL080501Resp resp = await _transactionApi.GetAf8(req, ct);
                aF1_8VM.AF1BL080501Dtco = resp.SalesTransactionBL080501.AF1BL080501;
                aF1_8VM.MasterId = resp.SalesTransactionBL080501.MasterId;
                aF1_8VM.ClientId = resp.SalesTransactionBL080501.ClientId;
            }

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            var result1 = await _generalListApi.GetGlobalLookupFindAll(req1, ct);

            
            aF1_8VM.Genders = result.gender;
            aF1_8VM.Regions = result.region;
            aF1_8VM.Relations = result.Relaion;
            aF1_8VM.MaritalStatuses = result.maritalStatus;
            aF1_8VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_8VM.ContactVM = contactVM;
            aF1_8VM.NetworkLevel = result.NetworkLevel;
            aF1_8VM.Clients = result1.Client;
            aF1_8VM.Masters = result1.Master;
            return View(aF1_8VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_8(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL080501NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL080501NewRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAf8(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_8Consolidation(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL080501UpdGlobalRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL080501UpdGlobalRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.EditAf8Consolidation(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_30Consolidation(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL301401UpdGlobalRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL301401UpdGlobalRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.EditAF30Consolidation(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_33Consolidation(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL331211UpdGlobalRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211UpdGlobalRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.EditAf33Consolidation(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        public async Task<IActionResult> EditAF1_04Consolidation(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL041312UpdGlobalRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312UpdGlobalRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.EditAF04Consolidation(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_32Consolidation(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL321110UpdGlobalRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110UpdGlobalRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.EditAf32Consolidation(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_8(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL080501UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL080501UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAf8(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_30(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_30VM aF1_30VM = new AF1_30VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL301401FindAF1WithRecIdReq req = new SalesTransactionBL301401FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL301401Resp resp = await _transactionApi.GetAf30(req, ct);
                aF1_30VM.SalesTransactionBL301401Dto = resp.SalesTransactionBL301401;
            }
            else
            {

                aF1_30VM.SalesTransactionBL301401Dto = new DTO.BL301401.SalesTransactionBL301401Dto();
                aF1_30VM.SalesTransactionBL301401Dto.AF1BL301401 = new List<DTO.BL301401.AF1BL301401Dto>();
            }
            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_30VM.Genders = result.gender;
            aF1_30VM.Regions = result.region;
            aF1_30VM.Relations = result.Relaion;
            aF1_30VM.MaritalStatuses = result.maritalStatus;
            aF1_30VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_30VM.ContactVM = contactVM;
            aF1_30VM.NetworkLevel = result.NetworkLevel;
            return View(aF1_30VM);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_30(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL301401NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL301401NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_30(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_30(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL301401UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL301401UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAf30(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_32(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_32VM aF1_30VM = new AF1_32VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL321110FindAF1WithRecIdReq req = new SalesTransactionBL321110FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL321110Resp resp = await _transactionApi.GetAf32(req, ct);
                aF1_30VM.SalesTransactionBL321110Dto = resp.SalesTransactionBL321110;
            }
            else
            {
                aF1_30VM.SalesTransactionBL321110Dto = new DTO.BL321110.SalesTransactionBL321110Dto();
                aF1_30VM.SalesTransactionBL321110Dto.AF1BL321110 = new List<DTO.BL321110.AF1BL321110Dto>();

            }


            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllReq requestBody = new ProductLookupFindAllReq();
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllResp productFindAllResp = await _productApi.GetProductLookup(requestBody, ct);
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_30VM.Genders = result.gender;
            aF1_30VM.Regions = result.region;
            aF1_30VM.Relations = result.Relaion;
            aF1_30VM.MaritalStatuses = result.maritalStatus;
            aF1_30VM.Networks = result.NetworkLevel;
            aF1_30VM.Territorias = result.TerritorialScope;
            aF1_30VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_30VM.ContactVM = contactVM;
            aF1_30VM.Insurer = productFindAllResp.Insurer;
            aF1_30VM.ThirdPartyAdmin = productFindAllResp.ThirdPartyAdmin;
            return View(aF1_30VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_32(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_32(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_32(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL321110UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAf32(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_1(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_1VM aF1_1VM = new AF1_1VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL010602FindAF1WithRecIdFilterReq req = new SalesTransactionBL010602FindAF1WithRecIdFilterReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL010602Resp resp = await _transactionApi.GetAF1_01(req, ct);
                aF1_1VM.AF1BL010602Dtco = resp.SalesTransactionBL010602.AF1BL010602;
            }

            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_1VM.Genders = result.gender;
            aF1_1VM.Regions = result.region;
            aF1_1VM.Relations = result.Relaion;
            aF1_1VM.MaritalStatuses = result.maritalStatus;
            aF1_1VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_1VM.TerritorialScope  = result.TerritorialScope;
            aF1_1VM.StayTripOption  = result.StayTripOption;
            aF1_1VM.ContactVM = contactVM;
            return View(aF1_1VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_1(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL010602NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL010602NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_01(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_1(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL010602UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL010602UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_01(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_3(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_3VM aF1_3VM = new AF1_3VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL030904FindAF1WithRecIdReq req = new SalesTransactionBL030904FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL030904Resp resp = await _transactionApi.GetAF1_03(req, ct);
                aF1_3VM.AF1BL030904Dto = resp.SalesTransactionBL030904.AF1BL030904[0];
            }

            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_3VM.Genders = result.gender;
            aF1_3VM.Regions = result.region;
            aF1_3VM.Relations = result.Relaion;
            aF1_3VM.MaritalStatuses = result.maritalStatus;
            aF1_3VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_3VM.TerritorialScope = result.TerritorialScope;
            aF1_3VM.ContactVM = contactVM;
            return View(aF1_3VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_3(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL030904NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL030904NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_03(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_3(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL030904UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL030904UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_03(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_6(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_6VM aF1_6VM = new AF1_6VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL061005FindAF1WithRecIdReq req = new SalesTransactionBL061005FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL061005Resp resp = await _transactionApi.GetAF1_06(req, ct);
                aF1_6VM.AF1BL061005Dto = resp.SalesTransactionBL061005.AF1BL061005[0];
            }

            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_6VM.Genders = result.gender;
            aF1_6VM.Regions = result.region;
            aF1_6VM.Relations = result.Relaion;
            aF1_6VM.MaritalStatuses = result.maritalStatus;
            aF1_6VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_6VM.ContactVM = contactVM;
            return View(aF1_6VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_6(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL061005NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL061005NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_06(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_6(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL061005UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL061005UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_06(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_7(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_7VM aF1_7VM = new AF1_7VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL070806FindAF1WithRecIdFilterReq req = new SalesTransactionBL070806FindAF1WithRecIdFilterReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL070806Resp resp = await _transactionApi.GetAF1_07(req, ct);
                aF1_7VM.AF1BL070806Dtco = resp.SalesTransactionBL070806.AF1BL070806;
            }

            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            var result1 = await _generalListApi.GetGlobalLookupFindAll(req1, ct);
            aF1_7VM.Genders = result.gender;
            aF1_7VM.Regions = result.region;
            aF1_7VM.Relations = result.Relaion;
            aF1_7VM.MaritalStatuses = result.maritalStatus;
            aF1_7VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_7VM.ContactVM = contactVM;
            aF1_7VM.Masters = result1.Master;
            return View(aF1_7VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_7(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL070806NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL070806NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_07(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_7(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL070806UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL070806UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_07(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_9(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_9VM aF1_8VM = new AF1_9VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL090703FindAF1WithRecIdFilterReq req = new SalesTransactionBL090703FindAF1WithRecIdFilterReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL090703Resp resp = await _transactionApi.GetAF1_09(req, ct);
                aF1_8VM.AF1BL090703Dtco = resp.SalesTransactionBL090703.AF1BL090703;
                aF1_8VM.MasterId = resp.SalesTransactionBL090703.MasterId;
                aF1_8VM.ClientId = resp.SalesTransactionBL090703.ClientId;
            }

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            var result1 = await _generalListApi.GetGlobalLookupFindAll(req1, ct);


            aF1_8VM.Genders = result.gender;
            aF1_8VM.Regions = result.region;
            aF1_8VM.Relations = result.Relaion;
            aF1_8VM.MaritalStatuses = result.maritalStatus;
            aF1_8VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_8VM.ContactVM = contactVM;
            aF1_8VM.NetworkLevel = result.NetworkLevel;
            aF1_8VM.Clients = result1.Client;
            aF1_8VM.Masters = result1.Master;
            return View(aF1_8VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_9(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL090703NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL090703NewRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_09(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_9Consolidation(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL090703UpdGlobalRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL090703UpdGlobalRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.EditAf9Consolidation(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_9(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL090703UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL090703UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_09(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_4(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_4VM aF1_30VM = new AF1_4VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL041312FindAF1WithRecIdReq req = new SalesTransactionBL041312FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL041312Resp resp = await _transactionApi.GetAf04(req, ct);
                aF1_30VM.SalesTransactionBL041312Dto = resp.SalesTransactionBL041312;
            }
            else
            {
                aF1_30VM.SalesTransactionBL041312Dto = new DTO.BL041312.SalesTransactionBL041312Dto();
                aF1_30VM.SalesTransactionBL041312Dto.AF1BL041312 = new List<DTO.BL041312.AF1BL041312Dto>();

            }


            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllReq requestBody = new ProductLookupFindAllReq();
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllResp productFindAllResp = await _productApi.GetProductLookup(requestBody, ct);
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_30VM.Genders = result.gender;
            aF1_30VM.Regions = result.region;
            aF1_30VM.Relations = result.Relaion;
            aF1_30VM.MaritalStatuses = result.maritalStatus;
            aF1_30VM.Networks = result.NetworkLevel;
            aF1_30VM.Territorias = result.TerritorialScope;
            aF1_30VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_30VM.ContactVM = contactVM;
            aF1_30VM.Insurer = productFindAllResp.Insurer;
            return View(aF1_30VM);
        }
      
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_4(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_4(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_4(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL041312UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_4(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_5(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_5VM aF1_4VM = new AF1_5VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL051807FindAF1WithRecIdReq req = new SalesTransactionBL051807FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL051807Resp resp = await _transactionApi.GetAF1_5(req, ct);
                aF1_4VM.AF1BL051807 = resp.SalesTransactionBL051807.AF1BL051807;
            }

            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_4VM.Genders = result.gender;
            aF1_4VM.Regions = result.region;
            aF1_4VM.Relations = result.Relaion;
            aF1_4VM.MaritalStatuses = result.maritalStatus;
            aF1_4VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_4VM.ContactVM = contactVM;
            return View(aF1_4VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_5(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL051807NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL051807NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_5(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_5(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL051807UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL051807UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_5(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_2(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_2VM aF1_30VM = new AF1_2VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL021502FindAF1WithRecIdReq req = new SalesTransactionBL021502FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL021502Resp resp = await _transactionApi.GetAF1_2(req, ct);
                aF1_30VM.SalesTransactionBL021502Dto = resp.SalesTransactionBL021502;
            }
            else
            {
                aF1_30VM.SalesTransactionBL021502Dto = new DTO.BL021502.SalesTransactionBL021502Dto();
                aF1_30VM.SalesTransactionBL021502Dto.AF1BL021502 = new List<DTO.BL021502.AF1BL021502Dto>();

            }


            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_30VM.Genders = result.gender;
            aF1_30VM.Regions = result.region;
            aF1_30VM.Relations = result.Relaion;
            aF1_30VM.MaritalStatuses = result.maritalStatus;
            aF1_30VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_30VM.StayTripOptions = result.StayTripOption;
            aF1_30VM.TerritorialScope = result.TerritorialScope;

            aF1_30VM.ContactVM = contactVM;
            return View(aF1_30VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_2(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL021502NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL021502NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_2(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_2(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL021502UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL021502UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_2(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_33(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_33VM aF1_30VM = new AF1_33VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL331211FindAF1WithRecIdReq req = new SalesTransactionBL331211FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL331211Resp resp = await _transactionApi.GetAf33(req, ct);
                aF1_30VM.SalesTransactionBL331211Dto = resp.SalesTransactionBL331211;
            }
            else
            {
                aF1_30VM.SalesTransactionBL331211Dto = new DTO.BL331211.SalesTransactionBL331211Dto();
                aF1_30VM.SalesTransactionBL331211Dto.AF1BL331211 = new List<DTO.BL331211.AF1BL331211Dto>();

            }


            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllReq requestBody = new ProductLookupFindAllReq();
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllResp productFindAllResp = await _productApi.GetProductLookup(requestBody, ct);
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_30VM.Genders = result.gender;
            aF1_30VM.Regions = result.region;
            aF1_30VM.Relations = result.Relaion;
            aF1_30VM.MaritalStatuses = result.maritalStatus;
            aF1_30VM.Networks = result.NetworkLevel;
            aF1_30VM.Territorias = result.TerritorialScope;
            aF1_30VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_30VM.ContactVM = contactVM;
            aF1_30VM.Insurer = productFindAllResp.Insurer;
            return View(aF1_30VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_33(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_33(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_33(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL331211UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_33(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
     
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_31(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_31VM aF1_30VM = new AF1_31VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL311703FindAF1WithRecIdReq req = new SalesTransactionBL311703FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL311703Resp resp = await _transactionApi.GetAF1_31(req, ct);
                aF1_30VM.SalesTransactionBL311703 = resp.SalesTransactionBL311703;
            }
            else
            {
                aF1_30VM.SalesTransactionBL311703 = new DTO.BL311703.SalesTransactionBL311703Dto();
                aF1_30VM.SalesTransactionBL311703.AF1BL311703 = new List<DTO.BL311703.AF1BL311703Dto>();

            }


            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_30VM.Genders = result.gender;
            aF1_30VM.Regions = result.region;
            aF1_30VM.Relations = result.Relaion;
            aF1_30VM.MaritalStatuses = result.maritalStatus;
            aF1_30VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_30VM.ContactVM = contactVM;
            return View(aF1_30VM);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_31(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL311703NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL311703NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_31(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_31(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL311703UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL311703UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_31(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_28(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_28VM aF1_4VM = new AF1_28VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL281609FindAF1WithRecIdReq req = new SalesTransactionBL281609FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL281609Resp resp = await _transactionApi.GetAF1_28(req, ct);
                aF1_4VM.AF1BL281609 = resp.SalesTransactionBL281609.AF1BL281609;
            }

            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_4VM.Genders = result.gender;
            aF1_4VM.Regions = result.region;
            aF1_4VM.Relations = result.Relaion;
            aF1_4VM.MaritalStatuses = result.maritalStatus;
            aF1_4VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_4VM.ContactVM = contactVM;
            return View(aF1_4VM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_28(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL281609NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL281609NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_28(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_28(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL281609UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL281609UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_28(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        } 
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> AF1_29(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_29VM aF1_4VM = new AF1_29VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);
            if (trxID != 0)
            {
                SalesTransactionBL291908FindAF1WithRecIdReq req = new SalesTransactionBL291908FindAF1WithRecIdReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.SalesTransactionId = trxID;
                SalesTransactionBL291908Resp resp = await _transactionApi.GetAF1_29(req, ct);
                aF1_4VM.AF1BL291908 = resp.SalesTransactionBL291908.AF1BL291908;
            }

            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_4VM.Genders = result.gender;
            aF1_4VM.Regions = result.region;
            aF1_4VM.Relations = result.Relaion;
            aF1_4VM.MaritalStatuses = result.maritalStatus;
            aF1_4VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_4VM.ContactVM = contactVM;
            return View(aF1_4VM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateAF1_29(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL291908NewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL291908NewRecReq>(keyValues["data"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.CreateAF1_29(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditAF1_29(IFormCollection keyValues, CancellationToken ct)
        {

            SalesTransactionBL291908UpdAF1RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL291908UpdAF1RecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _transactionApi.UpdateAF1_29(requestBody, ct);
            // Code to process the form data-
            return Ok(result);
        }
    }
}
