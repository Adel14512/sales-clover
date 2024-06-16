using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Evaluation.CAL.DTO.BL77
{
    public class SalesTransactionBL77Dto
    {
        public int RecId { get; set; }
        public int BusinessLineId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public List<AF1BL77Dto> AF1BL77 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}