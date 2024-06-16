using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO
{
    public class SalesTransactionDto
    {
        public int RecId { get; set; }
        public string TicketCode { get; set; }
        public DateTime OpenDate { get; set; }
        public int SalesTransactionId { get; set; }
        public int ParentSalesTransactionId { get; set; }
        public string BusinessLineCode { get; set; }
        public string BusinessLine { get; set; }
        public int HeaderStatusId { get; set; }
        public string HeaderStatus { get; set; }
        public int DetailStatusId { get; set; }
        public string DetailStatus { get; set; }
        public int InternalStatusId { get; set; }
        public string InternalStatus { get; set; }
        public int NbrDays { get; set; }
        public string TAT { get; set; }
        public string RelatedTable { get; set; }
        public int TicketDetailsId { get; set; }
        public string AF1API { get; set; }
        public string CQAPI { get; set; }
        public string AF1URL { get; set; }
        public string CQURL { get; set; }
        public string PolicyHolder { get; set; }
        public int NbrInssured { get; set; }
        public string AF1Resume { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
