using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Models;
using Evaluation.UI.Models.Dashboard;
using Evaluation.UI.Request;
using Evaluation.UI.Request.Dashboard;
using Evaluation.UI.Response;
using Evaluation.UI.Response.Dashboard;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Evaluation.UI.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGeneralListApi _generalListApi;
        private readonly IContactApi _contactApi;
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IUserApi _userApi;
        private readonly IDashboardApi _dashboard;
        public DashBoardController(IConfiguration configuration, IGeneralListApi generalListApi, IHttpClientHelper httpClientHelper, IUserApi userApi, IDashboardApi dashboard)
        {
            _configuration = configuration;
            _generalListApi = generalListApi;
            _httpClientHelper = httpClientHelper;
            _userApi = userApi;
            _dashboard = dashboard;
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ProductPrice(CancellationToken ct)
        {
           
            ProductPriceControlReq request = new ProductPriceControlReq();
            var user = await _userApi.GetUserClaims(User.Claims);
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            ProductPriceControlResp result = await _dashboard.ProductPriceControFindAll(request, ct);
			ProductPriceVM productPriceVM= new ProductPriceVM();
            productPriceVM.ProductPriceControl = result.ProductPriceControl;

			return View(productPriceVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> TicketHistory(CancellationToken ct)
        {
			
			//TicketHistoryReq request = new TicketHistoryReq();
           // var user = await _userApi.GetUserClaims(User.Claims);
           // request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            //request.WebRequestCommon.UserName = user.EmailAdress;
           // TicketHistoryResp result = await _dashboard.TicketHistoryFindDataWithNbrDaysFilter(request, ct);
			TicketHistoryVM ticketHistoryVM = new TicketHistoryVM();
			//ticketHistoryVM.TicketHistory=result.TicketHistory;

			return View(ticketHistoryVM);
        }
		[HttpPost]
		[Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
		public async Task<IActionResult> SearchTicketHistory(IFormCollection keyValues, CancellationToken ct)
		{

			TicketHistoryReq request = JsonConvert.DeserializeObject<TicketHistoryReq>(keyValues["nbr"]);
			var user = await _userApi.GetUserClaims(User.Claims);
			request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
			request.WebRequestCommon.UserName = user.EmailAdress;
			TicketHistoryResp result = await _dashboard.TicketHistoryFindDataWithNbrDaysFilter(request, ct);

			return Ok(result.TicketHistory);
		}
	}
}
