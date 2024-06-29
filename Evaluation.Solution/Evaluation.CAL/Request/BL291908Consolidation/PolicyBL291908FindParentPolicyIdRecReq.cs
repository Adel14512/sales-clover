using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL291908Consolidation
{
    public class PolicyBL291908FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
