
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request;
using Evaluation.UI.Request.AF1ColHeader;
using Evaluation.UI.Request.Global;
using Evaluation.UI.Response;
using Evaluation.UI.Response.AF1ColHeader;
using Evaluation.UI.Response.Global;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class GeneralListApi : IGeneralListApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public GeneralListApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<GeneralListResp> GetAllGeneralLists(GenericEmptyReq request, CancellationToken ct)
        {
            GeneralListResp resp = new GeneralListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lookup/LookupFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<GeneralListResp>(request, url, ct);
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
        public async Task<AF1ColHeaderResp> CheckExcelImportValidation(AF1ColHeaderFindWithColFilterReq request, CancellationToken ct)
        {
            AF1ColHeaderResp resp = new AF1ColHeaderResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/AF1/AF1ColHeaderFindWithColFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<AF1ColHeaderResp>(request, url, ct);
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
        public async Task<GlobalLookupFindAllResp> GetGlobalLookupFindAll(GlobalLookupFindAllReq request, CancellationToken ct)
        {
            GlobalLookupFindAllResp resp = new GlobalLookupFindAllResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/GlobalLookup/GlobalLookupFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<GlobalLookupFindAllResp>(request, url, ct);
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
