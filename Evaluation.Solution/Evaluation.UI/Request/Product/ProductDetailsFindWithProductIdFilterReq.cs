using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.Product
{
    public class ProductDetailsFindWithProductIdFilterReq :GenericEmptyReq
    {
        [Required]
        public int ProductId { get; set; }
    }
}
