using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL021502
{
    public class SalesTransactionBL021502Dto
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public List<AF1BL021502Dto> AF1BL021502 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
