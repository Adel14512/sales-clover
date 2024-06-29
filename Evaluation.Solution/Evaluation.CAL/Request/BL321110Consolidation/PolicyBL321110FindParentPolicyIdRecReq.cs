using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL321110Consolidation
{
    public class PolicyBL321110FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
