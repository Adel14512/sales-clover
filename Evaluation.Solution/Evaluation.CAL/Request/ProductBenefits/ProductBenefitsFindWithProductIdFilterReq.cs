using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.ProductBenefits
{
    public class ProductBenefitsFindWithProductIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
