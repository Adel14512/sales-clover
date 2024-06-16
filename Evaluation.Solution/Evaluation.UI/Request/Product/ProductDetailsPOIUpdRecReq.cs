

using Evaluation.UI.DTO.Product;

namespace Evaluation.UI.Request.Product
{
    public class ProductDetailsPOIUpdRecReq :GenericEmptyReq
    {
        public ProductDetailsPOIUpdDto ProductDetails { get; set; }
    }
}
