using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductBenefits
{
    public class ProductBenefitsFindWithProductIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int ProductId { get; set; }
    }
}
