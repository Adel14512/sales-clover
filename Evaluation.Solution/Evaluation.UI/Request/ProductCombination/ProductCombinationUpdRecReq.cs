
using Evaluation.UI.DTO.ProductCombination;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductCombination
{
    public class ProductCombinationUpdRecReq : GenericEmptyReq
    {
        [Required]
        public ProductCombinationUpdDto ProductCombination { get; set; }
    }
}
