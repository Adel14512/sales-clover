﻿using System;

namespace Evaluation.UI.DTO.BL311703
{
    public class SalesTransactionBL311703Xml
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public string AF1BL311703 { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }
}