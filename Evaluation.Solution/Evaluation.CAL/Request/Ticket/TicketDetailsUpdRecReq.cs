using Evaluation.CAL.DTO.BLDuplication;
using Evaluation.CAL.DTO.Ticket;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Ticket
{
    public class TicketDetailsUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }

        [Required]
        public TicketDetailsUpdDto TicketDetails { get; set; }
    }
}
