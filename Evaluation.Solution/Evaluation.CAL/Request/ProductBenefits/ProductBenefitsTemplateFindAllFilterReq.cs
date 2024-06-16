using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.ProductBenefits
{
    public class ProductBenefitsTemplateFindAllFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
