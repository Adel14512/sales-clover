using Evaluation.UI.Request.Dashboard;
using Evaluation.UI.Response.Dashboard;

namespace Evaluation.UI.IConsume.Api
{
    public interface IDashboardApi
    {
        Task<ProductPriceControlResp> ProductPriceControFindAll(ProductPriceControlReq request, CancellationToken ct);
        Task<TicketHistoryResp> TicketHistoryFindDataWithNbrDaysFilter(TicketHistoryReq request, CancellationToken ct);
    }
}
