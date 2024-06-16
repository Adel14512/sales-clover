using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Product
{
    public class ProductFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public bool IsActive { get; set; }
    }
}
