using Evaluation.UI.DTO;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Request.BL080501;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Response.BL080501;
using Evaluation.UI.Response.BL281609;
using System.Security.Claims;

namespace Evaluation.UI.ControllerBusiness
{
    public class ComparitiveQuotationBusiness:IComparitiveQuotationBusiness
    {
        private readonly IContactApi _contactApi;
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly IBusinessLineApi _businessLineApi;
        private readonly ISpecialConditionApi _specialCondition;
        public ComparitiveQuotationBusiness(IContactApi contactApi, IGlobal global, IUserApi userApi, IBusinessLineApi businessLineApi, ISpecialConditionApi specialCondition)
        {
            _contactApi = contactApi;
            _global = global;
            _userApi = userApi;
            _businessLineApi = businessLineApi;
            _specialCondition = specialCondition;
        }
        public async Task<CQAf8VM> GetCQ_1_8(string id, IEnumerable<Claim> claims,bool isShort , CancellationToken ct)
        {
            CQAf8VM cQAfVM = new CQAf8VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            await CQ_1_8(cQAfVM, user, trxID, isShort,ct);
            return cQAfVM;
        }

        public async Task CQ_1_8(CQAf8VM cQAfVM, UserDto user, int trxID, bool isShort,CancellationToken ct)
        {
            SalesTransactionBL080501FindCQWithRecIdFilterReq request = new SalesTransactionBL080501FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            SalesTransactionBL080501CQResp result = new SalesTransactionBL080501CQResp();
            if (isShort)
            {
                 result = await _businessLineApi.GetCQAF8Short(request, ct);
            }
            else
            {
                 result = await _businessLineApi.GetCQAF8(request, ct);
            }
            
            cQAfVM.CQDetailsBL080501 = result.CQDetailsBL080501;
            cQAfVM.CQSummaryBL080501 = result.CQSummaryBL080501;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL080501);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL080501);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL080501);
            List<IDictionary<string, string>> dynamiccompare = _global.GetDictoinaryListFromDynamicList(result.CQBenefitComapreBL080501);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQCompareList = dynamiccompare;
            cQAfVM.CQHeader = result.CQHeaderBL080501;
            cQAfVM.CQCategory = result.CQCategoryBL080501;
        }
        public async Task<CQAf07VM> GetCQ6(string id, IEnumerable<Claim> claims, bool isShort, CancellationToken ct)
        {
            CQAf07VM cQAfVM = new CQAf07VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            await CQ6(cQAfVM, user, trxID, isShort, ct);
            return cQAfVM;
        }

        public async Task CQ6(CQAf07VM cQAfVM, UserDto user, int trxID, bool isShort, CancellationToken ct)
        {
            //SalesTransactionBL070806FindCQWithRecIdFilterReq request = new SalesTransactionBL070806FindCQWithRecIdFilterReq();
            //request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            //request.WebRequestCommon.UserName = user.EmailAdress;
            //request.SalesTransactionId = trxID;
            //var result = await _businessLineApi.GetCQAF07(request, ct);
            //cQAfVM.CQDetailsBL070806 = result.CQDetailsBL070806;
            //cQAfVM.CQSummaryBL070806 = result.CQSummaryBL070806;
            //List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL070806);
            //List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL070806);
            //List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL070806);
            //cQAfVM.CQPivotList = dynamicDictionary;
            //cQAfVM.CQBenefitList = dynamicBenefit;
            //cQAfVM.CQBillsList = dynamicbills;
            //cQAfVM.CQHeader = result.CQHeaderBL070806;
            //cQAfVM.CQCategory = result.CQCategoryBL070806;
            SalesTransactionBL070806FindCQWithRecIdFilterReq request = new SalesTransactionBL070806FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            SalesTransactionBL070806CQResp result = new SalesTransactionBL070806CQResp();
            if (isShort)
            {
                result = await _businessLineApi.GetCQAF07Short(request, ct);
            }
            else
            {
                result = await _businessLineApi.GetCQAF07(request, ct);
            }

            cQAfVM.CQDetailsBL070806 = result.CQDetailsBL070806;
            cQAfVM.CQSummaryBL070806 = result.CQSummaryBL070806;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL070806);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL070806);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL070806);
            List<IDictionary<string, string>> dynamiccompare = _global.GetDictoinaryListFromDynamicList(result.CQBenefitComapreBL070806);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQCompareList = dynamiccompare;
            cQAfVM.CQHeader = result.CQHeaderBL070806;
            cQAfVM.CQCategory = result.CQCategoryBL070806;
        }
        public async Task<CQAf28VM> GetCQ9(string id, IEnumerable<Claim> claims, bool isShort, CancellationToken ct)
        {
            CQAf28VM cQAfVM = new CQAf28VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            cQAfVM.ContactVM = contactVM;
            int trxID = Convert.ToInt32(paramDecode[1]);

            await CQ9(cQAfVM, user, trxID, isShort, ct);
            return cQAfVM;
        }

        public async Task CQ9(CQAf28VM cQAfVM, UserDto user, int trxID, bool isShort, CancellationToken ct)
        {
            
            SalesTransactionBL281609FindCQWithRecIdFilterReq request = new SalesTransactionBL281609FindCQWithRecIdFilterReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            request.SalesTransactionId = trxID;
            SalesTransactionBL281609CQResp result = new SalesTransactionBL281609CQResp();
            if (isShort)
            {
                result = await _businessLineApi.GetCQAF28Short(request, ct);
            }
            else
            {
                result = await _businessLineApi.GetCQAF28(request, ct);
            }

            cQAfVM.CQDetailsBL281609 = result.CQDetailsBL281609;
            cQAfVM.CQSummaryBL281609 = result.CQSummaryBL281609;
            List<IDictionary<string, string>> dynamicDictionary = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL281609);
            List<IDictionary<string, string>> dynamicbills = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL281609);
            List<IDictionary<string, string>> dynamicBenefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL281609);
            List<IDictionary<string, string>> dynamiBenefitCompare = _global.GetDictoinaryListFromDynamicList(result.CQBenefitComapreBL281609);
            cQAfVM.CQPivotList = dynamicDictionary;
            cQAfVM.CQBenefitList = dynamicBenefit;
            cQAfVM.CQBillsList = dynamicbills;
            cQAfVM.CQBenefitCompareList = dynamiBenefitCompare;
            cQAfVM.CQHeader = result.CQHeaderBL281609;
            cQAfVM.CQCategory = result.CQCategoryBL281609;
        }
    }
}
