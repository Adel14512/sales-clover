
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductCombination
{
    public class ProductCombinationFindWithProductIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int ProductId { get; set; }
    }
}
