using Evaluation.UI.Response.BL080501;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL080501;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Response;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Wrapper;
using System.Net;
using Evaluation.UI.Response.BL021502;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Response.BL051807;
using Evaluation.UI.Response.BL291908;
using Evaluation.UI.Request.BL291908;
using Evaluation.UI.Response.BL281609;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Response.BL311703;
using Evaluation.UI.Request.BL311703;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Request.BL051807;
using Evaluation.UI.Request.BLDuplication;
using Evaluation.UI.Response.BLDuplication;
using Evaluation.UI.Response.BL090703;
using Evaluation.UI.Request.BL090703;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Response.BL010602;
using Evaluation.UI.Request.BL010602;
using Evaluation.UI.Response.BL030904;
using Evaluation.UI.Request.BL030904;
using Evaluation.UI.Response.BL061005;
using Evaluation.UI.Request.BL061005;

namespace Evaluation.UI.Consume.Api
{
    public class BusinessLineApi : IBusinessLineApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public BusinessLineApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<SalesTransactionMenuFindWithColFilterResp> GetTreeViewBusinessLine(SalesTransactionMenuFindWithColFilterReq request, CancellationToken ct)
        {
            SalesTransactionMenuFindWithColFilterResp resp = new SalesTransactionMenuFindWithColFilterResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/SalesTransaction/SalesTransactionMenuFindWithColFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionMenuFindWithColFilterResp>(request, url, ct);
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
        public async Task<SalesTransactionFindWithContactIdFilterResp> GetDashboard(SalesTransactionFindWithContactIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionFindWithContactIdFilterResp resp = new SalesTransactionFindWithContactIdFilterResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/SalesTransaction/SalesTransactionFindWithContactIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionFindWithContactIdFilterResp>(request, url, ct);
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
        public async Task<SalesTransactionBL080501CQResp> GetCQAF8(SalesTransactionBL080501FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL080501CQResp resp = new SalesTransactionBL080501CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL080501CQResp> GetCQAF8Short(SalesTransactionBL080501FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL080501CQResp resp = new SalesTransactionBL080501CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501FindCQShortWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806CQResp> GetCQAF07Short(SalesTransactionBL070806FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL070806CQResp resp = new SalesTransactionBL070806CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806FindCQShortWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL281609CQResp> GetCQAF28Short(SalesTransactionBL281609FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL281609CQResp resp = new SalesTransactionBL281609CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL281609/SalesTransactionBL281609FindCQShortWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL281609CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL301401CQResp> GetCQAF30(SalesTransactionBL301401FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL301401CQResp resp = new SalesTransactionBL301401CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL301401/SalesTransactionBL301401FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL301401CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110CQResp> GetCQAF32(SalesTransactionBL321110FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL321110CQResp resp = new SalesTransactionBL321110CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL021502CQResp> GetCQAF02(SalesTransactionBL021502FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL021502CQResp resp = new SalesTransactionBL021502CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL021502/SalesTransactionBL021502FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL021502CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL010602CQResp> GetCQAF01(SalesTransactionBL010602FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL010602CQResp resp = new SalesTransactionBL010602CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL010602/SalesTransactionBL010602FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL010602CQResp>(request, url, ct);
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

        public async Task<SalesTransactionBL051807CQResp> GetCQAF05(SalesTransactionBL051807FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL051807CQResp resp = new SalesTransactionBL051807CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL051807/SalesTransactionBL051807FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL051807CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL090703CQResp> GetCQAF09(SalesTransactionBL090703FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL090703CQResp resp = new SalesTransactionBL090703CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL090703/SalesTransactionBL090703FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL090703CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806CQResp> GetCQAF07(SalesTransactionBL070806FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL070806CQResp resp = new SalesTransactionBL070806CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL281609CQResp> GetCQAF28(SalesTransactionBL281609FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL281609CQResp resp = new SalesTransactionBL281609CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL281609/SalesTransactionBL281609FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL281609CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL311703CQResp> GetCQAF31(SalesTransactionBL311703FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL311703CQResp resp = new SalesTransactionBL311703CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL311703/SalesTransactionBL311703FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL311703CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL291908CQResp> GetCQAF29(SalesTransactionBL291908FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL291908CQResp resp = new SalesTransactionBL291908CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL291908/SalesTransactionBL291908FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL291908CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312CQResp> GetCQAF4(SalesTransactionBL041312FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL041312CQResp resp = new SalesTransactionBL041312CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312CQResp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211CQResp> GetCQAF33(SalesTransactionBL331211FindCQWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL331211CQResp resp = new SalesTransactionBL331211CQResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211FindCQWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211CQResp>(request, url, ct);
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
        public async Task<BusinessLineDuplicationResp> DuplicateTransaction(BusinessLineDuplicationNewRecReq request, CancellationToken ct)
        {
            BusinessLineDuplicationResp resp = new BusinessLineDuplicationResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BusinessLine/BusinessLineDupRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<BusinessLineDuplicationResp>(request, url, ct);
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
        public async Task<SalesTransactionBL080501CQShortFulListResp> DetailedShortLongList(SalesTransactionBL080501FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL080501CQShortFulListResp resp = new SalesTransactionBL080501CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL301401CQShortFulListResp> DetailedShortLongList301401(SalesTransactionBL301401FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL301401CQShortFulListResp resp = new SalesTransactionBL301401CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL301401/SalesTransactionBL301401FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL301401CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110CQShortFulListResp> DetailedShortLongList321110(SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL321110CQShortFulListResp resp = new SalesTransactionBL321110CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL090703CQShortFulListResp> DetailedShortLongList090703(SalesTransactionBL090703FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL090703CQShortFulListResp resp = new SalesTransactionBL090703CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL090703/SalesTransactionBL090703FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL090703CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806CQShortFulListResp> DetailedShortLongList070806(SalesTransactionBL070806FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL070806CQShortFulListResp resp = new SalesTransactionBL070806CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL010602CQShortFulListResp> DetailedShortLongList010602(SalesTransactionBL010602FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL010602CQShortFulListResp resp = new SalesTransactionBL010602CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL010602/SalesTransactionBL010602FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL010602CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL021502CQShortFulListResp> DetailedShortLongList021502(SalesTransactionBL021502FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL021502CQShortFulListResp resp = new SalesTransactionBL021502CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL021502/SalesTransactionBL021502FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL021502CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL281609CQShortFulListResp> DetailedShortLongList281609(SalesTransactionBL281609FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL281609CQShortFulListResp resp = new SalesTransactionBL281609CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL281609/SalesTransactionBL281609FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL281609CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211CQShortFulListResp> DetailedShortLongList331211(SalesTransactionBL331211FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL331211CQShortFulListResp resp = new SalesTransactionBL331211CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL311703CQShortFulListResp> DetailedShortLongList311703(SalesTransactionBL311703FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL311703CQShortFulListResp resp = new SalesTransactionBL311703CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL311703/SalesTransactionBL311703FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL311703CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL291908CQShortFulListResp> DetailedShortLongList291908(SalesTransactionBL291908FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL291908CQShortFulListResp resp = new SalesTransactionBL291908CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL291908/SalesTransactionBL291908FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL291908CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL051807CQShortFulListResp> DetailedShortLongList051807(SalesTransactionBL051807FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL051807CQShortFulListResp resp = new SalesTransactionBL051807CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL051807/SalesTransactionBL051807FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL051807CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL061005CQShortFulListResp> DetailedShortLongList061005(SalesTransactionBL061005FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL061005CQShortFulListResp resp = new SalesTransactionBL061005CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL061005/SalesTransactionBL061005FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL061005CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312CQShortFulListResp> DetailedShortLongList041312(SalesTransactionBL041312FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL041312CQShortFulListResp resp = new SalesTransactionBL041312CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312CQShortFulListResp>(request, url, ct);
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
        public async Task<SalesTransactionBL030904CQShortFulListResp> DetailedShortLongList030904(SalesTransactionBL030904FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL030904CQShortFulListResp resp = new SalesTransactionBL030904CQShortFulListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL030904/SalesTransactionBL030904FindShortFullWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL030904CQShortFulListResp>(request, url, ct);
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
