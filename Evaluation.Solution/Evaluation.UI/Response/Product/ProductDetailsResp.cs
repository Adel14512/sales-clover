
using Evaluation.UI.DTO.Product;

namespace Evaluation.UI.Response.Product
{
    public class ProductDetailsResp :GenericWebResponse
    {
        public ProductDetailsDto ProductDetails { get; set; }
    }
}
