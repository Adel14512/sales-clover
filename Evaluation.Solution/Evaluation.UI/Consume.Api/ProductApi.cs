
using Evaluation.CAL.Request.ProductDetailsPOIAllNetwork;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Request.BusinessLineDetailsProduct;
using Evaluation.UI.Request.Product;
using Evaluation.UI.Request.ProductBenefits;
using Evaluation.UI.Request.ProductCombination;
using Evaluation.UI.Request.ProductPriceList;
using Evaluation.UI.Request.Ticket;
using Evaluation.UI.Response.BusinessLineDetailsProduct;
using Evaluation.UI.Response.Product;
using Evaluation.UI.Response.ProductBenefits;
using Evaluation.UI.Response.ProductCombination;
using Evaluation.UI.Response.ProductDetailsPOIAllNetwork;
using Evaluation.UI.Response.ProductPriceList;
using Evaluation.UI.Response.Ticket;
using Evaluation.UI.Wrapper;
using System.Net;

namespace Evaluation.UI.Consume.Api
{
    public class ProductApi : IProductApi
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly ILoggerManager _logger;
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        public ProductApi(IHttpClientHelper httpClientHelper, ILoggerManager logger, IApiService apiService, IConfiguration configuration)
        {
            _httpClientHelper = httpClientHelper;
            _logger = logger;
            _apiService = apiService;
            _configuration = configuration;
        }
        public async Task<ProductFindAllResp> GetAllProduct(ProductFindAllReq request, CancellationToken ct)
        {
            ProductFindAllResp resp = new ProductFindAllResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductFindAllResp>(request, url, ct);
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
        public async Task<ProductFullResp> GetProductByID(ProductFindWithRecIdFilterReq request, CancellationToken ct)
        {
            ProductFullResp resp = new ProductFullResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductFullFindWithRecIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductFullResp>(request, url, ct);
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
        public async Task<ProductLookupFindAllResp> GetProductLookup(ProductLookupFindAllReq request, CancellationToken ct)
        {
            ProductLookupFindAllResp resp = new ProductLookupFindAllResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductLookupFindAll";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductLookupFindAllResp>(request, url, ct);
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
        public async Task<ProductFullResp> CreateProduct(ProductFullNewRecReq request, CancellationToken ct)
        {
            ProductFullResp resp = new ProductFullResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductFullNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductFullResp>(request, url, ct);
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
        public async Task<ProductFullResp> ProductActiveStatus(ProductFullUpdIsActiveRecReq request, CancellationToken ct)
        {
            ProductFullResp resp = new ProductFullResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductFullUpdIsActiveRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductFullResp>(request, url, ct);
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
        public async Task<ProductFullResp> UpdateProduct(ProductFullUpdRecReq request, CancellationToken ct)
        {
            ProductFullResp resp = new ProductFullResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductFullUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductFullResp>(request, url, ct);
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
        public async Task<ProductDetailsResp> CreateProductDetails(ProductDetailsNewRecReq request, CancellationToken ct)
        {
            ProductDetailsResp resp = new ProductDetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductDetailsNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductDetailsResp>(request, url, ct);
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
        public async Task<ProductDetailsResp> EditProductDetails(ProductDetailsUpdRecReq request, CancellationToken ct)
        {
            ProductDetailsResp resp = new ProductDetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductDetailsUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductDetailsResp>(request, url, ct);
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
        public async Task<ProductDetailsPOIResp> ProductDetailsPOINewRec(ProductDetailsPOINewRecReq request, CancellationToken ct)
        {
            ProductDetailsPOIResp resp = new ProductDetailsPOIResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductDetailsPOINewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductDetailsPOIResp>(request, url, ct);
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
        public async Task<ProductDetailsPOIResp> ProductDetailsPOIUpdRec(ProductDetailsPOIUpdRecReq request, CancellationToken ct)
        {
            ProductDetailsPOIResp resp = new ProductDetailsPOIResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductDetailsPOIUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductDetailsPOIResp>(request, url, ct);
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
        public async Task<TicketDetailsResp> TiketDetailsUpdRec(TicketDetailsUpdRecReq  request, CancellationToken ct)
        {
            TicketDetailsResp resp = new TicketDetailsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Ticket/TicketDetailsUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<TicketDetailsResp>(request, url, ct);
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
        public async Task<ProductBenefitsResp> ProductBenefitsFind(ProductBenefitsFindWithProductIdFilterReq request, CancellationToken ct)
        {
            ProductBenefitsResp resp = new ProductBenefitsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductBenefits/ProductBenefitsFindWithProductIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductBenefitsResp>(request, url, ct);
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
        public async Task<ProductBenefitsResp> ProductBenefitsFindAll(ProductBenefitsFindWithProductIdFilterReq request, CancellationToken ct)
        {
            ProductBenefitsResp resp = new ProductBenefitsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductBenefits/ProductBenefitsTemplateFindAllFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductBenefitsResp>(request, url, ct);
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
        public async Task<ProductBenefitsResp> ProductBenefitCreate(ProductBenefitsNewRecReq request, CancellationToken ct)
        {
            ProductBenefitsResp resp = new ProductBenefitsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductBenefits/ProductBenefitsNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductBenefitsResp>(request, url, ct);
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
        public async Task<ProductBenefitsResp> ProductBenefitUpdate(ProductBenefitsNewRecReq request, CancellationToken ct)
        {
            ProductBenefitsResp resp = new ProductBenefitsResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductBenefits/ProductBenefitsUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductBenefitsResp>(request, url, ct);
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
        public async Task<ProductCombinationListResp> ProductCombinationByProductId(ProductCombinationFindWithProductIdFilterReq request, CancellationToken ct)
        {
            ProductCombinationListResp resp = new ProductCombinationListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductCombination/ProductCombinationFindWithProductIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductCombinationListResp>(request, url, ct);
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
        
        public async Task<ProductPriceListResp> ProductPriceListFind(ProductPriceListFindWithProductIdFilterReq request, CancellationToken ct)
        {
            ProductPriceListResp resp = new ProductPriceListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductPriceList/ProductPriceListFindWithProductIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductPriceListResp>(request, url, ct);
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
        public async Task<BusinessLineDetailsProductResp> GetBuinessLineCodeFromProductID(BusinessLineDetailsProductFindWithProductIdFilterRecReq request, CancellationToken ct)
        {
            BusinessLineDetailsProductResp resp = new BusinessLineDetailsProductResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/BusinessLineDetailsProduct/BusinessLineDetailsProductFindWithProductIdFilter";
                resp = await _httpClientHelper.PostApiRequestModelAsync<BusinessLineDetailsProductResp>(request, url, ct);
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
        public async Task<ProductCombinationResp> CreateProductCombination(ProductCombinationNewRecReq request, CancellationToken ct)
        {
            ProductCombinationResp resp = new ProductCombinationResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductCombination/ProductCombinationNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductCombinationResp>(request, url, ct);
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
        public async Task<ProductCombinationDeaWithRecIdResp> DeactivateProductCombination(ProductCombinationDeaWithRecIdReq request, CancellationToken ct)
        {
            ProductCombinationDeaWithRecIdResp resp = new ProductCombinationDeaWithRecIdResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductCombination/ProductCombinationDeacRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductCombinationDeaWithRecIdResp>(request, url, ct);
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
        public async Task<ProductCombinationResp> UpdateProductCombination(ProductCombinationUpdRecReq request, CancellationToken ct)
        {
            ProductCombinationResp resp = new ProductCombinationResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductCombination/productCombinationUpdRecReq";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductCombinationResp>(request, url, ct);
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
        public async Task<ProductPriceListResp> CreateProductPriceList(ProductPriceListNewRecReq request, CancellationToken ct)
        {
            ProductPriceListResp resp = new ProductPriceListResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/ProductPriceList/ProductPriceListNewRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductPriceListResp>(request, url, ct);
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
        public async Task<ProductDetailsPOINetworkResp> UpdateProductNetwork(ProductDetailsPOINetworkUpdRecReq request, CancellationToken ct)
        {
            ProductDetailsPOINetworkResp resp = new ProductDetailsPOINetworkResp();
            try
            {
                var url = _configuration["ApiURL"] + "api/Product/ProductDetailsPOINetworkUpdRec";
                resp = await _httpClientHelper.PostApiRequestModelAsync<ProductDetailsPOINetworkResp>(request, url, ct);
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
    }
}
