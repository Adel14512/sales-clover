
using Evaluation.UI.DTO.ProductBenefits;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductBenefits
{
    public class ProductBenefitsNewRecReq : GenericEmptyReq
    {
        [Required]
        public List<ProductBenefitsNewDto> ProductBenefitsList { get; set; }
    }
}
