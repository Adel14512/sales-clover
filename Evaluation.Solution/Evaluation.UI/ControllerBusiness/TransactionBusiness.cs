using Evaluation.UI.Request.BL051807;
using Evaluation.UI.Request.BL061005;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Models.Transaction;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL010602;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Request.BL030904;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Request.BL090703;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Request.BL291908;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL311703;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Response.BL010602;
using Evaluation.UI.Response.BL021502;
using Evaluation.UI.Response.BL030904;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL051807;
using Evaluation.UI.Response.BL061005;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Response.BL090703;
using Evaluation.UI.Response.BL281609;
using Evaluation.UI.Response.BL291908;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Response.BL311703;
using Evaluation.UI.Response.BL331211;
using System.Security.Claims;
using Evaluation.UI.Response.Product;
using Evaluation.UI.Request.Product;
using Evaluation.UI.Consume.Api;

namespace Evaluation.UI.ControllerBusiness
{
    public class TransactionBusiness : ITransactionBusiness
    {
        private readonly IContactApi _contactApi;
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly IBusinessLineApi _businessLineApi;
        private readonly ISpecialConditionApi _specialCondition;
        private readonly ITransactionApi _transactionApi;
        private readonly IProductApi _productApi;
        private readonly IGeneralListApi _generalListApi;

        public TransactionBusiness(IContactApi contactApi, IGlobal global, IUserApi userApi, IBusinessLineApi businessLineApi, ISpecialConditionApi specialCondition, IGeneralListApi generalListApi, IProductApi productApi, ITransactionApi transactionApi)
        {
            _contactApi = contactApi;
            _global = global;
            _userApi = userApi;
            _businessLineApi = businessLineApi;
            _specialCondition = specialCondition;
            _generalListApi = generalListApi;
            _productApi = productApi;
            _transactionApi = transactionApi;
        }
        public async Task<Detailed301401VM> Detailed301401Business(string id, IEnumerable<Claim> claims , CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed301401VM detailedVM = new Detailed301401VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL301401FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL301401FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL301401CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList301401(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL301401 = resp.CQShortListBL301401;
            detailedVM.CQFullListBL301401 = resp.CQFullListBL301401;
            detailedVM.CQHeaderBL301401 = resp.CQHeaderBL301401;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        } 
        public async Task<Detailed070806VM> Detailed070806Business(string id, IEnumerable<Claim> claims , CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed070806VM detailedVM = new Detailed070806VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL070806FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL070806FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL070806CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList070806(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL070806 = resp.CQShortListBL070806;
            detailedVM.CQFullListBL070806 = resp.CQFullListBL070806;
            detailedVM.CQHeaderBL070806 = resp.CQHeaderBL070806;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed090703VM> Detailed090703Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed090703VM detailedVM = new Detailed090703VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL090703FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL090703FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL090703CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList090703(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL090703 = resp.CQShortListBL090703;
            detailedVM.CQFullListBL090703 = resp.CQFullListBL090703;
            detailedVM.CQHeaderBL090703 = resp.CQHeaderBL090703;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed010602VM> Detailed010602Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed010602VM detailedVM = new Detailed010602VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL010602FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL010602FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL010602CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList010602(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL010602 = resp.CQShortListBL010602;
            detailedVM.CQFullListBL010602 = resp.CQFullListBL010602;
            detailedVM.CQHeaderBL010602 = resp.CQHeaderBL010602;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed021502VM> Detailed021502Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed021502VM detailedVM = new Detailed021502VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL021502FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL021502FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL021502CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList021502(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL021502 = resp.CQShortListBL021502;
            detailedVM.CQFullListBL021502 = resp.CQFullListBL021502;
            detailedVM.CQHeaderBL021502 = resp.CQHeaderBL021502;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed281609VM> Detailed281609Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed281609VM detailedVM = new Detailed281609VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL281609FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL281609FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL281609CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList281609(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL281609 = resp.CQShortListBL281609;
            detailedVM.CQFullListBL281609 = resp.CQFullListBL281609;
            detailedVM.CQHeaderBL281609 = resp.CQHeaderBL281609;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed331211VM> Detailed331211Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            Detailed331211VM aF1_30VM = new Detailed331211VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);



            SalesTransactionBL331211DetailsFindWithSalesTrxIdReq reqDetails = new SalesTransactionBL331211DetailsFindWithSalesTrxIdReq();
            reqDetails.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqDetails.WebRequestCommon.UserName = user.EmailAdress;
           // reqDetails.SalesTransactionId = 1;
            reqDetails.SalesTransactionId = trxID;
            SalesTransactionBL331211DetailsResp resp = await _transactionApi.GetAF1_33Details(reqDetails, ct);
            aF1_30VM.SalesTransactionBL331211Details = new List<DTO.BL331211.SalesTransactionBL331211DetailsDto>();
            aF1_30VM.SalesTransactionBL331211Details = resp.SalesTransactionBL331211Details;
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
            aF1_30VM.ProductDetailsPOINetwork = productFindAllResp.ProductDetailsPOINetwork;
            aF1_30VM.SalesTransactionBL331211DetailsPrices = resp.SalesTransactionBL331211DetailsPrices;
            //aF1_30VM.BusinessLineCode = paramDecode[2];
            //aF1_30VM.PageType = paramDecode[3];
            return aF1_30VM;
        }
        public async Task<Detailed051807VM> Detailed051807Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed051807VM detailedVM = new Detailed051807VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL051807FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL051807FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL051807CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList051807(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL051807 = resp.CQShortListBL051807;
            detailedVM.CQFullListBL051807 = resp.CQFullListBL051807;
            detailedVM.CQHeaderBL051807 = resp.CQHeaderBL051807;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed030904VM> Detailed030904Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed030904VM detailedVM = new Detailed030904VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL030904FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL030904FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL030904CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList030904(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL030904 = resp.CQShortListBL030904;
            detailedVM.CQFullListBL030904 = resp.CQFullListBL030904;
            detailedVM.CQHeaderBL030904 = resp.CQHeaderBL030904;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed041312VM> Detailed041312Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 2);

            Detailed041312VM aF1_30VM = new Detailed041312VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);



            SalesTransactionBL041312DetailsFindWithSalesTrxIdReq reqDetails = new SalesTransactionBL041312DetailsFindWithSalesTrxIdReq();
            reqDetails.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqDetails.WebRequestCommon.UserName = user.EmailAdress;
            // reqDetails.SalesTransactionId = 1;
            reqDetails.SalesTransactionId = trxID;
            SalesTransactionBL041312DetailsResp resp = await _transactionApi.GetAF1_04Details(reqDetails, ct);
            aF1_30VM.SalesTransactionBL041312Details = new List<DTO.BL041312.SalesTransactionBL041312DetailsDto>();
            aF1_30VM.SalesTransactionBL041312Details = resp.SalesTransactionBL041312Details;
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
            aF1_30VM.ProductDetailsPOINetwork = productFindAllResp.ProductDetailsPOINetwork;
            aF1_30VM.SalesTransactionBL041312DetailsPrices = resp.SalesTransactionBL041312DetailsPrices;
            return aF1_30VM;
        }
        public async Task<Detailed061005VM> Detailed061005Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed061005VM detailedVM = new Detailed061005VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL061005FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL061005FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL061005CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList061005(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL061005 = resp.CQShortListBL061005;
            detailedVM.CQFullListBL061005 = resp.CQFullListBL061005;
            detailedVM.CQHeaderBL061005 = resp.CQHeaderBL061005;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed291908VM> Detailed291908Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed291908VM detailedVM = new Detailed291908VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL291908FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL291908FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL291908CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList291908(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL291908 = resp.CQShortListBL291908;
            detailedVM.CQFullListBL291908 = resp.CQFullListBL291908;
            detailedVM.CQHeaderBL291908 = resp.CQHeaderBL291908;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
        public async Task<Detailed311703VM> Detailed311703Business(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(claims);
            Detailed311703VM detailedVM = new Detailed311703VM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL311703FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL311703FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL311703CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList311703(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL311703 = resp.CQShortListBL311703;
            detailedVM.CQFullListBL311703 = resp.CQFullListBL311703;
            detailedVM.CQHeaderBL311703 = resp.CQHeaderBL311703;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];
            return detailedVM;
        }
    }
}
