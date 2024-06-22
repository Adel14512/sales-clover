using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request.Renewal;
using Evaluation.UI.Response.Renewal;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class RenewalApi: IRenewalApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public RenewalApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
		public async Task<RenewalPolicyResp> Policy(RenewalPolicyReq request, CancellationToken ct)
		{
			RenewalPolicyResp resp = new RenewalPolicyResp();
			try
			{
				var url = _configuration["ApiURL"] + "api/Renwal/RenewalPolicyFindAll";
				resp = await _httpClientHelper.PostApiRequestModelAsync<RenewalPolicyResp>(request, url, ct);
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
		public async Task<RenewalParameterResp> Parameters(RenewalParameterReq request, CancellationToken ct)
		{
			RenewalParameterResp resp = new RenewalParameterResp();
			try
			{
				var url = _configuration["ApiURL"] + "api/Renwal/RenewalParameterFindAll";
				resp = await _httpClientHelper.PostApiRequestModelAsync<RenewalParameterResp>(request, url, ct);
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
