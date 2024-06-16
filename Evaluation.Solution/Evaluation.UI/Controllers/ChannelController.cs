using Evaluation.UI.Consume.Api;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Evaluation.UI.Controllers
{
    public class ChannelController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IChannelApi _channel;
        private readonly IHttpClientHelper _httpClientHelper;

        public ChannelController(IConfiguration configuration,IHttpClientHelper httpClientHelper, IChannelApi channel)
        {
            _configuration = configuration;
            _httpClientHelper = httpClientHelper;
            _channel = channel;
        }

        // GET: ChannelController
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            GenericEmptyReq request = new GenericEmptyReq();
            var result=await _channel.GetAllChannel(request,ct);
            return View(result);
        }

        // GET: ChannelController/Details/5
        public async Task<IActionResult> Details(int id, CancellationToken ct)
        {
            return View();
        }

        // GET: ChannelController/Create
        public async Task<IActionResult> Create(CancellationToken ct)
        {
            return View();
        }

        // POST: ChannelController/Create
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection, CancellationToken ct)
        {
            ChannelNewRecReq requestBody = JsonConvert.DeserializeObject<ChannelNewRecReq>(collection["channel"]);
            var result = await _channel.CreateChannel(requestBody, ct);
            return Ok(result);
        }

        // GET: ChannelController/Edit/5
        public async Task<IActionResult> Edit(int id, CancellationToken ct)
        {
            GenericIdReq request = new GenericIdReq();
            request.recId = id;
            var result = await _channel.GetChannelByID(request, ct);
            return View(result);
        }

        // POST: ChannelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection, CancellationToken ct)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChannelController/Delete/5
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            return View();
        }

        // POST: ChannelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection, CancellationToken ct)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
