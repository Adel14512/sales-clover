using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL301401Consolidation
{
    public class PolicyBL301401FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
