using Evaluation.UI.Request;
using Evaluation.UI.Response;

namespace Evaluation.UI.IConsume.Api
{
    public interface IGenderApi
    {
        Task<List<GenderResp>> GetAllGender(GenericEmptyReq request, CancellationToken ct);
    }
}
