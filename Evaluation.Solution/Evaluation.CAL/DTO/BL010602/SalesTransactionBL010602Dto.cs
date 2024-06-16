using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL010602
{
    public class SalesTransactionBL010602Dto
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public AF1BL010602Dtco AF1BL010602 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
