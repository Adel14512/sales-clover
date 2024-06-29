using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL090703Consolidation
{
    public class PolicyBL090703FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
