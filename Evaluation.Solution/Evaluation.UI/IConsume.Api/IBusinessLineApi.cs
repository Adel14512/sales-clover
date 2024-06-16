using Evaluation.UI.Response.BL080501;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL080501;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Response;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Response.BL021502;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Response.BL051807;
using Evaluation.UI.Response.BL291908;
using Evaluation.UI.Request.BL291908;
using Evaluation.UI.Response.BL281609;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Request.BL311703;
using Evaluation.UI.Response.BL311703;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Request.BL051807;
using Evaluation.UI.Request.BLDuplication;
using Evaluation.UI.Response.BL090703;
using Evaluation.UI.Response.BLDuplication;
using Evaluation.UI.Request.BL090703;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Response.BL010602;
using Evaluation.UI.Request.BL010602;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Response.BL061005;
using Evaluation.UI.Request.BL061005;
using Evaluation.UI.Response.BL030904;
using Evaluation.UI.Request.BL030904;

namespace Evaluation.UI.IConsume.Api
{
    public interface IBusinessLineApi
    {
        Task<SalesTransactionMenuFindWithColFilterResp> GetTreeViewBusinessLine(SalesTransactionMenuFindWithColFilterReq request, CancellationToken ct);
        Task<SalesTransactionFindWithContactIdFilterResp> GetDashboard(SalesTransactionFindWithContactIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL010602CQResp> GetCQAF01(SalesTransactionBL010602FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL080501CQResp> GetCQAF8(SalesTransactionBL080501FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL301401CQResp> GetCQAF30(SalesTransactionBL301401FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL321110CQResp> GetCQAF32(SalesTransactionBL321110FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL021502CQResp> GetCQAF02(SalesTransactionBL021502FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL051807CQResp> GetCQAF05(SalesTransactionBL051807FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL070806CQResp> GetCQAF07(SalesTransactionBL070806FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL291908CQResp> GetCQAF29(SalesTransactionBL291908FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL281609CQResp> GetCQAF28(SalesTransactionBL281609FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL311703CQResp> GetCQAF31(SalesTransactionBL311703FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL331211CQResp> GetCQAF33(SalesTransactionBL331211FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL041312CQResp> GetCQAF4(SalesTransactionBL041312FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL090703CQResp> GetCQAF09(SalesTransactionBL090703FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL080501CQResp> GetCQAF8Short(SalesTransactionBL080501FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL070806CQResp> GetCQAF07Short(SalesTransactionBL070806FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL281609CQResp> GetCQAF28Short(SalesTransactionBL281609FindCQWithRecIdFilterReq request, CancellationToken ct);
        Task<BusinessLineDuplicationResp> DuplicateTransaction(BusinessLineDuplicationNewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL080501CQShortFulListResp> DetailedShortLongList(SalesTransactionBL080501FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL301401CQShortFulListResp> DetailedShortLongList301401(SalesTransactionBL301401FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL321110CQShortFulListResp> DetailedShortLongList321110(SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL090703CQShortFulListResp> DetailedShortLongList090703(SalesTransactionBL090703FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL070806CQShortFulListResp> DetailedShortLongList070806(SalesTransactionBL070806FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL010602CQShortFulListResp> DetailedShortLongList010602(SalesTransactionBL010602FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL021502CQShortFulListResp> DetailedShortLongList021502(SalesTransactionBL021502FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL281609CQShortFulListResp> DetailedShortLongList281609(SalesTransactionBL281609FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL030904CQShortFulListResp> DetailedShortLongList030904(SalesTransactionBL030904FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL051807CQShortFulListResp> DetailedShortLongList051807(SalesTransactionBL051807FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL041312CQShortFulListResp> DetailedShortLongList041312(SalesTransactionBL041312FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL061005CQShortFulListResp> DetailedShortLongList061005(SalesTransactionBL061005FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL291908CQShortFulListResp> DetailedShortLongList291908(SalesTransactionBL291908FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL311703CQShortFulListResp> DetailedShortLongList311703(SalesTransactionBL311703FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL331211CQShortFulListResp> DetailedShortLongList331211(SalesTransactionBL331211FindCQShortFullListWithRecIdFilterReq request, CancellationToken ct);
    }
}
