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
    public class ChannelApi : IChannelApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public ChannelApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<ChannelResp> GetAllChannel(GenericEmptyReq request, CancellationToken ct)
        {
            ChannelResp resp = new ChannelResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lookup/ChannelFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ChannelResp>(request, url, ct);
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
        public async Task<ChannelResp> CreateChannel(ChannelNewRecReq request, CancellationToken ct)
        {
            ChannelResp resp = new ChannelResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lookup/ChannelNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ChannelResp>(request, url, ct);
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
        public async Task<ChannelResp> EditChannel(ChannelNewRecReq request, CancellationToken ct)
        {
            ChannelResp resp = new ChannelResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lookup/ChannelUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ChannelResp>(request, url, ct);
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
        public async Task<ChannelResp> GetChannelByID(GenericIdReq request, CancellationToken ct)
        {
            ChannelResp resp = new ChannelResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Lookup/ChannelNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ChannelResp>(request, url, ct);
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
