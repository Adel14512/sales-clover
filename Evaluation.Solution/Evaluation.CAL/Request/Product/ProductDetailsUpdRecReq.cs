using Evaluation.CAL.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductDetailsUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ProductDetailsUpdDto ProductDetails { get; set; }
    }
}
