using Evaluation.UI.Request.Consolidation;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request.BL010602Consolidation;
using Evaluation.UI.Request.BL090703Consolidation;
using Evaluation.UI.Request.BL301401Consolidation;
using Evaluation.UI.Request.BL321110Consolidation;
using Evaluation.UI.Response.BL010602Consolidation;
using Evaluation.UI.Response.BL090703Consolidation;
using Evaluation.UI.Response.BL301401Consolidation;
using Evaluation.UI.Response.BL321110Consolidation;
using Evaluation.UI.Response.Consolidation;
using Evaluation.UI.Wrapper;
using System.Net;
using Evaluation.UI.Request.BL070806Consolidation;
using Evaluation.UI.Response.BL070806Consolidation;
using Evaluation.UI.Response.BL281609Consolidation;
using Evaluation.UI.Request.BL281609Consolidation;
using Evaluation.UI.Response.BL331211Consolidation;
using Evaluation.UI.Request.BL331211Consolidation;
using Evaluation.UI.Response.BL041312Consolidation;
using Evaluation.UI.Request.BL041312Consolidation;

namespace Evaluation.UI.Consume.Api
{
    public class ConsolidationApi : IConsolidationApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public ConsolidationApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<PolicyResp> CreateConsolidation(PolicyNewRecReq request, CancellationToken ct)
        {
            PolicyResp resp = new PolicyResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Policy/PolicyNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocResp> UpdatePolicyAndDocuments(PolicyRelatedDocUpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocResp resp = new PolicyRelatedDocResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Policy/PolicyRelatedDocUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocResp> CreatePolicyAndDocuments(PolicyRelatedDocNewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocResp resp = new PolicyRelatedDocResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Policy/PolicyRelatedDocNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        } 
        public async Task<PolicyUpdResp> UpdatePolicyForm(PolicyUpdRecReq request, CancellationToken ct)
        {
            PolicyUpdResp resp = new PolicyUpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Policy/PolicyUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyUpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL301401Resp> CreateConsolidation301401(PolicyBL301401NewRecReq request, CancellationToken ct)
        {
            PolicyBL301401Resp resp = new PolicyBL301401Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL301401/PolicyBL301401NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL301401Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL301401Resp> UpdatePolicyAndDocuments301401(PolicyRelatedDocBL301401UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL301401Resp resp = new PolicyRelatedDocBL301401Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL301401/PolicyRelatedDocBL301401UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL301401Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL301401Resp> CreatePolicyAndDocuments301401(PolicyRelatedDocBL301401NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL301401Resp resp = new PolicyRelatedDocBL301401Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL301401/PolicyRelatedDocBL301401NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL301401Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL301401UpdResp> UpdatePolicyForm301401(PolicyBL301401UpdRecReq request, CancellationToken ct)
        {
            PolicyBL301401UpdResp resp = new PolicyBL301401UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL301401/PolicyBL301401UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL301401UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL321110Resp> CreateConsolidation321110(PolicyBL321110NewRecReq request, CancellationToken ct)
        {
            PolicyBL321110Resp resp = new PolicyBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL321110/PolicyBL321110NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL321110Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL321110Resp> UpdatePolicyAndDocuments321110(PolicyRelatedDocBL321110UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL321110Resp resp = new PolicyRelatedDocBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL321110/PolicyRelatedDocBL321110UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL321110Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL321110Resp> CreatePolicyAndDocuments321110(PolicyRelatedDocBL321110NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL321110Resp resp = new PolicyRelatedDocBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL321110/PolicyRelatedDocBL321110NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL321110Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL321110UpdResp> UpdatePolicyForm321110(PolicyBL321110UpdRecReq request, CancellationToken ct)
        {
            PolicyBL321110UpdResp resp = new PolicyBL321110UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL321110/PolicyBL321110UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL321110UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL010602Resp> CreateConsolidation010602(PolicyBL010602NewRecReq request, CancellationToken ct)
        {
            PolicyBL010602Resp resp = new PolicyBL010602Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL010602/PolicyBL010602NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL010602Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL010602Resp> UpdatePolicyAndDocuments010602(PolicyRelatedDocBL010602UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL010602Resp resp = new PolicyRelatedDocBL010602Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL010602/PolicyRelatedDocBL010602UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL010602Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL010602Resp> CreatePolicyAndDocuments010602(PolicyRelatedDocBL010602NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL010602Resp resp = new PolicyRelatedDocBL010602Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL010602/PolicyRelatedDocBL010602NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL010602Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL010602UpdResp> UpdatePolicyForm010602(PolicyBL010602UpdRecReq request, CancellationToken ct)
        {
            PolicyBL010602UpdResp resp = new PolicyBL010602UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL010602/PolicyBL010602UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL010602UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL090703Resp> CreateConsolidation090703(PolicyBL090703NewRecReq request, CancellationToken ct)
        {
            PolicyBL090703Resp resp = new PolicyBL090703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL090703/PolicyBL090703NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL090703Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL090703Resp> UpdatePolicyAndDocuments090703(PolicyRelatedDocBL090703UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL090703Resp resp = new PolicyRelatedDocBL090703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL090703/PolicyRelatedDocBL090703UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL090703Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL090703Resp> CreatePolicyAndDocuments090703(PolicyRelatedDocBL090703NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL090703Resp resp = new PolicyRelatedDocBL090703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL090703/PolicyRelatedDocBL090703NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL090703Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL090703UpdResp> UpdatePolicyForm090703(PolicyBL090703UpdRecReq request, CancellationToken ct)
        {
            PolicyBL090703UpdResp resp = new PolicyBL090703UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL090703/PolicyBL090703UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL090703UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL070806Resp> CreateConsolidation070806(PolicyBL070806NewRecReq request, CancellationToken ct)
        {
            PolicyBL070806Resp resp = new PolicyBL070806Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL070806/PolicyBL070806NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL070806Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL070806Resp> UpdatePolicyAndDocuments070806(PolicyRelatedDocBL070806UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL070806Resp resp = new PolicyRelatedDocBL070806Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL070806/PolicyRelatedDocBL070806UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL070806Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL070806Resp> CreatePolicyAndDocuments070806(PolicyRelatedDocBL070806NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL070806Resp resp = new PolicyRelatedDocBL070806Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL070806/PolicyRelatedDocBL070806NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL070806Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL070806UpdResp> UpdatePolicyForm070806(PolicyBL070806UpdRecReq request, CancellationToken ct)
        {
            PolicyBL070806UpdResp resp = new PolicyBL070806UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL070806/PolicyBL070806UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL070806UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL281609Resp> CreateConsolidation281609(PolicyBL281609NewRecReq request, CancellationToken ct)
        {
            PolicyBL281609Resp resp = new PolicyBL281609Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL281609/PolicyBL281609NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL281609Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL281609Resp> UpdatePolicyAndDocuments281609(PolicyRelatedDocBL281609UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL281609Resp resp = new PolicyRelatedDocBL281609Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL281609/PolicyRelatedDocBL281609UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL281609Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL281609Resp> CreatePolicyAndDocuments281609(PolicyRelatedDocBL281609NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL281609Resp resp = new PolicyRelatedDocBL281609Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL281609/PolicyRelatedDocBL281609NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL281609Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL281609UpdResp> UpdatePolicyForm281609(PolicyBL281609UpdRecReq request, CancellationToken ct)
        {
            PolicyBL281609UpdResp resp = new PolicyBL281609UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL281609/PolicyBL281609UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL281609UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL331211Resp> CreateConsolidation331211(PolicyBL331211NewRecReq request, CancellationToken ct)
        {
            PolicyBL331211Resp resp = new PolicyBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL331211/PolicyBL331211NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL331211Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL331211Resp> UpdatePolicyAndDocuments331211(PolicyRelatedDocBL331211UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL331211Resp resp = new PolicyRelatedDocBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL331211/PolicyRelatedDocBL331211UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL331211Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL331211Resp> CreatePolicyAndDocuments331211(PolicyRelatedDocBL331211NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL331211Resp resp = new PolicyRelatedDocBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL331211/PolicyRelatedDocBL331211NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL331211Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL331211UpdResp> UpdatePolicyForm331211(PolicyBL331211UpdRecReq request, CancellationToken ct)
        {
            PolicyBL331211UpdResp resp = new PolicyBL331211UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL331211/PolicyBL331211UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL331211UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL041312Resp> CreateConsolidation041312(PolicyBL041312NewRecReq request, CancellationToken ct)
        {
            PolicyBL041312Resp resp = new PolicyBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL041312/PolicyBL041312NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL041312Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL041312Resp> UpdatePolicyAndDocuments041312(PolicyRelatedDocBL041312UpdRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL041312Resp resp = new PolicyRelatedDocBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL041312/PolicyRelatedDocBL041312UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL041312Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyRelatedDocBL041312Resp> CreatePolicyAndDocuments041312(PolicyRelatedDocBL041312NewRecReq request, CancellationToken ct)
        {
            PolicyRelatedDocBL041312Resp resp = new PolicyRelatedDocBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "/api/PolicyBL041312/PolicyRelatedDocBL041312NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyRelatedDocBL041312Resp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }
        public async Task<PolicyBL041312UpdResp> UpdatePolicyForm041312(PolicyBL041312UpdRecReq request, CancellationToken ct)
        {
            PolicyBL041312UpdResp resp = new PolicyBL041312UpdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/PolicyBL041312/PolicyBL041312UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyBL041312UpdResp>(request, url, ct);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }

            return resp;
        }

    }
}
