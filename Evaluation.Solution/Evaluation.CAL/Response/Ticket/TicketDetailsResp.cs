using Evaluation.CAL.DTO.BLDuplication;
using Evaluation.CAL.DTO.Ticket;
using System;


namespace Evaluation.CAL.Response.Ticket
{
    public class TicketDetailsResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public TicketDetailsDto TicketDetails { get; set; }
    }
}
