
using EllipticCurve.Utils;
using Evaluation.UI.Consume.Api;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.DTO;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Models.Transaction;
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
using Evaluation.UI.Request.BLDuplication;
using Evaluation.UI.Request.Product;
using Evaluation.UI.Request.Ticket;
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
using Evaluation.UI.Response.Product;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static Evaluation.UI.Models.TransactionVM;

namespace Evaluation.UI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IGeneralListApi _generalListApi;
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IBusinessLineApi _businessLineApi;
        private readonly IContactApi _contactApi;
        private readonly IProductApi _productApi;
        private readonly IUserApi _userApi;
        private readonly IGlobal _global;
        private readonly IConvertFromToExcel _convertFromToExcel;
        private readonly ITransactionApi _transactionApi;
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(IConfiguration configuration, IHttpClientHelper httpClientHelper, IGeneralListApi generalListApi, IBusinessLineApi businessLineApi, IContactApi contactApi, IUserApi userApi, IGlobal global, IProductApi productApi, IConvertFromToExcel convertFromToExcel, ITransactionApi transactionApi, ITransactionBusiness transactionBusiness)
        {
            _configuration = configuration;
            _httpClientHelper = httpClientHelper;
            _generalListApi = generalListApi;
            _businessLineApi = businessLineApi;
            _contactApi = contactApi;
            _userApi = userApi;
            _global = global;
            _productApi = productApi;
            _convertFromToExcel = convertFromToExcel;
            _transactionApi = transactionApi;
            _transactionBusiness = transactionBusiness;
        }
        // GET: TransactionController
        public ActionResult Index()
        {
            return View();
        }
        // GET: TransactionController
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Dashboard(string id, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 1);
            var user = await _userApi.GetUserClaims(User.Claims);

            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            var result = await _businessLineApi.GetDashboard(requestBody, ct);

            SalesTransactionDashboardVM salesTransactionDashboardVM = new SalesTransactionDashboardVM();
            salesTransactionDashboardVM.SalesTransactions = result.SalesTransaction;
            salesTransactionDashboardVM.ContactVM = contactVM;

            return View(salesTransactionDashboardVM);
        }
        // GET: TransactionController/Details/5
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed080501(string id, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 4);
            var user = await _userApi.GetUserClaims(User.Claims);
            DetailedVM detailedVM = new DetailedVM();
            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 1;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


            SalesTransactionBL080501FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL080501FindCQShortFullListWithRecIdFilterReq();

            requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBod.WebRequestCommon.UserName = user.EmailAdress;
            requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
            SalesTransactionBL080501CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList(requestBod, ct);
            detailedVM.ContactVM = contactVM;
            detailedVM.CQShortListBL080501 = resp.CQShortListBL080501;
            detailedVM.CQFullListBL080501 = resp.CQFullListBL080501;
            detailedVM.CQHeaderBL080501 = resp.CQHeaderBL080501;
            detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
            detailedVM.BusinessLineCode = paramDecode[2];
            detailedVM.PageType = paramDecode[3];

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed321110(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 2);
            AF1_32VM aF1_30VM = new AF1_32VM();
            GenericIdReq requestCont = new GenericIdReq();
            //requestCont.recId = contactId;
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);
            int trxID = Convert.ToInt32(paramDecode[1]);


            //if (trxID != 0)
            //{
            //    SalesTransactionBL321110FindAF1WithRecIdReq req = new SalesTransactionBL321110FindAF1WithRecIdReq();
            //    req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            //    req.WebRequestCommon.UserName = user.EmailAdress;
            //    req.SalesTransactionId = trxID;
            //    SalesTransactionBL321110Resp resp = await _transactionApi.GetAf32(req, ct);
            //    aF1_30VM.SalesTransactionBL321110Dto = resp.SalesTransactionBL321110;
            //}
            //else
            //{
            //    aF1_30VM.SalesTransactionBL321110Dto = new DTO.BL321110.SalesTransactionBL321110Dto();
            //    aF1_30VM.SalesTransactionBL321110Dto.AF1BL321110 = new List<DTO.BL321110.AF1BL321110Dto>();

            //}
            SalesTransactionBL321110DetailsFindWithSalesTrxIdReq reqDetails = new SalesTransactionBL321110DetailsFindWithSalesTrxIdReq();
            reqDetails.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            reqDetails.WebRequestCommon.UserName = user.EmailAdress;
            reqDetails.SalesTransactionId = trxID;
            SalesTransactionBL321110DetailsResp resp = await _transactionApi.GetAF1_32Details(reqDetails, ct);
            aF1_30VM.SalesTransactionBL321110Details = resp.SalesTransactionBL321110Details;
            GenericEmptyReq request = new GenericEmptyReq();
            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            request.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllReq requestBody = new ProductLookupFindAllReq();
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            ProductLookupFindAllResp productFindAllResp = await _productApi.GetProductLookup(requestBody, ct);
            var result = await _generalListApi.GetAllGeneralLists(request, ct);
            aF1_30VM.Genders = result.gender;
            aF1_30VM.Regions = result.region;
            aF1_30VM.Relations = result.Relaion;
            aF1_30VM.MaritalStatuses = result.maritalStatus;
            aF1_30VM.Networks = result.NetworkLevel;
            aF1_30VM.Territorias = result.TerritorialScope;
            aF1_30VM.ProductClassOfCoverage = result.ProductClassOfCoverage;
            aF1_30VM.ContactVM = contactVM;
            aF1_30VM.Insurer = productFindAllResp.Insurer;
            aF1_30VM.ThirdPartyAdmin = productFindAllResp.ThirdPartyAdmin;
            aF1_30VM.ProductDetailsPOINetwork = productFindAllResp.ProductDetailsPOINetwork;
            aF1_30VM.SalesTransactionBL321110DetailsPrices = resp.SalesTransactionBL321110DetailsPrices;
            return View(aF1_30VM);
        } 
        //[Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        //public async Task<IActionResult> Detailed321110(string id, CancellationToken ct)
        //{
        //    var paramDecode = _global.DecodeParameters(id, 4);
        //    var user = await _userApi.GetUserClaims(User.Claims);
        //    Detailed321110VM detailedVM = new Detailed321110VM();
        //    SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

        //    requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
        //    requestBody.WebRequestCommon.UserName = user.EmailAdress;
        //    requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
        //    requestBody.InternalStatus = 1;
        //    GenericIdReq requestCont = new GenericIdReq();
        //    requestCont.recId = Convert.ToInt32(paramDecode[0]);
        //    ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);


        //    SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq requestBod = new SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq();

        //    requestBod.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
        //    requestBod.WebRequestCommon.UserName = user.EmailAdress;
        //    requestBod.SalesTransactionId = Convert.ToInt32(paramDecode[1]);
        //    SalesTransactionBL321110CQShortFulListResp resp = await _businessLineApi.DetailedShortLongList321110(requestBod, ct);
        //    detailedVM.ContactVM = contactVM;
        //    detailedVM.CQShortListBL321110 = resp.CQShortListBL321110;
        //    detailedVM.CQFullListBL321110 = resp.CQFullListBL321110;
        //    detailedVM.CQHeaderBL321110 = resp.CQHeaderBL321110;
        //    detailedVM.SalesTransactionId = requestBod.SalesTransactionId;
        //    detailedVM.BusinessLineCode = paramDecode[2];
        //    detailedVM.PageType = paramDecode[3];

        //    return View(detailedVM);
        //}
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed301401(string id, CancellationToken ct)
        {
            Detailed301401VM detailedVM = await _transactionBusiness.Detailed301401Business(id, User.Claims, ct);

            return View(detailedVM);
        }

        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed090703(string id, CancellationToken ct)
        {
            Detailed090703VM detailedVM = await _transactionBusiness.Detailed090703Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed070806(string id, CancellationToken ct)
        {
            Detailed070806VM detailedVM = await _transactionBusiness.Detailed070806Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed010602(string id, CancellationToken ct)
        {
            Detailed010602VM detailedVM = await _transactionBusiness.Detailed010602Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed021502(string id, CancellationToken ct)
        {
            Detailed021502VM detailedVM = await _transactionBusiness.Detailed021502Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed281609(string id, CancellationToken ct)
        {
            Detailed281609VM detailedVM = await _transactionBusiness.Detailed281609Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed331211(string id, CancellationToken ct)
        {
            Detailed331211VM detailedVM = await _transactionBusiness.Detailed331211Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed030904(string id, CancellationToken ct)
        {
            Detailed030904VM detailedVM = await _transactionBusiness.Detailed030904Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed051807(string id, CancellationToken ct)
        {
            Detailed051807VM detailedVM = await _transactionBusiness.Detailed051807Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed041312(string id, CancellationToken ct)
        {
            Detailed041312VM detailedVM = await _transactionBusiness.Detailed041312Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed061005(string id, CancellationToken ct)
        {
            Detailed061005VM detailedVM = await _transactionBusiness.Detailed061005Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed291908(string id, CancellationToken ct)
        {
            Detailed291908VM detailedVM = await _transactionBusiness.Detailed291908Business(id, User.Claims, ct);

            return View(detailedVM);
        }
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Detailed311703(string id, CancellationToken ct)
        {
            Detailed311703VM detailedVM = await _transactionBusiness.Detailed311703Business(id, User.Claims, ct);

            return View(detailedVM);
        }

        // GET: TransactionController/Create
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Create(string id, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 1);
            var user = await _userApi.GetUserClaims(User.Claims);
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            SalesTransactionMenuFindWithColFilterReq request = new SalesTransactionMenuFindWithColFilterReq();
            request.ContactId = Convert.ToInt32(paramDecode[0]);
            SalesTransactionMenuFindWithColFilterResp resp = await _businessLineApi.GetTreeViewBusinessLine(request, ct);
            List<SalesTransactionMenuDto> list = resp.SalesTransactionMenu;
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < list.Count; i++)
            {
                Node node = new Node();
                node.Id = list[i].RecId;
                //if (list[i].CountSalesTrx==1)
                //{
                //    node.Name = list[i].DisplayNameTreeView + " (" + list[i].CountSalesTrx + ")";
                //}
                //else
                //{
                //    node.Name = list[i].DisplayNameTreeView;

                //}
                node.Name = list[i].DisplayNameTreeView;
                node.Code = list[i].BusinessLineCode;
                node.ParentId = list[i].ParentId;
                node.Href = list[i].AF1URL;
                node.Color = list[i].TextForeColor;
                node.BackColor = list[i].BackColor;
                node.MinRange = list[i].MinRange;
                node.MaxRange = list[i].MaxRange;
                node.CountSalesTrx = list[i].CountSalesTrx;
                node.Tags = new List<string>() { list[i].CountSalesTrx.ToString() };
                nodes.Add(node);
            }
            List<TreeNode> treeNodes = TreeNode.BuildTree(nodes);

            string json = JsonConvert.SerializeObject(treeNodes, Formatting.Indented);

            var tabsNames = list.Where(x => x.ParentId == 0).Select(x => new { x.RecId, x.DisplayNameTreeView, x.MenuIcon }).ToList();
            List<Tab> tbs = new List<Tab>();
            foreach (var tb in tabsNames)
            {
                Tab t = new Tab();
                t.Name = tb.DisplayNameTreeView;
                t.Id = tb.RecId;
                t.Icon = tb.MenuIcon;
                tbs.Add(t);
            }
            TransactionVM transactionVM = new TransactionVM();
            transactionVM.Tabs = tbs;
            // Build the HTML and JavaScript dynamically
            StringBuilder sb = new StringBuilder();

            // Tabs drawer start 
            sb.AppendLine("<ul class='nav nav-tabs' role='tablist'>");
            foreach (var item in tbs)
            {
                sb.AppendLine(" <li class='nav-item'>");
                if (item == tbs.First())
                {
                    sb.AppendLine("<a class='nav-link d-flex active' data-bs-toggle='tab' href='#content" + @item.Id + "' role='tab'>");
                }
                else
                {
                    sb.AppendLine("<a class='nav-link d-flex' data-bs-toggle='tab' href='#content" + @item.Id + "' role='tab'>");

                }
                sb.AppendLine("     <span>");
                sb.AppendLine("       <i class='" + @item.Icon + "'></i>");
                sb.AppendLine("    </span>");
                sb.AppendLine("     <span class='d-none d-md-block ms-2'>" + @item.Name + "</span>");
                sb.AppendLine("    </a>");
                sb.AppendLine("</li>");
            }
            sb.AppendLine("</ul>");
            // Tabs drawer end


            //Content tab start
            sb.AppendLine(" <div class='tab-content'>");
            foreach (var item in tbs)
            {
                if (item == tbs.First())
                {
                    sb.AppendLine("  <div class='tab-pane active' id='content" + @item.Id + "' role='tabpanel'> ");
                }
                else
                {
                    sb.AppendLine("  <div class='tab-pane' id='content" + @item.Id + "' role='tabpanel'> ");
                }

                sb.AppendLine("   <div id='treeview" + @item.Id + "'></div>");
                sb.AppendLine("   </div>");
            }
            sb.AppendLine("</div>");
            //Content tab end

            StringBuilder sbSc = new StringBuilder();
            //Script tab start
            //  sbSc.AppendLine("<script>");
            //  sb.AppendLine("$(function() {");
            foreach (var item in tbs)
            {
                var treeJson = treeNodes.Where(x => x.Id == item.Id).FirstOrDefault();
                var jsontreeview = JsonConvert.SerializeObject(treeJson);
                jsontreeview = jsontreeview.Replace("\"nodes\":[]", "");
                sbSc.AppendLine("$('#treeview" + @item.Id + "').treeview({");
                sbSc.AppendLine("   color: 'black',                                   ");
                sbSc.AppendLine("       selectedBackColor: '#03a9f3',                 ");
                sbSc.AppendLine("       onhoverColor: 'rgba(0, 0, 0, 0.05)',          ");
                sbSc.AppendLine("       expandIcon: 'ri-add-line fs-4 me-1',          ");
                sbSc.AppendLine("       collapseIcon: 'ri-subtract-line fs-4 me-1',   ");
                sbSc.AppendLine("       nodeIcon: 'ri-folder-5-line fs-4 me-1',       ");
                sbSc.AppendLine("       data: [" + jsontreeview + "],");

                sbSc.AppendLine("   });                                               ");
                // Add an event listener for the nodeSelected event
                sbSc.AppendLine("$('#treeview" + @item.Id + "').on('nodeSelected', function(event, data) {");
                //sbSc.AppendLine("var params=encodeParameters('?contactId=" + Convert.ToInt32(paramDecode[0]) + "&min='+data.minRange+'&max='+data.maxRange+'&businessline='+data.id+'&countrnx='+data.countSalesTrx)");
                sbSc.AppendLine("var params=encodeParameters('?contactId=" + Convert.ToInt32(paramDecode[0]) + "&wqdq=0&businessline='+data.code)");
                //_global.EncodeParameters()
                // sbSc.AppendLine("window.location.href = data.href+'?param='+params");
                sbSc.AppendLine("window.location.href = data.href+'/'+params");
                // sbSc.AppendLine("window.location.href = data.href+'?contactId="+ contactId + "&min='+data.minRange+'&max='+data.maxRange+'&businessline='+data.id+'&countrnx='+data.countSalesTrx;");
                sbSc.AppendLine("  });");
            }
            //   sb.AppendLine("});");
            //sbSc.AppendLine("</script>");
            //Script tab end


            // Pass the resulting string to your Razor view
            ViewBag.TreeViewHtml = sb.ToString();
            ViewBag.TreeViewScript = sbSc.ToString();
            return View(contactVM);
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TransactionController/Edit/5
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionController/Delete/5
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
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> DashboardDetails(string id, CancellationToken ct)
        {
            var paramDecode = _global.DecodeParameters(id, 1);
            var user = await _userApi.GetUserClaims(User.Claims);

            SalesTransactionFindWithContactIdFilterReq requestBody = new SalesTransactionFindWithContactIdFilterReq();

            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.ContactId = Convert.ToInt32(paramDecode[0]);
            requestBody.InternalStatus = 3;
            GenericIdReq requestCont = new GenericIdReq();
            requestCont.recId = Convert.ToInt32(paramDecode[0]);
            ContactVM contactVM = await _contactApi.GetContactByIDApi(requestCont, ct);

            var result = await _businessLineApi.GetDashboard(requestBody, ct);

            SalesTransactionDashboardVM salesTransactionDashboardVM = new SalesTransactionDashboardVM();
            salesTransactionDashboardVM.SalesTransactions = result.SalesTransaction;
            salesTransactionDashboardVM.ContactVM = contactVM;

            return View(salesTransactionDashboardVM);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> DuplicateTransaction(IFormCollection keyValues, CancellationToken ct)
        {
            BusinessLineDuplicationNewRecReq requestBody = JsonConvert.DeserializeObject<BusinessLineDuplicationNewRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);


            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _businessLineApi.DuplicateTransaction(requestBody, ct);

            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> MoveToNextStep(IFormCollection keyValues, CancellationToken ct)
        {
            TicketDetailsUpdRecReq requestBody = JsonConvert.DeserializeObject<TicketDetailsUpdRecReq>(keyValues["data"]);
            var user = await _userApi.GetUserClaims(User.Claims);


            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.TiketDetailsUpdRec(requestBody, ct);

            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Slip(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                string businesscode = JsonConvert.DeserializeObject<string>(keyValues["businesscode"].ToString());
                // string type = keyValues["type"];
                int salestransactionId = JsonConvert.DeserializeObject<int>(keyValues["salestransactionId"]);
                var user = await _userApi.GetUserClaims(User.Claims);
                // var resultRes;
                byte[]? bytes = null;
                switch (businesscode)
                {
                    case "080501":
                        {
                            SalesTransactionBL080501FindAF1WithRecIdFilterReq reqs = new SalesTransactionBL080501FindAF1WithRecIdFilterReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL080501SlipResp res = await _transactionApi.Slip080501(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split080501(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "010602":
                        {
                            SalesTransactionBL010602FindAF1WithRecIdFilterReq reqs = new SalesTransactionBL010602FindAF1WithRecIdFilterReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL010602SlipResp res = await _transactionApi.Slip010602(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split010602(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "090703":
                        {
                            SalesTransactionBL090703FindAF1WithRecIdFilterReq reqs = new SalesTransactionBL090703FindAF1WithRecIdFilterReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL090703SlipResp res = await _transactionApi.Slip090703(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split090703(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "030904":
                        {
                            SalesTransactionBL030904FindAF1WithRecIdReq reqs = new SalesTransactionBL030904FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL030904SlipResp res = await _transactionApi.Slip030904(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split030904(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "061005":
                        {
                            SalesTransactionBL061005FindAF1WithRecIdReq reqs = new SalesTransactionBL061005FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL061005SlipResp res = await _transactionApi.Slip061005(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split061005(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "070806":
                        {
                            SalesTransactionBL070806FindAF1WithRecIdFilterReq reqs = new SalesTransactionBL070806FindAF1WithRecIdFilterReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL070806SlipResp res = await _transactionApi.Slip070806(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split070806(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "021502":
                        {
                            SalesTransactionBL021502FindAF1WithRecIdReq reqs = new SalesTransactionBL021502FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL021502SlipResp res = await _transactionApi.Slip021502(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split021502(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "051807":
                        {
                            SalesTransactionBL051807FindAF1WithRecIdReq reqs = new SalesTransactionBL051807FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL051807SlipResp res = await _transactionApi.Slip051807(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split051807(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "291908":
                        {
                            SalesTransactionBL291908FindAF1WithRecIdReq reqs = new SalesTransactionBL291908FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL291908SlipResp res = await _transactionApi.Slip291908(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split291908(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "281609":
                        {
                            SalesTransactionBL281609FindAF1WithRecIdReq reqs = new SalesTransactionBL281609FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL281609SlipResp res = await _transactionApi.Slip281609(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split281609(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "301401":
                        {
                            SalesTransactionBL301401FindAF1WithRecIdReq reqs = new SalesTransactionBL301401FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL301401SlipResp res = await _transactionApi.Slip301401(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split301401(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "311703":
                        {
                            SalesTransactionBL311703FindAF1WithRecIdReq reqs = new SalesTransactionBL311703FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL311703SlipResp res = await _transactionApi.Slip311703(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split311703(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "321110":
                        {
                            SalesTransactionBL321110FindAF1WithRecIdReq reqs = new SalesTransactionBL321110FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL321110SlipResp res = await _transactionApi.Slip321110(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split321110(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "331211":
                        {
                            SalesTransactionBL331211FindAF1WithRecIdReq reqs = new SalesTransactionBL331211FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;
                            
                            SalesTransactionBL331211SlipResp res = await _transactionApi.Slip331211(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split331211(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    case "041312":
                        {
                            SalesTransactionBL041312FindAF1WithRecIdReq reqs = new SalesTransactionBL041312FindAF1WithRecIdReq();
                            reqs.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            reqs.WebRequestCommon.UserName = user.EmailAdress;
                            reqs.SalesTransactionId = salestransactionId;

                            SalesTransactionBL041312SlipResp res = await _transactionApi.Slip041312(reqs, ct);
                            if (res.webResponseCommon.ReturnCode == "200")
                            {
                                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await GetSlipExcelDocument(businesscode, user, ct);
                                bytes = await _convertFromToExcel.Split041312(resFile.BusinessLineRelatedDoc.AttachDocBinary, res);
                                return ReturnDownloadSlipFileNameAndBytes(businesscode, bytes);
                            }
                            else
                            {
                                return Ok(new { status = "error", message = res.webResponseCommon.ReturnMessage });
                            }
                        }
                        break;
                    default:
                        return null;
                        break;
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }
        }

        private IActionResult ReturnDownloadSlipFileNameAndBytes(string businesscode, byte[]? bytes)
        {
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "slip-" + businesscode + "-" + DateTime.UtcNow.
  ToShortTimeString() + ".xlsx");
        }

        private async Task<BusinessLineRelatedDocFindWithBusinessLineIdFilterResp> GetSlipExcelDocument(string businesscode, UserDto user, CancellationToken ct)
        {
            BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
            req.BusinessLineCode = businesscode;
            req.ApplicationForm = "SLIP";
            req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            req.WebRequestCommon.UserName = user.EmailAdress;
            BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
            return resFile;
        }
    }
}
