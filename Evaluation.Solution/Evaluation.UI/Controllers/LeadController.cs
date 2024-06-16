using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Models.Lead;
using Evaluation.UI.Request;
using Evaluation.UI.Request.Lead;
using Evaluation.UI.Response;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Evaluation.UI.Controllers
{
    public class LeadController : Controller
    {
        private readonly ILeadApi _leadApi;
        private readonly IUserApi _userApi;
        public LeadController(ILeadApi leadApi, IUserApi userApi)
        {
            _leadApi = leadApi;
            _userApi = userApi;
        }
        // GET: LeadController
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            
            LeadFindAllReq leadFindAllReq = new LeadFindAllReq();
            leadFindAllReq.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            leadFindAllReq.WebRequestCommon.UserName = user.EmailAdress;
            LeadFindAllResp leadFindAllResp = await _leadApi.GetAllLeads(leadFindAllReq ,ct);
            return View(leadFindAllResp);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        // GET: LeadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        // GET: LeadController/Create
        public async Task<IActionResult> Create(CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);

            LeadVM leadVM = new LeadVM();
            LeadLookupFindAllReq leadLookupFindAllReq = new LeadLookupFindAllReq();
            leadLookupFindAllReq.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            leadLookupFindAllReq.WebRequestCommon.UserName = user.EmailAdress;
            var reResult = await _leadApi.GetLookupLead(leadLookupFindAllReq, ct);
            leadVM.Regions = reResult.Region;
            leadVM.LeadSales = reResult.LeadSale;
            leadVM.LeadSources = reResult.LeadSource;
            leadVM.LeadStatuses = reResult.LeadStatus;
            return View(leadVM);
        }

        // POST: LeadController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Create(IFormCollection keyValues, CancellationToken ct)
        {
      

            LeadNewRecReq lead = new LeadNewRecReq();
            lead = JsonConvert.DeserializeObject<LeadNewRecReq>(keyValues["lead"]);
            var user = await _userApi.GetUserClaims(User.Claims);
            lead.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            lead.WebRequestCommon.UserName = user.EmailAdress;
            var reResult = await _leadApi.CreateLead(lead, ct);
            return Ok(reResult);
        }

        // GET: LeadController/Edit/5
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LeadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
