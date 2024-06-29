using Evaluation.UI.Request.Consolidation;
using Evaluation.UI.Request.BL010602Consolidation;
using Evaluation.UI.Request.BL090703Consolidation;
using Evaluation.UI.Request.BL301401Consolidation;
using Evaluation.UI.Request.BL321110Consolidation;
using Evaluation.UI.Response.BL010602Consolidation;
using Evaluation.UI.Response.BL090703Consolidation;
using Evaluation.UI.Response.BL301401Consolidation;
using Evaluation.UI.Response.BL321110Consolidation;
using Evaluation.UI.Response.Consolidation;
using Evaluation.UI.Request.BL070806Consolidation;
using Evaluation.UI.Response.BL070806Consolidation;
using Evaluation.UI.Response.BL281609Consolidation;
using Evaluation.UI.Request.BL281609Consolidation;
using Evaluation.UI.Request.BL331211Consolidation;
using Evaluation.UI.Response.BL331211Consolidation;
using Evaluation.UI.Response.BL041312Consolidation;
using Evaluation.UI.Request.BL041312Consolidation;

namespace Evaluation.UI.IConsume.Api
{
    public interface IConsolidationApi
    {
        Task<PolicyResp> CreateConsolidation(PolicyNewRecReq request, CancellationToken ct);
        Task<PolicyResp> PolicyFindAllWithParentPolicyId(PolicyBl080501FindParentPolicyIdRecReq request, CancellationToken ct);

		Task<PolicyRelatedDocResp> UpdatePolicyAndDocuments(PolicyRelatedDocUpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocResp> CreatePolicyAndDocuments(PolicyRelatedDocNewRecReq request, CancellationToken ct);
        Task<PolicyUpdResp> UpdatePolicyForm(PolicyUpdRecReq request, CancellationToken ct);
        Task<PolicyBL301401Resp> CreateConsolidation301401(PolicyBL301401NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL301401Resp> UpdatePolicyAndDocuments301401(PolicyRelatedDocBL301401UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL301401Resp> CreatePolicyAndDocuments301401(PolicyRelatedDocBL301401NewRecReq request, CancellationToken ct);
        Task<PolicyBL301401UpdResp> UpdatePolicyForm301401(PolicyBL301401UpdRecReq request, CancellationToken ct);
        Task<PolicyBL321110Resp> CreateConsolidation321110(PolicyBL321110NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL321110Resp> UpdatePolicyAndDocuments321110(PolicyRelatedDocBL321110UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL321110Resp> CreatePolicyAndDocuments321110(PolicyRelatedDocBL321110NewRecReq request, CancellationToken ct);
        Task<PolicyBL321110UpdResp> UpdatePolicyForm321110(PolicyBL321110UpdRecReq request, CancellationToken ct);
        Task<PolicyBL010602Resp> CreateConsolidation010602(PolicyBL010602NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL010602Resp> UpdatePolicyAndDocuments010602(PolicyRelatedDocBL010602UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL010602Resp> CreatePolicyAndDocuments010602(PolicyRelatedDocBL010602NewRecReq request, CancellationToken ct);
        Task<PolicyBL010602UpdResp> UpdatePolicyForm010602(PolicyBL010602UpdRecReq request, CancellationToken ct);
        Task<PolicyBL090703Resp> CreateConsolidation090703(PolicyBL090703NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL090703Resp> UpdatePolicyAndDocuments090703(PolicyRelatedDocBL090703UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL090703Resp> CreatePolicyAndDocuments090703(PolicyRelatedDocBL090703NewRecReq request, CancellationToken ct);
        Task<PolicyBL090703UpdResp> UpdatePolicyForm090703(PolicyBL090703UpdRecReq request, CancellationToken ct); 
        Task<PolicyBL070806Resp> CreateConsolidation070806(PolicyBL070806NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL070806Resp> UpdatePolicyAndDocuments070806(PolicyRelatedDocBL070806UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL070806Resp> CreatePolicyAndDocuments070806(PolicyRelatedDocBL070806NewRecReq request, CancellationToken ct);
        Task<PolicyBL070806UpdResp> UpdatePolicyForm070806(PolicyBL070806UpdRecReq request, CancellationToken ct);
        Task<PolicyBL281609UpdResp> UpdatePolicyForm281609(PolicyBL281609UpdRecReq request, CancellationToken ct);
        Task<PolicyBL281609Resp> CreateConsolidation281609(PolicyBL281609NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL281609Resp> UpdatePolicyAndDocuments281609(PolicyRelatedDocBL281609UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL281609Resp> CreatePolicyAndDocuments281609(PolicyRelatedDocBL281609NewRecReq request, CancellationToken ct);
        Task<PolicyBL331211UpdResp> UpdatePolicyForm331211(PolicyBL331211UpdRecReq request, CancellationToken ct);
        Task<PolicyBL331211Resp> CreateConsolidation331211(PolicyBL331211NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL331211Resp> UpdatePolicyAndDocuments331211(PolicyRelatedDocBL331211UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL331211Resp> CreatePolicyAndDocuments331211(PolicyRelatedDocBL331211NewRecReq request, CancellationToken ct);
        Task<PolicyBL041312UpdResp> UpdatePolicyForm041312(PolicyBL041312UpdRecReq request, CancellationToken ct);
        Task<PolicyBL041312Resp> CreateConsolidation041312(PolicyBL041312NewRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL041312Resp> UpdatePolicyAndDocuments041312(PolicyRelatedDocBL041312UpdRecReq request, CancellationToken ct);
        Task<PolicyRelatedDocBL041312Resp> CreatePolicyAndDocuments041312(PolicyRelatedDocBL041312NewRecReq request, CancellationToken ct);

    }
}
