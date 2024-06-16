
using Evaluation.UI.DTO.ProductBenefits;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.ProductBenefits
{
    public class ProductBenefitsResp : GenericWebResponse
    {
        public List<ProductBenefitsDto> ProductBenefitsList { get; set; }
    }
}
