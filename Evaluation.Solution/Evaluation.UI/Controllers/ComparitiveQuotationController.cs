
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL051807;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Request.BL080501;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Request.BL291908;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL311703;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Request.SpecialCondition;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Util;
using Evaluation.UI.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Evaluation.UI.Controllers
{
    public class ComparitiveQuotationController : Controller
    {
 
        private readonly IContactApi _contactApi;
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly IComparitiveQuotationBusiness _comparitiveQuotationBusiness;
        private readonly IBusinessLineApi _businessLineApi;
        private readonly ISpecialConditionApi _specialCondition;
        public ComparitiveQuotationController(IContactApi contactApi, IGlobal global, IUserApi userApi, IBusinessLineApi businessLineApi, ISpecialConditionApi specialCondition, IComparitiveQuotationBusiness comparitiveQuotationBusiness)
        {
            _contactApi = contactApi;
            _global = global;
            _userApi = userApi;
            _businessLineApi = businessLineApi;
            _specialCondition = specialCondition;
            _comparitiveQuotationBusiness = comparitiveQuotationBusiness;
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_1_8(string id, CancellationToken ct)
        {
            var cQAfVM = await _comparitiveQuotationBusiness.GetCQ_1_8(id, User.Claims,false, ct);
            return View(cQAfVM);
            
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_1(string id, CancellationToken ct)
        {
            CQAf30VM cQAfVM = new CQAf30VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL301401FindCQWithRecIdFilterReq request = new SalesTransactionBL301401FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF30(request, ct);
          //  cQAfVM.CQDetailsBL301401 = result.CQDetailsBL301401;
           // cQAfVM.CQSummaryBL301401 = result.CQSummaryBL301401;
            //cQAfVM.CQPivotBL301401 = result.CQPivotBL301401;
            // Convert the dynamic object to a dictionary
            List<IDictionary<string, string>> dynamicDictionary = _global. GetDictoinaryListFromDynamicList(result.CQPivotBL301401);
           // List<IDictionary<string, string>> dynamicbills = _global. GetDictoinaryListFromDynamicList(result.CQBillsBL301401);
            List<IDictionary<string, string>> dynamicBenefit = _global. GetDictoinaryListFromDynamicList(result.CQBenefitBL301401);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
           // cQAfVM.CQBillsList = dynamicbills;
          //  cQAfVM.CQHeader = result.CQHeaderBL301401;
            cQAfVM.CQCategory = result.CQCategoryBL301401;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_10(string id, CancellationToken ct)
        {
            CQAf32VM cQAfVM = new CQAf32VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL321110FindCQWithRecIdFilterReq request = new SalesTransactionBL321110FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF32(request, ct);
            //cQAfVM.CQDetailsBL321110 = result.CQDetailsBL321110;
            //cQAfVM.CQSummaryBL321110 = result.CQSummaryBL321110;
            //List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL321110);
            //List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL321110);
            //List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL321110);
            //cQAfVM.CQPivotList = dynamicDictionary;
            //cQAfVM.CQBenefitList = dynamicBenefit;
            //cQAfVM.CQBillsList = dynamicbills;
            //cQAfVM.CQHeader = result.CQHeaderBL321110;
            //cQAfVM.CQCategory = result.CQCategoryBL321110;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_2(string id, CancellationToken ct)
        {
            CQAf02VM cQAfVM = new CQAf02VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL021502FindCQWithRecIdFilterReq request = new SalesTransactionBL021502FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF02(request, ct);
            //cQAfVM.CQDetailsBL021502 = result.CQDetailsBL021502;
           // cQAfVM.CQSummaryBL021502 = result.CQSummaryBL021502;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL021502);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL021502);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL021502);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQHeader = result.CQHeaderBL021502;
            //cQAfVM.CQCategory = result.CQCategoryBL021502;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_6(string id, CancellationToken ct)
        {
            CQAf07VM cQAfVM = await _comparitiveQuotationBusiness.GetCQ6(id, User.Claims,false, ct);
            return View(cQAfVM);
        }

       

        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_7(string id, CancellationToken ct)
        {
            CQAf05VM cQAfVM = new CQAf05VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL051807FindCQWithRecIdFilterReq request = new SalesTransactionBL051807FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF05(request, ct);
            cQAfVM.CQDetailsBL051807 = result.CQDetailsBL051807;
            cQAfVM.CQSummaryBL051807 = result.CQSummaryBL051807;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL051807);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL051807);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL051807);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQHeader = result.CQHeaderBL051807;
            cQAfVM.CQCategory = result.CQCategoryBL051807;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_8(string id, CancellationToken ct)
        {
            CQAf29VM cQAfVM = new CQAf29VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL291908FindCQWithRecIdFilterReq request = new SalesTransactionBL291908FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF29(request, ct);
            cQAfVM.CQDetailsBL291908 = result.CQDetailsBL291908;
            cQAfVM.CQSummaryBL291908 = result.CQSummaryBL291908;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL291908);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL291908);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL291908);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQHeader = result.CQHeaderBL291908;
            cQAfVM.CQCategory = result.CQCategoryBL291908;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_9(string id, CancellationToken ct)
        {
            CQAf28VM cQAfVM = new CQAf28VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL281609FindCQWithRecIdFilterReq request = new SalesTransactionBL281609FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF28(request, ct);
            cQAfVM.CQDetailsBL281609 = result.CQDetailsBL281609;
            cQAfVM.CQSummaryBL281609 = result.CQSummaryBL281609;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL281609);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL281609);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL281609);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQHeader = result.CQHeaderBL281609;
            cQAfVM.CQCategory = result.CQCategoryBL281609;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_3(string id, CancellationToken ct)
        {
            CQAf31VM cQAfVM = new CQAf31VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL311703FindCQWithRecIdFilterReq request = new SalesTransactionBL311703FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF31(request, ct);
            cQAfVM.CQDetailsBL311703 = result.CQDetailsBL311703;
            cQAfVM.CQSummaryBL311703 = result.CQSummaryBL311703;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL311703);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL311703);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL311703);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQHeader = result.CQHeaderBL311703;
            cQAfVM.CQCategory = result.CQCategoryBL311703;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_11(string id, CancellationToken ct)
        {
            CQAf33VM cQAfVM = new CQAf33VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL331211FindCQWithRecIdFilterReq request = new SalesTransactionBL331211FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF33(request, ct);
            //cQAfVM.CQDetailsBL331211 = result.CQDetailsBL331211;
            //cQAfVM.CQSummaryBL331211 = result.CQSummaryBL331211;
            //List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL331211);
            //List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL331211);
            //List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL331211);
            //cQAfVM.CQPivotList = dynamicDictionary;
            //cQAfVM.CQBenefitList = dynamicBenefit;
            //cQAfVM.CQBillsList = dynamicbills;
            //cQAfVM.CQHeader = result.CQHeaderBL331211;
            //cQAfVM.CQCategory = result.CQCategoryBL331211;
            return View(cQAfVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CQ_12(string id, CancellationToken ct)
        {
            CQAf4VM cQAfVM = new CQAf4VM();
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            SalesTransactionBL041312FindCQWithRecIdFilterReq request = new SalesTransactionBL041312FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            var result = await _businessLineApi.GetCQAF4(request, ct);
            //cQAfVM.CQDetailsBL041312 = result.CQDetailsBL041312;
            //cQAfVM.CQSummaryBL041312 = result.CQSummaryBL041312;
            //List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL041312);
            //List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL041312);
            //List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL041312);
           // cQAfVM.CQPivotList = dynamicDictionary;
           // cQAfVM.CQBenefitList = dynamicBenefit;
           // cQAfVM.CQBillsList = dynamicbills;
            //cQAfVM.CQHeader = result.CQHeaderBL041312;
        //    cQAfVM.CQCategory = result.CQCategoryBL041312;
            return View(cQAfVM);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> InsertSpecialCondition(IFormCollection keyValues, CancellationToken ct)
        {
            SpecialConditionNewRecReq requestBody = JsonConvert.DeserializeObject<SpecialConditionNewRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _specialCondition.InsertSpecialCondition(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> GetSpecialCondition(IFormCollection keyValues, CancellationToken ct)
        {
            SpecialConditionFindWithColFilterReq requestBody = JsonConvert.DeserializeObject<SpecialConditionFindWithColFilterReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _specialCondition.FindSpecialCondition(requestBody, ct);
            return Ok(result);
        }
    }
}
