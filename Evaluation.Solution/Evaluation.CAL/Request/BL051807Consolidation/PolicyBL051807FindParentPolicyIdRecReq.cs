using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL051807Consolidation
{
    public class PolicyBL051807FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
