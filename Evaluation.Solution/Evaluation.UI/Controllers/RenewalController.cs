using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Models.Renewal;
using Evaluation.UI.Request.Renewal;
using Evaluation.UI.Response.Renewal;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evaluation.UI.Controllers
{
    public class RenewalController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly IGeneralListApi _generalListApi;
		private readonly IContactApi _contactApi;
		private readonly IHttpClientHelper _httpClientHelper;
		private readonly IUserApi _userApi;
		private readonly IRenewalApi _renewalApi;
		public RenewalController(IConfiguration configuration, IGeneralListApi generalListApi, IHttpClientHelper httpClientHelper, IUserApi userApi, IRenewalApi renewalApi)
		{
			_configuration = configuration;
			_generalListApi = generalListApi;
			_httpClientHelper = httpClientHelper;
			_userApi = userApi;
			_renewalApi = renewalApi;
		}
		[Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
		public async Task<IActionResult> Parameters(CancellationToken ct)
        {
            RenewalParameterReq request = new RenewalParameterReq();
            var user = await _userApi.GetUserClaims(User.Claims);
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            RenewalParameterResp result = await _renewalApi.Parameters(request, ct);
			ParametersVM parametersVM = new ParametersVM();
			parametersVM.RenewalParameter = result.RenewalParameter;

			return View(parametersVM);
        }
		[Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
		public async Task<IActionResult> Policies(CancellationToken ct)
		{
			RenewalPolicyReq request = new RenewalPolicyReq();
			var user = await _userApi.GetUserClaims(User.Claims);
			request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
			request.WebRequestCommon.UserName = user.EmailAdress;
			RenewalPolicyResp result = await _renewalApi.Policy(request, ct);
			PolicyVM parametersVM = new PolicyVM();
			parametersVM.RenewalPolicy = result.RenewalPolicy;
			return View(parametersVM);
		}
	}
}
