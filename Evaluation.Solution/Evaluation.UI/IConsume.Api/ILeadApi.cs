using Evaluation.UI.Request;
using Evaluation.UI.Request.Lead;
using Evaluation.UI.Response;

namespace Evaluation.UI.IConsume.Api
{
    public interface ILeadApi
    {
        Task<GenericWebResponse> CreateLead(LeadNewRecReq request, CancellationToken ct);
        Task<LeadLookupFindAllResp> GetLookupLead(LeadLookupFindAllReq request, CancellationToken ct);
        Task<GenericWebResponse> UpdateLead(LeadNewRecReq request, CancellationToken ct);
        Task<LeadFindAllResp> GetAllLeads(LeadFindAllReq request, CancellationToken ct);
    }
}
