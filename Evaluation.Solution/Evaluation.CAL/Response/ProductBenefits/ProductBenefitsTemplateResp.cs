using Evaluation.CAL.DTO.ProductBenefits;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.ProductBenefits
{
    public class ProductBenefitsTemplateResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ProductBenefitsTemplateDto> ProductBenefitsTemplateList { get; set; }
    }
}
