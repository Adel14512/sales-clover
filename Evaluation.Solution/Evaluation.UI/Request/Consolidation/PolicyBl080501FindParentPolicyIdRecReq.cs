using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;


namespace Evaluation.UI.Request.Consolidation
{
    public class PolicyBl080501FindParentPolicyIdRecReq : GenericEmptyReq
	{
        public string ParentPolicyId { get; set; }
    }
}
