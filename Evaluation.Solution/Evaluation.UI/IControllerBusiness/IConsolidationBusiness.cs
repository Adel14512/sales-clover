using Evaluation.UI.DTO;
using Evaluation.UI.Models.Consolidation;
using Evaluation.UI.Response.BL010602Consolidation;
using Evaluation.UI.Response.BL041312Consolidation;
using Evaluation.UI.Response.BL070806Consolidation;
using Evaluation.UI.Response.BL090703Consolidation;
using Evaluation.UI.Response.BL281609Consolidation;
using Evaluation.UI.Response.BL301401Consolidation;
using Evaluation.UI.Response.BL321110Consolidation;
using Evaluation.UI.Response.BL331211Consolidation;
using Evaluation.UI.Response.Consolidation;
using System.Security.Claims;

namespace Evaluation.UI.IControllerBusiness
{
    public interface IConsolidationBusiness
    {
        Task<ConsolidationVM> GetConsolidationBusiness(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocResp> CreateConsolidation080501Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocResp> UpdateConsolidation080501Business(IFormFile uploadDoc,  IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyUpdResp> UpdateConsolidation080501FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<Consolidation321110VM> GetConsolidationBusiness321110(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL321110Resp> UpdateConsolidation321110Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL321110Resp> CreateConsolidation321110Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL321110UpdResp> UpdateConsolidation321110FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<Consolidation301401VM> GetConsolidationBusiness301401(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL301401Resp> UpdateConsolidation301401Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL301401Resp> CreateConsolidation301401Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL301401UpdResp> UpdateConsolidation301401FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<Consolidation010602VM> GetConsolidationBusiness010602(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL010602Resp> UpdateConsolidation010602Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL010602Resp> CreateConsolidation010602Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL010602UpdResp> UpdateConsolidation010602FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);  
        Task<Consolidation090703VM> GetConsolidationBusiness090703(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL090703Resp> UpdateConsolidation090703Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL090703Resp> CreateConsolidation090703Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL090703UpdResp> UpdateConsolidation090703FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct); 
        Task<Consolidation070806VM> GetConsolidationBusiness070806(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL070806Resp> UpdateConsolidation070806Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL070806Resp> CreateConsolidation070806Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL070806UpdResp> UpdateConsolidation070806FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<Consolidation281609VM> GetConsolidationBusiness281609(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL281609Resp> UpdateConsolidation281609Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL281609Resp> CreateConsolidation281609Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL281609UpdResp> UpdateConsolidation281609FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<Consolidation331211VM> GetConsolidationBusiness331211(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL331211Resp> UpdateConsolidation331211Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL331211Resp> CreateConsolidation331211Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL331211UpdResp> UpdateConsolidation331211FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<Consolidation041312VM> GetConsolidationBusiness041312(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<PolicyRelatedDocBL041312Resp> UpdateConsolidation041312Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyRelatedDocBL041312Resp> CreateConsolidation041312Business(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
        Task<PolicyBL041312UpdResp> UpdateConsolidation041312FormBusiness(IFormFile uploadDoc, IFormCollection keyValues, UserDto user, CancellationToken ct);
    }

}
