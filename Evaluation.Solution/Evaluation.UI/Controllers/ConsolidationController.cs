using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.Models.Consolidation;
using Evaluation.UI.Response.BL010602Consolidation;
using Evaluation.UI.Response.BL041312Consolidation;
using Evaluation.UI.Response.BL070806Consolidation;
using Evaluation.UI.Response.BL090703Consolidation;
using Evaluation.UI.Response.BL281609Consolidation;
using Evaluation.UI.Response.BL301401Consolidation;
using Evaluation.UI.Response.BL321110Consolidation;
using Evaluation.UI.Response.BL331211Consolidation;
using Evaluation.UI.Response.Consolidation;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace Evaluation.UI.Controllers
{
    public class ConsolidationController : Controller
    {

        private readonly IConsolidationBusiness _consolidationBusines;
        private readonly IUserApi _userApi;
        public ConsolidationController(IUserApi userApi, IConsolidationBusiness consolidationBusines)
        {
            _userApi = userApi;
            _consolidationBusines = consolidationBusines;
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation080501(string id, CancellationToken ct)
        {
            ConsolidationVM convm = await _consolidationBusines.GetConsolidationBusiness(id, User.Claims, ct);

            return View(convm);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation301401(string id, CancellationToken ct)
        {
            Consolidation301401VM convm = await _consolidationBusines.GetConsolidationBusiness301401(id, User.Claims, ct);

            return View(convm);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation321110(string id, CancellationToken ct)
        {
            Consolidation321110VM convm = await _consolidationBusines.GetConsolidationBusiness321110(id, User.Claims, ct);

            return View(convm);
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument080501(IFormFile uploadfile, IFormCollection keyValues,CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocResp result = await _consolidationBusines.UpdateConsolidation080501Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument080501(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocResp result =await _consolidationBusines.CreateConsolidation080501Business(uploadfile, keyValues, user,ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm080501(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyUpdResp result = await _consolidationBusines.UpdateConsolidation080501FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument301401(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL301401Resp result = await _consolidationBusines.UpdateConsolidation301401Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument301401(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL301401Resp result = await _consolidationBusines.CreateConsolidation301401Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm301401(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL301401UpdResp result = await _consolidationBusines.UpdateConsolidation301401FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }
         [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument321110(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL321110Resp result = await _consolidationBusines.UpdateConsolidation321110Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument321110(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL321110Resp result = await _consolidationBusines.CreateConsolidation321110Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm321110(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL321110UpdResp result = await _consolidationBusines.UpdateConsolidation321110FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation010602(string id, CancellationToken ct)
        {
            Consolidation010602VM convm = await _consolidationBusines.GetConsolidationBusiness010602(id, User.Claims, ct);

            return View(convm);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument010602(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL010602Resp result = await _consolidationBusines.UpdateConsolidation010602Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument010602(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL010602Resp result = await _consolidationBusines.CreateConsolidation010602Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm010602(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL010602UpdResp result = await _consolidationBusines.UpdateConsolidation010602FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }
        
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation090703(string id, CancellationToken ct)
        {
            Consolidation090703VM convm = await _consolidationBusines.GetConsolidationBusiness090703(id, User.Claims, ct);

            return View(convm);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument090703(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL090703Resp result = await _consolidationBusines.UpdateConsolidation090703Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument090703(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL090703Resp result = await _consolidationBusines.CreateConsolidation090703Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm090703(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL090703UpdResp result = await _consolidationBusines.UpdateConsolidation090703FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        } 
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation070806(string id, CancellationToken ct)
        {
            Consolidation070806VM convm = await _consolidationBusines.GetConsolidationBusiness070806(id, User.Claims, ct);

            return View(convm);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument070806(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL070806Resp result = await _consolidationBusines.UpdateConsolidation070806Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument070806(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL070806Resp result = await _consolidationBusines.CreateConsolidation070806Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm070806(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL070806UpdResp result = await _consolidationBusines.UpdateConsolidation070806FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation281609(string id, CancellationToken ct)
        {
            Consolidation281609VM convm = await _consolidationBusines.GetConsolidationBusiness281609(id, User.Claims, ct);

            return View(convm);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument281609(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL281609Resp result = await _consolidationBusines.UpdateConsolidation281609Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument281609(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL281609Resp result = await _consolidationBusines.CreateConsolidation281609Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm281609(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL281609UpdResp result = await _consolidationBusines.UpdateConsolidation281609FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }    
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation331211(string id, CancellationToken ct)
        {
            Consolidation331211VM convm = await _consolidationBusines.GetConsolidationBusiness331211(id, User.Claims, ct);

            return View(convm);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument331211(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL331211Resp result = await _consolidationBusines.UpdateConsolidation331211Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument331211(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL331211Resp result = await _consolidationBusines.CreateConsolidation331211Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm331211(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL331211UpdResp result = await _consolidationBusines.UpdateConsolidation331211FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Consolidation041312(string id, CancellationToken ct)
        {
            Consolidation041312VM convm = await _consolidationBusines.GetConsolidationBusiness041312(id, User.Claims, ct);

            return View(convm);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationDocument041312(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL041312Resp result = await _consolidationBusines.UpdateConsolidation041312Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateConsolidationDocument041312(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyRelatedDocBL041312Resp result = await _consolidationBusines.CreateConsolidation041312Business(uploadfile, keyValues, user, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> UpdateConsolidationForm041312(IFormFile uploadfile, IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            PolicyBL041312UpdResp result = await _consolidationBusines.UpdateConsolidation041312FormBusiness(uploadfile, keyValues, user, ct);
            return Ok(result);
        }
    }
}
