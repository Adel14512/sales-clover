using Evaluation.CAL.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductFullUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ProductFullUpdDto ProductFull { get; set; }
    }
}
