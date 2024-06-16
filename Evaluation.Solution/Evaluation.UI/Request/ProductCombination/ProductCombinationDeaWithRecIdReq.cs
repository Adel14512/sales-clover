using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductCombination
{
    public class ProductCombinationDeaWithRecIdReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
    }
}
