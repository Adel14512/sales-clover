using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Dashboard
{
    public class PolicyInquiryReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
