using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL010602Consolidation
{
    public class PolicyBL010602FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
