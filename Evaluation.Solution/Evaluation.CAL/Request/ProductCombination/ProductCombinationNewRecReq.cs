using Evaluation.CAL.DTO.ProductCombination;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.ProductCombination
{
    public class ProductCombinationNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public ProductCombinationNewDto ProductCombination { get; set; }
    }
}
