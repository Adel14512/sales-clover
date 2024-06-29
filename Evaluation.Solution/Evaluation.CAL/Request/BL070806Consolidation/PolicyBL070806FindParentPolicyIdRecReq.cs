using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL070806Consolidation
{
    public class PolicyBL070806FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
