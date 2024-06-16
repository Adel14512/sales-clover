using System;


namespace Evaluation.CAL.DTO.Ticket
{
    public class TicketDetailsUpdDto
    {
        public int TicketId { get; set; }
        public string TicketCode { get; set; }
        public string BusinessLineCode { get; set; }
        public int SalesTransactionId { get; set; }
        public int ParentSalesTransactionId { get; set; }
    }
}
