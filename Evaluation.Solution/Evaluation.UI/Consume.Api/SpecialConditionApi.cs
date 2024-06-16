using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request.SpecialCondition;
using Evaluation.UI.Response.SpecialCondition;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class SpecialConditionApi : ISpecialConditionApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public SpecialConditionApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<SpecialConditionResp> InsertSpecialCondition(SpecialConditionNewRecReq request, CancellationToken ct)
        {
            SpecialConditionResp resp = new SpecialConditionResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/SpecialCondition/SpecialConditionNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SpecialConditionResp>(request, url, ct);
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
        public async Task<SpecialConditionResp> FindSpecialCondition(SpecialConditionFindWithColFilterReq request, CancellationToken ct)
        {
            SpecialConditionResp resp = new SpecialConditionResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/SpecialCondition/SpecialConditionFindWithColFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SpecialConditionResp>(request, url, ct);
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
