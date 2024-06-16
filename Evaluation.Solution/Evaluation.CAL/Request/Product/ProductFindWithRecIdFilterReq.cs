using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductFindWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
    }
}
