using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL321110
{
    public class SalesTransactionBL321110Dto
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
        public List<AF1BL321110Dto> AF1BL321110 { get; set; }
        public List<Slip2BL321110Dto> Slip2BL321110 { get; set; }
        public List<Slip3BL321110Dto> Slip3BL321110 { get; set; }
        public List<Slip4BL321110Dto> Slip4BL321110 { get; set; }
        public List<Slip5BL321110Dto> Slip5BL321110 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
