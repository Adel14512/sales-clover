using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductDetailsFindWithProductIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
