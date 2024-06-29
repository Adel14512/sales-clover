using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL021502Consolidation
{
    public class PolicyBL021502FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
