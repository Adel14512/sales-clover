
using Evaluation.UI.DTO.Dashboard;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.Dashboard
{
    public class TicketHistoryResp : GenericWebResponse
    {
        public List<TicketHistoryDto> TicketHistory { get; set; }
    }
}
