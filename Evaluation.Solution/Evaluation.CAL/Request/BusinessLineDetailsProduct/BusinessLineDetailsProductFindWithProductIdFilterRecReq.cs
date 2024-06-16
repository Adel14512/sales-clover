using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BusinessLineDetailsProduct
{
    public class BusinessLineDetailsProductFindWithProductIdFilterRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
