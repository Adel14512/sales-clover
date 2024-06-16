using Evaluation.CAL.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductDetailsPOINewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ProductDetailsPOINewDto ProductDetails { get; set; }
    }
}
