using Evaluation.UI.Request.SpecialCondition;
using Evaluation.UI.Response.SpecialCondition;

namespace Evaluation.UI.IConsume.Api
{
    public interface ISpecialConditionApi
    {
        Task<SpecialConditionResp> FindSpecialCondition(SpecialConditionFindWithColFilterReq request, CancellationToken ct);
        Task<SpecialConditionResp> InsertSpecialCondition(SpecialConditionNewRecReq request, CancellationToken ct);
    }
}
