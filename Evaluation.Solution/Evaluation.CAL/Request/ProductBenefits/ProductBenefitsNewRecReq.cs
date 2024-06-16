using Evaluation.CAL.DTO.ProductBenefits;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.ProductBenefits
{
    public class ProductBenefitsNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public List<ProductBenefitsNewDto> ProductBenefitsList { get; set; }
    }
}
