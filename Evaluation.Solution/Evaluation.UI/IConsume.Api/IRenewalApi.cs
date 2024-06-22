using Evaluation.UI.Request.Renewal;
using Evaluation.UI.Response.Renewal;

namespace Evaluation.UI.IConsume.Api
{
    public interface IRenewalApi
    {
		Task<RenewalPolicyResp> Policy(RenewalPolicyReq request, CancellationToken ct);
		Task<RenewalParameterResp> Parameters(RenewalParameterReq request, CancellationToken ct);
	}
}
