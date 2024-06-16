using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BusinessLineDetailsProduct
{
    public class BusinessLineDetailsProductFindWithProductIdFilterRecReq : GenericEmptyReq
    {
        [Required]
        public int ProductId { get; set; }
    }
}
