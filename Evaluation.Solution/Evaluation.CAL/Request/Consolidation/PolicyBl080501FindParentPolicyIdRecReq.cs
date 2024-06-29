using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.Consolidation
{
    public class PolicyBl080501FindParentPolicyIdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ParentPolicyId { get; set; }
    }
}
