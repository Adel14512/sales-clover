
using Evaluation.CAL.Request.ProductDetailsPOIAllNetwork;
using Evaluation.UI.ExcelImportModel;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models.Product;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BusinessLineDetailsProduct;
using Evaluation.UI.Request.Product;
using Evaluation.UI.Request.ProductBenefits;
using Evaluation.UI.Request.ProductCombination;
using Evaluation.UI.Request.ProductPriceList;
using Evaluation.UI.Response;
using Evaluation.UI.Response.Product;
using Evaluation.UI.Util;
using Evaluation.UI.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;

namespace Evaluation.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGeneralListApi _generalListApi;
        private readonly ITransactionApi _transactionApi;
        private readonly IContactApi _contactApi;
        private readonly ILoggerManager _logger;
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly IProductApi _productApi;
        private readonly IConvertFromToExcel _convertFromToExcel;
        public ProductController(IGeneralListApi generalListApi, ITransactionApi transactionApi, IContactApi contactApi, IGlobal global, IUserApi userApi, IProductApi productApi, IConvertFromToExcel convertFromToExcel)
        {
            _generalListApi = generalListApi;
            _transactionApi = transactionApi;
            _contactApi = contactApi;
            _global = global;
            _userApi = userApi;
            _productApi = productApi;
            _convertFromToExcel = convertFromToExcel;
        }

        // GET: ProductController
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Index(int isactive,string param, CancellationToken ct)
        {

            //var paramDecode = _global.DecodeParameters(param, 1);
            bool showActive = Convert.ToBoolean(isactive);
            ProductFindAllReq requestBody = new ProductFindAllReq();
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            requestBody.IsActive = showActive;
            ProductFindAllResp productFindAllResp = await _productApi.GetAllProduct(requestBody, ct);
            ProductListVM productListVM = new ProductListVM();
            productListVM.Products = productFindAllResp.Product;
            return View(productListVM);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Create(CancellationToken ct)
        {
            ProductLookupFindAllReq requestBody = new ProductLookupFindAllReq();
            var user = await _userApi.GetUserClaims(User.Claims);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;

            ProductLookupFindAllResp productFindAllResp = await _productApi.GetProductLookup(requestBody, ct);
            ProductVM productVM = new ProductVM();
            productVM.Regions = productFindAllResp.Region;
            productVM.Currencys = productFindAllResp.Currency;
            productVM.TerritorialScopes = productFindAllResp.TerritorialScope;
            productVM.ThirdPartyAdmins = productFindAllResp.ThirdPartyAdmin;
            productVM.Branchs = productFindAllResp.Branch;
            productVM.Insurers = productFindAllResp.Insurer;
            productVM.Product = new DTO.Product.ProductFullNewDto();
            return View(productVM);
        }

        // POST: ProductController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Create(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductFullNewRecReq requestBody = JsonConvert.DeserializeObject<ProductFullNewRecReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.CreateProduct(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }

        // GET: ProductController/Edit/5
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Edit(string id, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            var paramDecode = _global.DecodeParameters(id, 1);
            var productID = Convert.ToInt32(paramDecode[0]);

            ProductFindWithRecIdFilterReq productFindWithRecIdFilterReq = new ProductFindWithRecIdFilterReq();
            productFindWithRecIdFilterReq.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            productFindWithRecIdFilterReq.WebRequestCommon.UserName = user.EmailAdress;
            productFindWithRecIdFilterReq.RecId =productID;
            var product = await _productApi.GetProductByID(productFindWithRecIdFilterReq, ct);

            ProductVM productVM = new ProductVM();
            ProductLookupFindAllReq requestBody = new ProductLookupFindAllReq();
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;

            ProductLookupFindAllResp productFindAllResp = await _productApi.GetProductLookup(requestBody, ct);

            ProductBenefitsFindWithProductIdFilterReq requestBenifits = new ProductBenefitsFindWithProductIdFilterReq();
            requestBenifits.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBenifits.WebRequestCommon.UserName = user.EmailAdress;
            requestBenifits.ProductId = productID;
            var pbenift= await _productApi.ProductBenefitsFind(requestBenifits, ct);
            productVM.ProductBenefits = pbenift.ProductBenefitsList;

            BusinessLineDetailsProductFindWithProductIdFilterRecReq rBl = new BusinessLineDetailsProductFindWithProductIdFilterRecReq();
            rBl.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            rBl.WebRequestCommon.UserName = user.EmailAdress;
            rBl.ProductId = productID;
            var rwe = await _productApi.GetBuinessLineCodeFromProductID(rBl, ct);
            productVM.BusinessLineCode = rwe.BusinessLineDetailsProduct.BusinessLineCode;

            ProductPriceListFindWithProductIdFilterReq rPrices = new ProductPriceListFindWithProductIdFilterReq();
            rPrices.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            rPrices.WebRequestCommon.UserName = user.EmailAdress;
            rPrices.ProductId = productID;
            var pPrices = await _productApi.ProductPriceListFind(rPrices, ct);
            productVM.ProductPrices = pPrices.ProductPriceList;

            ProductCombinationFindWithProductIdFilterReq rCombination = new ProductCombinationFindWithProductIdFilterReq();
            rCombination.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            rCombination.WebRequestCommon.UserName = user.EmailAdress;
            rCombination.ProductId = productID;
            var pCombination = await _productApi.ProductCombinationByProductId(rCombination, ct);
            productVM.ProductCombination = pCombination.ProductCombination;

            productVM.Regions = productFindAllResp.Region;
            productVM.Currencys = productFindAllResp.Currency;
            productVM.TerritorialScopes = productFindAllResp.TerritorialScope;
            productVM.ThirdPartyAdmins = productFindAllResp.ThirdPartyAdmin;
            productVM.Branchs = productFindAllResp.Branch;
            productVM.Insurers = productFindAllResp.Insurer;
            productVM.ProductDetailsPOISections = productFindAllResp.ProductDetailsPOISection;
            productVM.ProductClassOfCoverages = productFindAllResp.ProductClassOfCoverage;
            productVM.ProductDetailsPOINetworks = productFindAllResp.ProductDetailsPOINetwork;
            productVM.Product = new DTO.Product.ProductFullNewDto();
            productVM.EditProduct = new DTO.Product.ProductFullDto();
            productVM.EditProduct = product.ProductFull;

            return View(productVM);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> Edit(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductFullUpdRecReq requestBody = JsonConvert.DeserializeObject<ProductFullUpdRecReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.UpdateProduct(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateProductDetails(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductDetailsNewRecReq requestBody = JsonConvert.DeserializeObject<ProductDetailsNewRecReq>(keyValues["productdetails"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.CreateProductDetails(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditProductDetails(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductDetailsUpdRecReq requestBody = JsonConvert.DeserializeObject<ProductDetailsUpdRecReq>(keyValues["productdetails"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.EditProductDetails(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateProductDetailsPOI(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductDetailsPOINewRecReq requestBody = JsonConvert.DeserializeObject<ProductDetailsPOINewRecReq>(keyValues["productdetails"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.ProductDetailsPOINewRec(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditProductDetailsPOI(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductDetailsPOIUpdRecReq requestBody = JsonConvert.DeserializeObject<ProductDetailsPOIUpdRecReq>(keyValues["productdetails"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.ProductDetailsPOIUpdRec(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ChangeActiveStatus(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductFullUpdIsActiveRecReq requestBody = JsonConvert.DeserializeObject<ProductFullUpdIsActiveRecReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.ProductActiveStatus(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        } 
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ProductBenefitCreate(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductBenefitsNewRecReq requestBody = JsonConvert.DeserializeObject<ProductBenefitsNewRecReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.ProductBenefitCreate(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> GetProductBenifits(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductBenefitsFindWithProductIdFilterReq requestBody = JsonConvert.DeserializeObject<ProductBenefitsFindWithProductIdFilterReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.ProductBenefitsFind(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> GetProductPriceListFind(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductPriceListFindWithProductIdFilterReq requestBody = JsonConvert.DeserializeObject<ProductPriceListFindWithProductIdFilterReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.ProductPriceListFind(requestBody, ct);
            // Code to process the form data
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateProductCombination(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductCombinationNewRecReq requestBody = JsonConvert.DeserializeObject<ProductCombinationNewRecReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.CreateProductCombination(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> DeleteProductCombination(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductCombinationDeaWithRecIdReq requestBody = JsonConvert.DeserializeObject<ProductCombinationDeaWithRecIdReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.DeactivateProductCombination(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditProductCombination(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductCombinationUpdRecReq requestBody = JsonConvert.DeserializeObject<ProductCombinationUpdRecReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.UpdateProductCombination(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> DownloadProductListExcelTemplate(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                string businesLineID = keyValues["businesscode"].ToString();
                string type = JsonConvert.DeserializeObject<string>(keyValues["type"]);
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = type;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);

                var downloadFile = File(resFile.BusinessLineRelatedDoc.AttachDocBinary, System.Net.Mime.MediaTypeNames.Application.Octet, type + businesLineID + "-" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    status = "error",
                    message = e.Message
                });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> CreateProductPrice(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductPriceListNewRecReq requestBody = JsonConvert.DeserializeObject<ProductPriceListNewRecReq>(keyValues["product"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.CreateProductPriceList(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelProductPrice(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<ProductPriceEM> data = JsonConvert.DeserializeObject<List<ProductPriceEM>>(keyValues["data"]);
                List<CombinationEM> combination = JsonConvert.DeserializeObject<List<CombinationEM>>(keyValues["combination"]);
                List<TechnicalSheetEM> technical = JsonConvert.DeserializeObject<List<TechnicalSheetEM>>(keyValues["technical"]);
                string businesLineID = keyValues["businesscode"].ToString();
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = "PL";
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                bytes = await _convertFromToExcel.ConvetFormToExcelProductPrice(resFile.BusinessLineRelatedDoc.AttachDocBinary, businesLineID, data, combination, technical);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "ProductList_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        // GET: ProductController/Edit/5
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> NetworkList(CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductVM productVM = new ProductVM();
            ProductLookupFindAllReq requestBody = new ProductLookupFindAllReq();
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;

            ProductLookupFindAllResp productFindAllResp = await _productApi.GetProductLookup(requestBody, ct);
            productVM.ProductDetailsPOINetworks = productFindAllResp.ProductDetailsPOINetwork;
            return View(productVM);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> EditNetwork(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            ProductDetailsPOINetworkUpdRecReq requestBody = JsonConvert.DeserializeObject<ProductDetailsPOINetworkUpdRecReq>(keyValues["network"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _productApi.UpdateProductNetwork(requestBody, ct);
            return Ok(result);
        }
    }

}
