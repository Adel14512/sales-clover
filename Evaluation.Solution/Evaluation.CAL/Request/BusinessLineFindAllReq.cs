using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class BusinessLineFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
