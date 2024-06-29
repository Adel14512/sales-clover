using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL041312Consolidation
{
    public class PolicyBL041312FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
