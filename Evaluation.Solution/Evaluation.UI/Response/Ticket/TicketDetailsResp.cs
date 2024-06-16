
using Evaluation.UI.DTO.Ticket;
using Evaluation.UI.Response;


namespace Evaluation.UI.Response.Ticket
{
    public class TicketDetailsResp :GenericWebResponse
    {
        public TicketDetailsDto TicketDetails { get; set; }
    }
}
