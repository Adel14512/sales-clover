
using Evaluation.UI.DTO.ProductCombination;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductCombination
{
    public class ProductCombinationNewRecReq : GenericEmptyReq
    {
        [Required]
        public ProductCombinationNewDto ProductCombination { get; set; }
    }
}
