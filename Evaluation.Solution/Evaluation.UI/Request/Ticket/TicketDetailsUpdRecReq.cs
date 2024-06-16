
using Evaluation.UI.DTO.Ticket;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.Ticket
{
    public class TicketDetailsUpdRecReq:GenericEmptyReq
    {

        [Required]
        public TicketDetailsUpdDtoS TicketDetails { get; set; }
    }
}
