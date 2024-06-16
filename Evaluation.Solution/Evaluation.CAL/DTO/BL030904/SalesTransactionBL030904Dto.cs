using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL030904
{
    public class SalesTransactionBL030904Dto
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public List<AF1BL030904Dto> AF1BL030904 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
