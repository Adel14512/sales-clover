using System;

namespace Evaluation.UI.DTO.BL041312
{
    public class SalesTransactionBL041312Xml
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public string AF1BL041312 { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }
}
