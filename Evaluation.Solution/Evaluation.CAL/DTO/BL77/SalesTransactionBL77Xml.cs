using System;

namespace Evaluation.CAL.DTO.BL77
{
    public class SalesTransactionBL77Xml
    {
        public int RecId { get; set; }
        public int BusinessLineId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public string AF1BL77 { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }
}
