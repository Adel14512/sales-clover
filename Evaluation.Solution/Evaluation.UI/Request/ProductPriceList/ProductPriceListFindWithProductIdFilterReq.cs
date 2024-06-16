using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductPriceList
{
    public class ProductPriceListFindWithProductIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int ProductId { get; set; }
    }
}
