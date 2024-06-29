using Evaluation.UI.Request.Consolidation;
using Evaluation.UI.DTO;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Models.Consolidation;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL010602Consolidation;
using Evaluation.UI.Request.BL090703Consolidation;
using Evaluation.UI.Request.BL301401Consolidation;
using Evaluation.UI.Request.BL321110Consolidation;
using Evaluation.UI.Request.Global;
using Evaluation.UI.Response.BL010602Consolidation;
using Evaluation.UI.Response.BL090703Consolidation;
using Evaluation.UI.Response.BL301401Consolidation;
using Evaluation.UI.Response.BL321110Consolidation;
using Evaluation.UI.Response.Consolidation;
using Newtonsoft.Json;
using System.Security.Claims;
using Evaluation.UI.Response.BL070806Consolidation;
using Evaluation.UI.Request.BL070806Consolidation;
using Evaluation.UI.Request.BL281609Consolidation;
using Evaluation.UI.Response.BL281609Consolidation;
using Evaluation.UI.Response.BL331211Consolidation;
using Evaluation.UI.Request.BL331211Consolidation;
using Evaluation.UI.Response.BL041312Consolidation;
using Evaluation.UI.Request.BL041312Consolidation;
using Evaluation.UI.Response;

namespace Evaluation.UI.ControllerBusiness
{
    public class ConsolidationBusiness : IConsolidationBusiness
    {
        private readonly IGeneralListApi _generalListApi;
        private readonly IContactApi _contactApi;
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly IConsolidationApi _consolidationApi;
        public ConsolidationBusiness(IGeneralListApi generalListApi, ITransactionApi transactionApi, IContactApi contactApi, IGlobal global, IUserApi userApi, IProductApi productApi, IConsolidationApi consolidationApi)
        {
            _generalListApi = generalListApi;
            _contactApi = contactApi;
            _global = global;
            _userApi = userApi;
            _consolidationApi = consolidationApi;
        }
   
        public async Task<ConsolidationVM> GetConsolidationBusiness(string id, IEnumerable<Claim> claims,CancellationToken ct)
        {
            ConsolidationVM convm = new ConsolidationVM();
            var user = await _userApi.GetUserClaims(claims);

			GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
			req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
			req.WebRequestCommon.UserName = user.EmailAdress;
			var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
			convm.Masters = resultClientMaster.Master;
			convm.Clients = resultClientMaster.Client;

			PolicyResp resultConsolidation = new PolicyResp();
			ContactVM contactVM= new ContactVM();
            var salestransactionID = 0;
            var businesscode = "";
			try
            {
				var paramDecode = _global.DecodeParameters(id, 5);
				var contactID = Convert.ToInt32(paramDecode[0]);
			    salestransactionID = Convert.ToInt32(paramDecode[1]);
			    businesscode = paramDecode[2];
				var productID = Convert.ToInt32(paramDecode[3]);
				var combinationID = paramDecode[4];


				GenericIdReq requestCont = new GenericIdReq();
				requestCont.recId = contactID;
				contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);



			
				PolicyNewRecReq reqCon = new PolicyNewRecReq();
				reqCon.SalesTransactionId = salestransactionID;
				reqCon.ProductId = productID;
				reqCon.Combination = combinationID;
				reqCon.BusinessLineCode = businesscode;
				reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
				reqCon.WebRequestCommon.UserName = user.EmailAdress;
			    resultConsolidation = await _consolidationApi.CreateConsolidation(reqCon, ct);
			}
            catch  {
				var paramDecode = _global.DecodeParameters(id, 1);
				var parentPolicyId = paramDecode[0];
				PolicyBl080501FindParentPolicyIdRecReq policyBl080501FindParentPolicyIdRecReq = new PolicyBl080501FindParentPolicyIdRecReq();
				policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
				policyBl080501FindParentPolicyIdRecReq.WebRequestCommon.UserName = user.EmailAdress;
                policyBl080501FindParentPolicyIdRecReq.ParentPolicyId = parentPolicyId;
				resultConsolidation = await _consolidationApi.PolicyFindAllWithParentPolicyId(policyBl080501FindParentPolicyIdRecReq,ct);

				salestransactionID = resultConsolidation.SalesTransactionBL080501.RecId;
				businesscode = resultConsolidation.SalesTransactionBL080501.BusinessLineCode;

				GenericIdReq requestCont = new GenericIdReq();
				requestCont.recId = resultConsolidation.SalesTransactionBL080501.ContactId;
				contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
			}

			GenericEmptyReq request = new GenericEmptyReq();
			request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
			request.WebRequestCommon.UserName = user.EmailAdress;
			var result = await _generalListApi.GetAllGeneralLists(request, ct);

			convm.PolicyRelatedDoc = resultConsolidation.PolicyRelatedDoc;
            convm.PaymentSchedule = resultConsolidation.PaymentSchedule;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL080501 = resultConsolidation.SalesTransactionBL080501;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocResp> UpdateConsolidation080501Business(IFormFile uploadDoc,IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocUpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocUpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocResp> CreateConsolidation080501Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocNewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocNewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information
            
                requestBody.AttachDocName= Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt= Path.GetExtension(uploadDoc.FileName).Replace(".","");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }
               

            }  
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments(requestBody, ct);
            return result;
        }
        public async Task<PolicyUpdResp> UpdateConsolidation080501FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyUpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyUpdRecReq>(keyValues["data"]);
          
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm(requestBody, ct);
            return result;
        }
        public async Task<Consolidation321110VM> GetConsolidationBusiness321110(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation321110VM convm = new Consolidation321110VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 5);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var insurerCode =paramDecode[3];
            var thirdPartyAdminCode = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL321110NewRecReq reqCon = new PolicyBL321110NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
            reqCon.InsurerCode = insurerCode;
            reqCon.ThirdPartyAdminCode = thirdPartyAdminCode;
            reqCon.BusinessLineCode = businesscode;
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation321110(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc321110;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL321110;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL321110 = resultConsolidation.SalesTransactionBL321110;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL321110Resp> UpdateConsolidation321110Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL321110UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL321110UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments321110(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL321110Resp> CreateConsolidation321110Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL321110NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL321110NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments321110(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL321110UpdResp> UpdateConsolidation321110FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL321110UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL321110UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm321110(requestBody, ct);
            return result;
        }
        public async Task<Consolidation301401VM> GetConsolidationBusiness301401(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation301401VM convm = new Consolidation301401VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 5);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var productID = Convert.ToInt32(paramDecode[3]);
            var combinationID = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL301401NewRecReq reqCon = new PolicyBL301401NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
            reqCon.ProductId = productID;
            reqCon.Combination = combinationID;
            reqCon.BusinessLineCode = businesscode;
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation301401(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc301401;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL301401;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL301401 = resultConsolidation.SalesTransactionBL301401;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL301401Resp> UpdateConsolidation301401Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL301401UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL301401UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments301401(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL301401Resp> CreateConsolidation301401Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL301401NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL301401NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments301401(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL301401UpdResp> UpdateConsolidation301401FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL301401UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL301401UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm301401(requestBody, ct);
            return result;
        }
        public async Task<Consolidation010602VM> GetConsolidationBusiness010602(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation010602VM convm = new Consolidation010602VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 5);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var productID = Convert.ToInt32(paramDecode[3]);
            var combinationID = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL010602NewRecReq reqCon = new PolicyBL010602NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
            reqCon.ProductId = productID;
            reqCon.Combination = combinationID;
            reqCon.BusinessLineCode = businesscode;
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation010602(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc010602;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL010602;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL010602 = resultConsolidation.SalesTransactionBL010602;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL010602Resp> UpdateConsolidation010602Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL010602UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL010602UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments010602(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL010602Resp> CreateConsolidation010602Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL010602NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL010602NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments010602(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL010602UpdResp> UpdateConsolidation010602FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL010602UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL010602UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm010602(requestBody, ct);
            return result;
        }
        public async Task<Consolidation090703VM> GetConsolidationBusiness090703(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation090703VM convm = new Consolidation090703VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 5);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var productID = Convert.ToInt32(paramDecode[3]);
            var combinationID = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL090703NewRecReq reqCon = new PolicyBL090703NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
            reqCon.ProductId = productID;
            reqCon.Combination = combinationID;
            reqCon.BusinessLineCode = businesscode;
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation090703(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc090703;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL090703;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL090703 = resultConsolidation.SalesTransactionBL090703;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL090703Resp> UpdateConsolidation090703Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL090703UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL090703UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments090703(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL090703Resp> CreateConsolidation090703Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL090703NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL090703NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments090703(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL090703UpdResp> UpdateConsolidation090703FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL090703UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL090703UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm090703(requestBody, ct);
            return result;
        }   
        public async Task<Consolidation070806VM> GetConsolidationBusiness070806(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation070806VM convm = new Consolidation070806VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 5);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var productID = Convert.ToInt32(paramDecode[3]);
            var combinationID = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL070806NewRecReq reqCon = new PolicyBL070806NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
            reqCon.ProductId = productID;
            reqCon.Combination = combinationID;
            reqCon.BusinessLineCode = businesscode;
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation070806(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc070806;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL070806;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL070806 = resultConsolidation.SalesTransactionBL070806;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL070806Resp> UpdateConsolidation070806Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL070806UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL070806UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments070806(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL070806Resp> CreateConsolidation070806Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL070806NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL070806NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments070806(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL070806UpdResp> UpdateConsolidation070806FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL070806UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL070806UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm070806(requestBody, ct);
            return result;
        }
        public async Task<Consolidation281609VM> GetConsolidationBusiness281609(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation281609VM convm = new Consolidation281609VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 5);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var productID = Convert.ToInt32(paramDecode[3]);
            var combinationID = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL281609NewRecReq reqCon = new PolicyBL281609NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
            reqCon.ProductId = productID;
            reqCon.Combination = combinationID;
            reqCon.BusinessLineCode = businesscode;
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation281609(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc281609;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL281609;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL281609 = resultConsolidation.SalesTransactionBL281609;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL281609Resp> UpdateConsolidation281609Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL281609UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL281609UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments281609(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL281609Resp> CreateConsolidation281609Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL281609NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL281609NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments281609(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL281609UpdResp> UpdateConsolidation281609FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL281609UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL281609UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm281609(requestBody, ct);
            return result;
        }
        public async Task<Consolidation041312VM> GetConsolidationBusiness041312(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation041312VM convm = new Consolidation041312VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 4);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var productID = Convert.ToInt32(paramDecode[3]);
            //var combinationID = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL041312NewRecReq reqCon = new PolicyBL041312NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
            //  reqCon.ProductId = productID;
            //  reqCon.Combination = combinationID;
            reqCon.BusinessLineCode = businesscode;
            reqCon.InsurerCode = productID.ToString();
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation041312(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc041312;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL041312;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL041312 = resultConsolidation.SalesTransactionBL041312;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL041312Resp> UpdateConsolidation041312Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL041312UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL041312UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments041312(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL041312Resp> CreateConsolidation041312Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL041312NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL041312NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments041312(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL041312UpdResp> UpdateConsolidation041312FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL041312UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL041312UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm041312(requestBody, ct);
            return result;
        }
        public async Task<Consolidation331211VM> GetConsolidationBusiness331211(string id, IEnumerable<Claim> claims, CancellationToken ct)
        {
            Consolidation331211VM convm = new Consolidation331211VM();
            var user = await _userApi.GetUserClaims(claims);
            var paramDecode = _global.DecodeParameters(id, 4);
            var contactID = Convert.ToInt32(paramDecode[0]);
            var salestransactionID = Convert.ToInt32(paramDecode[1]);
            var businesscode = paramDecode[2];
            var productID = Convert.ToInt32(paramDecode[3]);
            //var combinationID = paramDecode[4];

            GlobalLookupFindAllReq req = new GlobalLookupFindAllReq();
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            var resultClientMaster = await _generalListApi.GetGlobalLookupFindAll(req, ct);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = contactID;
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            convm.Masters = resultClientMaster.Master;
            convm.Clients = resultClientMaster.Client;

            GenericEmptyReq request = new GenericEmptyReq();
            GlobalLookupFindAllReq req1 = new GlobalLookupFindAllReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            req1.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req1.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _generalListApi.GetAllGeneralLists(request, ct);


            PolicyBL331211NewRecReq reqCon = new PolicyBL331211NewRecReq();
            reqCon.SalesTransactionId = salestransactionID;
          //  reqCon.ProductId = productID;
          //  reqCon.Combination = combinationID;
            reqCon.BusinessLineCode = businesscode;
            reqCon.InsurerCode = productID.ToString();
            reqCon.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqCon.WebRequestCommon.UserName = user.EmailAdress;
            var resultConsolidation = await _consolidationApi.CreateConsolidation331211(reqCon, ct);


            convm.PolicyRelatedDoc = resultConsolidation.policyRelatedDoc331211;
            convm.PaymentSchedule = resultConsolidation.paymentScheduleBL331211;
            convm.Policy = resultConsolidation.Policy;
            convm.SalesTransactionId = salestransactionID;
            convm.BusinessLineCode = businesscode;
            convm.SalesTransactionBL331211 = resultConsolidation.SalesTransactionBL331211;
            convm.Genders = result.gender;
            convm.Regions = result.region;
            convm.Relations = result.Relaion;
            convm.MaritalStatuses = result.maritalStatus;
            convm.ProductClassOfCoverage = result.ProductClassOfCoverage;
            convm.ContactVM = contactVM;
            convm.NetworkLevel = result.NetworkLevel;

            return convm;
        }
        public async Task<PolicyRelatedDocBL331211Resp> UpdateConsolidation331211Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {

            PolicyRelatedDocBL331211UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL331211UpdRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyAndDocuments331211(requestBody, ct);
            return result;
        }
        public async Task<PolicyRelatedDocBL331211Resp> CreateConsolidation331211Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyRelatedDocBL331211NewRecReq requestBody = JsonConvert.DeserializeObject<PolicyRelatedDocBL331211NewRecReq>(keyValues["data"]);
            // Check if a file is provided
            if (uploadDoc != null && uploadDoc.Length > 0)
            {
                // Access file information

                requestBody.AttachDocName = Path.GetFileNameWithoutExtension(uploadDoc.FileName);
                requestBody.AttachDocExt = Path.GetExtension(uploadDoc.FileName).Replace(".", "");
                using (var memoryStream = new MemoryStream())
                {
                    uploadDoc.CopyTo(memoryStream);
                    requestBody.AttachDocBinary = memoryStream.ToArray();
                }


            }
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.CreatePolicyAndDocuments331211(requestBody, ct);
            return result;
        }
        public async Task<PolicyBL331211UpdResp> UpdateConsolidation331211FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct)
        {
            PolicyBL331211UpdRecReq requestBody = JsonConvert.DeserializeObject<PolicyBL331211UpdRecReq>(keyValues["data"]);

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _consolidationApi.UpdatePolicyForm331211(requestBody, ct);
            return result;
        }


    }

}
