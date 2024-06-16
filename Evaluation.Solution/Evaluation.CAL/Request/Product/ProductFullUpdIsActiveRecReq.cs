using Evaluation.CAL.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductFullUpdIsActiveRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
