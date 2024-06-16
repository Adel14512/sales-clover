using Evaluation.CAL.DTO.ProductCombination;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.ProductCombination
{
    public class ProductCombinationUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public ProductCombinationUpdDto ProductCombination { get; set; }
    }
}
