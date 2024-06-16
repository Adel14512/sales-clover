using System.ComponentModel.DataAnnotations;
namespace Evaluation.CAL.Request.ProductCombination
{
    public class ProductCombinationFindWithProductIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
