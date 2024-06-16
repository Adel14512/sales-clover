using Evaluation.CAL.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductDetailsNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ProductDetailsNewDto ProductDetails { get; set; }
    }
}
