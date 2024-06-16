using Evaluation.CAL.Request.BL321110;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Wrapper;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Evaluation.UI.Consume.Api
{
    public class SlipApi : ISlipApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public SlipApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip2(SalesTransactionBL321110UpdSlip2RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110UpdSlip2Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip3(SalesTransactionBL321110UpdSlip3RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110UpdSlip3Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip4(SalesTransactionBL321110UpdSlip4RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110UpdSlip4Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip5(SalesTransactionBL321110UpdSlip5RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110UpdSlip5Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110DetailsResp> SalesTransactionBL321110DetailsUpdSlip2(SalesTransactionBL321110DetailsUpdSlip2RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110DetailsResp resp = new SalesTransactionBL321110DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110DetailsUpdSlip2Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110DetailsResp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110DetailsResp> SalesTransactionBL321110DetailsUpdSlip3(SalesTransactionBL321110DetailsUpdSlip3RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110DetailsResp resp = new SalesTransactionBL321110DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110DetailsUpdSlip3Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110DetailsResp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110DetailsResp> SalesTransactionBL321110DetailsUpdSlip4(SalesTransactionBL321110DetailsUpdSlip4RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110DetailsResp resp = new SalesTransactionBL321110DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110DetailsUpdSlip4Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110DetailsResp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110DetailsPricesResp> SalesTransactionBL321110DetailsPricesNewRec(SalesTransactionBL321110DetailsPricesNewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110DetailsPricesResp resp = new SalesTransactionBL321110DetailsPricesResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110DetailsPricesNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110DetailsPricesResp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip2(SalesTransactionBL331211UpdSlip2RecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211UpdSlip2Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip3(SalesTransactionBL331211UpdSlip3RecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211UpdSlip3Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip4(SalesTransactionBL331211UpdSlip4RecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211UpdSlip4Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip5(SalesTransactionBL331211UpdSlip5RecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211UpdSlip5Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211DetailsResp> SalesTransactionBL331211DetailsUpdSlip3(SalesTransactionBL331211DetailsUpdSlip3RecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211DetailsResp resp = new SalesTransactionBL331211DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211DetailsUpdSlip3Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211DetailsResp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211DetailsResp> SalesTransactionBL331211DetailsUpdSlip4(SalesTransactionBL331211DetailsUpdSlip4RecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211DetailsResp resp = new SalesTransactionBL331211DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211DetailsUpdSlip4Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211DetailsResp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211DetailsPricesResp> SalesTransactionBL331211DetailsPricesNewRec(SalesTransactionBL331211DetailsPricesNewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211DetailsPricesResp resp = new SalesTransactionBL331211DetailsPricesResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211DetailsPricesNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211DetailsPricesResp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip2(SalesTransactionBL041312UpdSlip2RecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312UpdSlip2Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip3(SalesTransactionBL041312UpdSlip3RecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312UpdSlip3Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip4(SalesTransactionBL041312UpdSlip4RecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312UpdSlip4Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip5(SalesTransactionBL041312UpdSlip5RecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312UpdSlip5Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312DetailsResp> SalesTransactionBL041312DetailsUpdSlip3(SalesTransactionBL041312DetailsUpdSlip3RecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312DetailsResp resp = new SalesTransactionBL041312DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312DetailsUpdSlip3Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312DetailsResp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312DetailsResp> SalesTransactionBL041312DetailsUpdSlip4(SalesTransactionBL041312DetailsUpdSlip4RecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312DetailsResp resp = new SalesTransactionBL041312DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312DetailsUpdSlip4Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312DetailsResp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312DetailsPricesResp> SalesTransactionBL041312DetailsPricesNewRec(SalesTransactionBL041312DetailsPricesNewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312DetailsPricesResp resp = new SalesTransactionBL041312DetailsPricesResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312DetailsPricesNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312DetailsPricesResp>(request, url, ct);
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
