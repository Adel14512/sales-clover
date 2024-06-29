using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL281609Consolidation
{
    public class PolicyBL281609FindParentPolicyIdRecReq
    {

        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
