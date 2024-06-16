using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.ProductCombination
{
    public class ProductCombinationDeaWithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
    }
}
