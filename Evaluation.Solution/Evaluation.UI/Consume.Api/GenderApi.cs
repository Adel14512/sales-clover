using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request;
using Evaluation.UI.Response;
using Evaluation.UI.Wrapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class GenderApi :IGenderApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public GenderApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<List<GenderResp>> GetAllGender(GenericEmptyReq request,CancellationToken ct)
        {
            List<GenderResp> resp = new List<GenderResp>();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lookup/GenderFindAll";
                resp = await _httpClientHelper.PostApiRequestAsync<GenderResp>(request, url, ct);
              //  var result = _httpClientHelper.CallRestClient(url, "POST", request);
              //  resp = JsonConvert.DeserializeObject<List<GenderResp>>(result);
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
