using Evaluation.CAL.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductDetailsPOIUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ProductDetailsPOIUpdDto ProductDetails { get; set; }
    }
}
