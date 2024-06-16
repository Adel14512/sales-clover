
using Evaluation.CAL.Request.ProductDetailsPOIAllNetwork;
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

namespace Evaluation.UI.IConsume.Api
{
    public interface IProductApi
    {
        Task<ProductFindAllResp> GetAllProduct(ProductFindAllReq request, CancellationToken ct);
        Task<ProductLookupFindAllResp> GetProductLookup(ProductLookupFindAllReq request, CancellationToken ct);
        Task<ProductFullResp> CreateProduct(ProductFullNewRecReq request, CancellationToken ct);
        Task<ProductFullResp> GetProductByID(ProductFindWithRecIdFilterReq request, CancellationToken ct);
        Task<ProductFullResp> UpdateProduct(ProductFullUpdRecReq request, CancellationToken ct);
        Task<ProductDetailsResp> CreateProductDetails(ProductDetailsNewRecReq request, CancellationToken ct);
        Task<ProductDetailsResp> EditProductDetails(ProductDetailsUpdRecReq request, CancellationToken ct);
        Task<ProductDetailsPOIResp> ProductDetailsPOINewRec(ProductDetailsPOINewRecReq request, CancellationToken ct);
        Task<ProductDetailsPOIResp> ProductDetailsPOIUpdRec(ProductDetailsPOIUpdRecReq request, CancellationToken ct);
        Task<TicketDetailsResp> TiketDetailsUpdRec(TicketDetailsUpdRecReq request, CancellationToken ct);
        Task<ProductFullResp> ProductActiveStatus(ProductFullUpdIsActiveRecReq request, CancellationToken ct);
        Task<ProductBenefitsResp> ProductBenefitsFind(ProductBenefitsFindWithProductIdFilterReq request, CancellationToken ct);
        Task<ProductPriceListResp> ProductPriceListFind(ProductPriceListFindWithProductIdFilterReq request, CancellationToken ct);
        Task<ProductBenefitsResp> ProductBenefitCreate(ProductBenefitsNewRecReq request, CancellationToken ct);
        Task<ProductCombinationListResp> ProductCombinationByProductId(ProductCombinationFindWithProductIdFilterReq request, CancellationToken ct);
        Task<BusinessLineDetailsProductResp> GetBuinessLineCodeFromProductID(BusinessLineDetailsProductFindWithProductIdFilterRecReq request, CancellationToken ct);
        Task<ProductCombinationResp> CreateProductCombination(ProductCombinationNewRecReq request, CancellationToken ct);
        Task<ProductCombinationDeaWithRecIdResp> DeactivateProductCombination(ProductCombinationDeaWithRecIdReq request, CancellationToken ct);
        Task<ProductCombinationResp> UpdateProductCombination(ProductCombinationUpdRecReq request, CancellationToken ct);
        Task<ProductPriceListResp> CreateProductPriceList(ProductPriceListNewRecReq request, CancellationToken ct);
        Task<ProductBenefitsResp> ProductBenefitsFindAll(ProductBenefitsFindWithProductIdFilterReq request, CancellationToken ct);
        Task<ProductDetailsPOINetworkResp> UpdateProductNetwork(ProductDetailsPOINetworkUpdRecReq request, CancellationToken ct);
    }
}
