using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Ticket
{
    public class TicketDetailsDto
    {
        public int TicketId { get; set; }
        public string TicketCode { get; set; }
        public string BusinessLineCode { get; set; }
        public int SalesTransactionId { get; set; }
        public int ParentSalesTransactionId { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
