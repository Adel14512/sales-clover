

using Evaluation.UI.DTO.ProductBenefits;

namespace Evaluation.UI.Response.ProductBenefits
{
    public class ProductBenefitsTemplateResp : GenericWebResponse
    {
        public List<ProductBenefitsTemplateDto> ProductBenefitsTemplateList { get; set; }
    }
}
