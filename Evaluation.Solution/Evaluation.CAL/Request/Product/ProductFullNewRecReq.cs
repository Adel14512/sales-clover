using Evaluation.CAL.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductFullNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ProductFullNewDto ProductFull { get; set; }
    }
}
