using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.DTO;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Response;
using Evaluation.UI.Wrapper;
using System.Net;
using System.Security.Claims;

namespace Evaluation.UI.Consume.Api
{
    
    public class UserApi : IUserApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public UserApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<UserCredResp> Login(UserCredViewModel request, CancellationToken ct)
        {
            UserCredResp resp = new UserCredResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Login/AuthenticateUser";
                resp = await _httpClientHelper.PostApiRequestModelAsync<UserCredResp>(request, url, ct);
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
        public async Task<UserDto> GetUserClaims(IEnumerable<Claim> claims)
        {
            UserDto userDto = new UserDto();
            userDto.EmailAdress = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            userDto.CorrelationID = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return userDto;
        }
    }
}
