using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request;
using Evaluation.UI.Request.Lead;
using Evaluation.UI.Response;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class LeadApi :ILeadApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public LeadApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<GenericWebResponse> CreateLead(LeadNewRecReq request, CancellationToken ct)
        {
            GenericWebResponse resp = new GenericWebResponse();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lead/LeadNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<GenericWebResponse>(request, url, ct);
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
        public async Task<LeadLookupFindAllResp> GetLookupLead(LeadLookupFindAllReq request, CancellationToken ct)
        {
            LeadLookupFindAllResp resp = new LeadLookupFindAllResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lookup/LeadLookupFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<LeadLookupFindAllResp>(request, url, ct);
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
        public async Task<GenericWebResponse> UpdateLead(LeadNewRecReq request, CancellationToken ct)
        {
            GenericWebResponse resp = new GenericWebResponse();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lead/LeadUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<GenericWebResponse>(request, url, ct);
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
        public async Task<LeadFindAllResp> GetAllLeads(LeadFindAllReq request, CancellationToken ct)
        {
            LeadFindAllResp resp = new LeadFindAllResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lead/LeadFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<LeadFindAllResp>(request, url, ct);
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
