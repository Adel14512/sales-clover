
using Evaluation.UI.Request;
using Evaluation.UI.Request.AF1ColHeader;
using Evaluation.UI.Request.Global;
using Evaluation.UI.Response;
using Evaluation.UI.Response.AF1ColHeader;
using Evaluation.UI.Response.Global;

namespace Evaluation.UI.IConsume.Api
{
    public interface IGeneralListApi
    {
        Task<GeneralListResp> GetAllGeneralLists(GenericEmptyReq request, CancellationToken ct);
        Task<AF1ColHeaderResp> CheckExcelImportValidation(AF1ColHeaderFindWithColFilterReq request, CancellationToken ct);
        Task<GlobalLookupFindAllResp> GetGlobalLookupFindAll(GlobalLookupFindAllReq request, CancellationToken ct);
    }
}
