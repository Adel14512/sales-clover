
using Evaluation.UI.DTO.Product;
using Evaluation.UI.Request;
namespace Evaluation.UI.Request.Product
{
    public class ProductDetailsUpdRecReq : GenericEmptyReq
    {
        public ProductDetailsUpdDto ProductDetails { get; set; }
    }
}
