using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL331211Consolidation
{
    public class PolicyBL331211FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
