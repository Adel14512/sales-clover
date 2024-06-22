
using Evaluation.UI.DTO.Renewal;

namespace Evaluation.UI.Response.Renewal
{
    public class RenewalPolicyResp : GenericWebResponse
	{
        public List<RenewalPolicyDto> RenewalPolicy { get; set; }
    }
}
