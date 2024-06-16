using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL041312
{
    public class SalesTransactionBL041312Dto
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
        public List<AF1BL041312Dto> AF1BL041312 { get; set; }
        public List<Slip2BL041312Dto> Slip2BL041312 { get; set; }
        public List<Slip3BL041312Dto> Slip3BL041312 { get; set; }
        public List<Slip4BL041312Dto> Slip4BL041312 { get; set; }
        public List<Slip5BL041312Dto> Slip5BL041312 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
