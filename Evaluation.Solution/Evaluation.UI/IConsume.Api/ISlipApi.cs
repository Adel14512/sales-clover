
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Response.BL331211;

namespace Evaluation.UI.IConsume.Api
{
    public interface ISlipApi
    {
        Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip2(SalesTransactionBL321110UpdSlip2RecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip3(SalesTransactionBL321110UpdSlip3RecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip4(SalesTransactionBL321110UpdSlip4RecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110Resp> SalesTransactionBL321110UpdSlip5(SalesTransactionBL321110UpdSlip5RecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110DetailsResp> SalesTransactionBL321110DetailsUpdSlip2(SalesTransactionBL321110DetailsUpdSlip2RecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110DetailsResp> SalesTransactionBL321110DetailsUpdSlip3(SalesTransactionBL321110DetailsUpdSlip3RecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110DetailsResp> SalesTransactionBL321110DetailsUpdSlip4(SalesTransactionBL321110DetailsUpdSlip4RecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110DetailsPricesResp> SalesTransactionBL321110DetailsPricesNewRec(SalesTransactionBL321110DetailsPricesNewRecReq request, CancellationToken ct);

        Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip2(SalesTransactionBL331211UpdSlip2RecReq request, CancellationToken ct);
        Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip3(SalesTransactionBL331211UpdSlip3RecReq request, CancellationToken ct);
        Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip4(SalesTransactionBL331211UpdSlip4RecReq request, CancellationToken ct);
        Task<SalesTransactionBL331211Resp> SalesTransactionBL331211UpdSlip5(SalesTransactionBL331211UpdSlip5RecReq request, CancellationToken ct);
       
        Task<SalesTransactionBL331211DetailsResp> SalesTransactionBL331211DetailsUpdSlip3(SalesTransactionBL331211DetailsUpdSlip3RecReq request, CancellationToken ct);
        Task<SalesTransactionBL331211DetailsResp> SalesTransactionBL331211DetailsUpdSlip4(SalesTransactionBL331211DetailsUpdSlip4RecReq request, CancellationToken ct);
        Task<SalesTransactionBL331211DetailsPricesResp> SalesTransactionBL331211DetailsPricesNewRec(SalesTransactionBL331211DetailsPricesNewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip2(SalesTransactionBL041312UpdSlip2RecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip3(SalesTransactionBL041312UpdSlip3RecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip4(SalesTransactionBL041312UpdSlip4RecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> SalesTransactionBL041312UpdSlip5(SalesTransactionBL041312UpdSlip5RecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312DetailsResp> SalesTransactionBL041312DetailsUpdSlip3(SalesTransactionBL041312DetailsUpdSlip3RecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312DetailsResp> SalesTransactionBL041312DetailsUpdSlip4(SalesTransactionBL041312DetailsUpdSlip4RecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312DetailsPricesResp> SalesTransactionBL041312DetailsPricesNewRec(SalesTransactionBL041312DetailsPricesNewRecReq request, CancellationToken ct);
    }
}
