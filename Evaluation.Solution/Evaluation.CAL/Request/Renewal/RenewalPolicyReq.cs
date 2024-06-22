using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Renewal
{
    public class RenewalPolicyReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
