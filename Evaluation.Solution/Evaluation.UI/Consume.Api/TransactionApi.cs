
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL010602;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Request.BL030904;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL051807;
using Evaluation.UI.Request.BL061005;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Request.BL080501;
using Evaluation.UI.Request.BL090703;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Request.BL291908;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL311703;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Request.BL77;
using Evaluation.UI.Response;
using Evaluation.UI.Response.BL010602;
using Evaluation.UI.Response.BL021502;
using Evaluation.UI.Response.BL030904;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL051807;
using Evaluation.UI.Response.BL061005;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Response.BL080501;
using Evaluation.UI.Response.BL090703;
using Evaluation.UI.Response.BL281609;
using Evaluation.UI.Response.BL291908;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Response.BL311703;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Response.BL77;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class TransactionApi : ITransactionApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly IApiService _apiService;
        public TransactionApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IConfiguration configuration, IApiService apiService)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _configuration = configuration;
            _apiService = apiService;
        }
        public async Task<SalesTransactionBL77RecResp> CreateBl77(SalesTransactionBL77NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL77RecResp resp = new SalesTransactionBL77RecResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL77/SalesTransactionBL77NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL77RecResp>(request, url, ct);
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
        public async Task<SalesTransactionBL77RecResp> UpdateBl77(SalesTransactionBL77UpdRecReq request, CancellationToken ct)
        {
            SalesTransactionBL77RecResp resp = new SalesTransactionBL77RecResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL77/SalesTransactionBL77UpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL77RecResp>(request, url, ct);
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
        public async Task<SalesTransactionBL77RecResp> GetBl77(SalesTransactionBL77FindWithColFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL77RecResp resp = new SalesTransactionBL77RecResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL77/SalesTransactionBL77FindWithColFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL77RecResp>(request, url, ct);
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
        public async Task<BusinessLineRelatedDocFindWithBusinessLineIdFilterResp> GetDocumentByBussinessID(BusinessLineRelatedDocFindWithBusinessLineIdFilterReq request, CancellationToken ct)
        {
            BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resp = new BusinessLineRelatedDocFindWithBusinessLineIdFilterResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BusinessLine/BusinessLineRelatedDocFindWithBusinessLineCodeFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<BusinessLineRelatedDocFindWithBusinessLineIdFilterResp>(request, url, ct);
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
        public async Task<SalesTransactionBL301401Resp> CreateAF1_30(SalesTransactionBL301401NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL301401Resp resp = new SalesTransactionBL301401Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL301401/SalesTransactionBL301401NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL301401Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110Resp> CreateAF1_32(SalesTransactionBL321110NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110NewRec";
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
       
        public async Task<SalesTransactionBL080501Resp> CreateAf8(SalesTransactionBL080501NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL080501Resp resp = new SalesTransactionBL080501Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL080501Resp> EditAf8Consolidation(SalesTransactionBL080501UpdGlobalRecReq request, CancellationToken ct)
        {
            SalesTransactionBL080501Resp resp = new SalesTransactionBL080501Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501UpdGlobalRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211Resp> EditAf33Consolidation(SalesTransactionBL331211UpdGlobalRecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211UpdGlobalRec";
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
        public async Task<SalesTransactionBL321110Resp> EditAf32Consolidation(SalesTransactionBL321110UpdGlobalRecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110UpdGlobalRec";
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
        public async Task<SalesTransactionBL041312Resp> EditAF04Consolidation(SalesTransactionBL041312UpdGlobalRecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312UpdGlobalRec";
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

        public async Task<SalesTransactionBL080501Resp> UpdateAf8(SalesTransactionBL080501UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL080501Resp resp = new SalesTransactionBL080501Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL301401Resp> UpdateAf30(SalesTransactionBL301401UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL301401Resp resp = new SalesTransactionBL301401Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL301401/SalesTransactionBL301401UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL301401Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110Resp> UpdateAf32(SalesTransactionBL321110UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110UpdAF1Rec";
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
        public async Task<SalesTransactionBL080501Resp> GetAf8(SalesTransactionBL080501FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL080501Resp resp = new SalesTransactionBL080501Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110Resp> GetAf32(SalesTransactionBL321110FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL321110Resp resp = new SalesTransactionBL321110Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110FindAF1WithRecIdFilter";
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
        public async Task<SalesTransactionBL331211Resp> GetAf33(SalesTransactionBL331211FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211FindAF1WithRecIdFilter";
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
        public async Task<SalesTransactionBL041312Resp> GetAf04(SalesTransactionBL041312FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312FindAF1WithRecIdFilter";
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
        public async Task<SalesTransactionBL301401Resp> GetAf30(SalesTransactionBL301401FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL301401Resp resp = new SalesTransactionBL301401Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL301401/SalesTransactionBL301401FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL301401Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL021502Resp> CreateAF1_2(SalesTransactionBL021502NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL021502Resp resp = new SalesTransactionBL021502Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL021502/SalesTransactionBL021502NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL021502Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL021502Resp> UpdateAF1_2(SalesTransactionBL021502UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL021502Resp resp = new SalesTransactionBL021502Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL021502/SalesTransactionBL021502UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL021502Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL021502Resp> GetAF1_2(SalesTransactionBL021502FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL021502Resp resp = new SalesTransactionBL021502Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL021502/SalesTransactionBL021502FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL021502Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312Resp> CreateAF1_4(SalesTransactionBL041312NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312NewRec";
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
        public async Task<SalesTransactionBL041312Resp> UpdateAF1_4(SalesTransactionBL041312UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312UpdAF1Rec";
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
        public async Task<SalesTransactionBL041312Resp> GetAF1_4(SalesTransactionBL041312FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL041312Resp resp = new SalesTransactionBL041312Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312FindAF1WithRecIdFilter";
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
        public async Task<SalesTransactionBL051807Resp> CreateAF1_5(SalesTransactionBL051807NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL051807Resp resp = new SalesTransactionBL051807Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL051807/SalesTransactionBL051807NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL051807Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL051807Resp> UpdateAF1_5(SalesTransactionBL051807UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL051807Resp resp = new SalesTransactionBL051807Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL051807/SalesTransactionBL051807UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL051807Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL051807Resp> GetAF1_5(SalesTransactionBL051807FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL051807Resp resp = new SalesTransactionBL051807Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL051807/SalesTransactionBL051807FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL051807Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211Resp> CreateAF1_33(SalesTransactionBL331211NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211NewRec";
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
        public async Task<SalesTransactionBL331211Resp> UpdateAF1_33(SalesTransactionBL331211UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211UpdAF1Rec";
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
        public async Task<SalesTransactionBL331211Resp> GetAF1_33(SalesTransactionBL331211FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL331211Resp resp = new SalesTransactionBL331211Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211FindAF1WithRecIdFilter";
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
        public async Task<SalesTransactionBL311703Resp> CreateAF1_31(SalesTransactionBL311703NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL311703Resp resp = new SalesTransactionBL311703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL311703/SalesTransactionBL311703NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL311703Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL311703Resp> UpdateAF1_31(SalesTransactionBL311703UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL311703Resp resp = new SalesTransactionBL311703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL311703/SalesTransactionBL311703UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL311703Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL311703Resp> GetAF1_31(SalesTransactionBL311703FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL311703Resp resp = new SalesTransactionBL311703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL311703/SalesTransactionBL311703FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL311703Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL281609Resp> CreateAF1_28(SalesTransactionBL281609NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL281609Resp resp = new SalesTransactionBL281609Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL281609/SalesTransactionBL281609NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL281609Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL281609Resp> UpdateAF1_28(SalesTransactionBL281609UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL281609Resp resp = new SalesTransactionBL281609Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL281609/SalesTransactionBL281609UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL281609Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL281609Resp> GetAF1_28(SalesTransactionBL281609FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL281609Resp resp = new SalesTransactionBL281609Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL281609/SalesTransactionBL281609FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL281609Resp>(request, url, ct);
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
        
        public async Task<SalesTransactionBL291908Resp> CreateAF1_29(SalesTransactionBL291908NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL291908Resp resp = new SalesTransactionBL291908Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL291908/SalesTransactionBL291908NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL291908Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL291908Resp> UpdateAF1_29(SalesTransactionBL291908UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL291908Resp resp = new SalesTransactionBL291908Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL291908/SalesTransactionBL291908UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL291908Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL291908Resp> GetAF1_29(SalesTransactionBL291908FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL291908Resp resp = new SalesTransactionBL291908Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL291908/SalesTransactionBL291908FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL291908Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL080501SlipResp> Slip080501(SalesTransactionBL080501FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL080501SlipResp resp = new SalesTransactionBL080501SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL080501/SalesTransactionBL080501FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL080501SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL010602SlipResp> Slip010602(SalesTransactionBL010602FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL010602SlipResp resp = new SalesTransactionBL010602SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL010602/SalesTransactionBL010602FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL010602SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806SlipResp> Slip070806(SalesTransactionBL070806FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL070806SlipResp resp = new SalesTransactionBL070806SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL090703SlipResp> Slip090703(SalesTransactionBL090703FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL090703SlipResp resp = new SalesTransactionBL090703SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL090703/SalesTransactionBL090703FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL090703SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL021502SlipResp> Slip021502(SalesTransactionBL021502FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL021502SlipResp resp = new SalesTransactionBL021502SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL021502/SalesTransactionBL021502FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL021502SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL030904SlipResp> Slip030904(SalesTransactionBL030904FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL030904SlipResp resp = new SalesTransactionBL030904SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL030904/SalesTransactionBL030904FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL030904SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL051807SlipResp> Slip051807(SalesTransactionBL051807FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL051807SlipResp resp = new SalesTransactionBL051807SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL051807/SalesTransactionBL051807FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL051807SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL041312SlipResp> Slip041312(SalesTransactionBL041312FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL041312SlipResp resp = new SalesTransactionBL041312SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL041312SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL291908SlipResp> Slip291908(SalesTransactionBL291908FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL291908SlipResp resp = new SalesTransactionBL291908SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL291908/SalesTransactionBL291908FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL291908SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL331211SlipResp> Slip331211(SalesTransactionBL331211FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL331211SlipResp resp = new SalesTransactionBL331211SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL331211SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL301401SlipResp> Slip301401(SalesTransactionBL301401FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL301401SlipResp resp = new SalesTransactionBL301401SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL301401/SalesTransactionBL301401FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL301401SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110SlipResp> Slip321110(SalesTransactionBL321110FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL321110SlipResp resp = new SalesTransactionBL321110SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL321110SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL281609SlipResp> Slip281609(SalesTransactionBL281609FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL281609SlipResp resp = new SalesTransactionBL281609SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL281609/SalesTransactionBL281609FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL281609SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL311703SlipResp> Slip311703(SalesTransactionBL311703FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL311703SlipResp resp = new SalesTransactionBL311703SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL311703/SalesTransactionBL311703FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL311703SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL061005SlipResp> Slip061005(SalesTransactionBL061005FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL061005SlipResp resp = new SalesTransactionBL061005SlipResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL061005/SalesTransactionBL061005FindSlipWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL061005SlipResp>(request, url, ct);
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
        public async Task<SalesTransactionBL010602Resp> CreateAF1_01(SalesTransactionBL010602NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL010602Resp resp = new SalesTransactionBL010602Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL010602/SalesTransactionBL010602NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL010602Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL010602Resp> UpdateAF1_01(SalesTransactionBL010602UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL010602Resp resp = new SalesTransactionBL010602Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL010602/SalesTransactionBL010602UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL010602Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL010602Resp> GetAF1_01(SalesTransactionBL010602FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL010602Resp resp = new SalesTransactionBL010602Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL010602/SalesTransactionBL010602FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL010602Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL030904Resp> CreateAF1_03(SalesTransactionBL030904NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL030904Resp resp = new SalesTransactionBL030904Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL030904/SalesTransactionBL030904NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL030904Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL030904Resp> UpdateAF1_03(SalesTransactionBL030904UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL030904Resp resp = new SalesTransactionBL030904Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL030904/SalesTransactionBL030904UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL030904Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL030904Resp> GetAF1_03(SalesTransactionBL030904FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL030904Resp resp = new SalesTransactionBL030904Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL030904/SalesTransactionBL030904FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL030904Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL090703Resp> CreateAF1_09(SalesTransactionBL090703NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL090703Resp resp = new SalesTransactionBL090703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL090703/SalesTransactionBL090703NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL090703Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL090703Resp> UpdateAF1_09(SalesTransactionBL090703UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL090703Resp resp = new SalesTransactionBL090703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL090703/SalesTransactionBL090703UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL090703Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL090703Resp> GetAF1_09(SalesTransactionBL090703FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL090703Resp resp = new SalesTransactionBL090703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL090703/SalesTransactionBL090703FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL090703Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL090703Resp> EditAf9Consolidation(SalesTransactionBL090703UpdGlobalRecReq request, CancellationToken ct)
        {
            SalesTransactionBL090703Resp resp = new SalesTransactionBL090703Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL090703/SalesTransactionBL090703UpdGlobalRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL090703Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806Resp> CreateAF1_07(SalesTransactionBL070806NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL070806Resp resp = new SalesTransactionBL070806Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806Resp> UpdateAF1_07(SalesTransactionBL070806UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL070806Resp resp = new SalesTransactionBL070806Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806Resp> GetAF1_07(SalesTransactionBL070806FindAF1WithRecIdFilterReq request, CancellationToken ct)
        {
            SalesTransactionBL070806Resp resp = new SalesTransactionBL070806Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL070806Resp> EditAf7Consolidation(SalesTransactionBL070806UpdGlobalRecReq request, CancellationToken ct)
        {
            SalesTransactionBL070806Resp resp = new SalesTransactionBL070806Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL070806/SalesTransactionBL070806UpdGlobalRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL070806Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL061005Resp> CreateAF1_06(SalesTransactionBL061005NewRecReq request, CancellationToken ct)
        {
            SalesTransactionBL061005Resp resp = new SalesTransactionBL061005Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL061005/SalesTransactionBL061005NewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL061005Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL061005Resp> UpdateAF1_06(SalesTransactionBL061005UpdAF1RecReq request, CancellationToken ct)
        {
            SalesTransactionBL061005Resp resp = new SalesTransactionBL061005Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL061005/SalesTransactionBL061005UpdAF1Rec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL061005Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL061005Resp> GetAF1_06(SalesTransactionBL061005FindAF1WithRecIdReq request, CancellationToken ct)
        {
            SalesTransactionBL061005Resp resp = new SalesTransactionBL061005Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL061005/SalesTransactionBL061005FindAF1WithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL061005Resp>(request, url, ct);
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
        public async Task<SalesTransactionBL321110DetailsResp> GetAF1_32Details(SalesTransactionBL321110DetailsFindWithSalesTrxIdReq request, CancellationToken ct)
        {
            SalesTransactionBL321110DetailsResp resp = new SalesTransactionBL321110DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL321110/SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter";
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
        public async Task<SalesTransactionBL331211DetailsResp> GetAF1_33Details(SalesTransactionBL331211DetailsFindWithSalesTrxIdReq request, CancellationToken ct)
        {
            SalesTransactionBL331211DetailsResp resp = new SalesTransactionBL331211DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL331211/SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter";
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
        public async Task<SalesTransactionBL041312DetailsResp> GetAF1_04Details(SalesTransactionBL041312DetailsFindWithSalesTrxIdReq request, CancellationToken ct)
        {
            SalesTransactionBL041312DetailsResp resp = new SalesTransactionBL041312DetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL041312/SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter";
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
        public async Task<SalesTransactionBL301401Resp> EditAF30Consolidation(SalesTransactionBL301401UpdGlobalRecReq request, CancellationToken ct)
        {
            SalesTransactionBL301401Resp resp = new SalesTransactionBL301401Resp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BL301401/SalesTransactionBL301401UpdGlobalRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL301401Resp>(request, url, ct);
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
        //public async Task<SalesTransactionBL061005Resp> EditAf6Consolidation(SalesTransactionBL061005UpdGlobalRecReq request, CancellationToken ct)
        //{
        //    SalesTransactionBL061005Resp resp = new SalesTransactionBL061005Resp();
        //    try
        //    {
        //        var url = _configuration["ApiURL"] + "api/BL061005/SalesTransactionBL061005UpdGlobalRec";
        //        resp = await _httpClientHelper.PostApiRequestModelAsync<SalesTransactionBL061005Resp>(request, url, ct);
        //    }
        //    catch (WebException ex)
        //    {
        //        var response = _apiService.HandleHttpResponse(ex);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(string.Empty, ex);

        //    }

        //    return resp;
        //}
    }
}