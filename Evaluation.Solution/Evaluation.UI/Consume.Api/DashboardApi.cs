
using Evaluation.UI.Request.Dashboard;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Response.Dashboard;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{

    public class DashboardApi : IDashboardApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public DashboardApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<ProductPriceControlResp> ProductPriceControFindAll(ProductPriceControlReq request, CancellationToken ct)
        {
            ProductPriceControlResp resp = new ProductPriceControlResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Dashboard/ProductPriceControFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductPriceControlResp>(request, url, ct);
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
        public async Task<TicketHistoryResp> TicketHistoryFindDataWithNbrDaysFilter(TicketHistoryReq request, CancellationToken ct)
        {
            TicketHistoryResp resp = new TicketHistoryResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Dashboard/TicketHistoryFindDataWithNbrDaysFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<TicketHistoryResp>(request, url, ct);
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
		public async Task<PolicyInquiryResp> PolicyInquiry(PolicyInquiryReq request, CancellationToken ct)
		{
			PolicyInquiryResp resp = new PolicyInquiryResp();
			try
			{
				var url = _configuration["ApiURL"] + "api/Dashboard/PolicyInquiryFindAll";
				resp = await _httpClientHelper.PostApiRequestModelAsync<PolicyInquiryResp>(request, url, ct);
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
