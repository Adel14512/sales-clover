using AutoMapper;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Response;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class ContactApi : IContactApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ContactApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration, IMapper mapper)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<GenericWebResponse> CreateContactApi(ContactCreateReq request,CancellationToken ct)
        {
            GenericWebResponse resp = new GenericWebResponse();
            try
            {
                var url = _configuration["ApiURL"] + "api/Contact/ContactNewRec";
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
        public async Task<GenericWebResponse> EditContactApi(ContactCreateReq request, CancellationToken ct)
        {
            GenericWebResponse resp = new GenericWebResponse();
            try
            {
                var url = _configuration["ApiURL"] + "api/Contact/ContactUpdRec";
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
        public async Task<ContactVM> GetContactByIDApi(GenericIdReq request, CancellationToken ct)
        {
            ContactVM contactVM = new ContactVM();
            try
            {
                var url = _configuration["ApiURL"] + "api/Contact/ContactFindWithRecIdFilter";
                var resp = await _httpClientHelper.PostApiRequestModelAsync<ContactSearchResp>(request, url, ct);
                var contact = resp.contact[0];
                contactVM = _mapper.Map<ContactVM>(contact);
            }
            catch (WebException ex)
            {
                var response = _apiService.HandleHttpResponse(ex);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex);

            }
            return contactVM;
        }
    }
}
