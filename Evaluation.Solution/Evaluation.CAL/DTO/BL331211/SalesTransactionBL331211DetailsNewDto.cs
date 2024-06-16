using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL331211
{
    public class SalesTransactionBL331211DetailsNewDto
    {
        public int RecId { get; set; }
        public int SalesTrxId { get; set; }
        public decimal CommisinOnGPPer { get; set; }
        public decimal AdminFeesAmount { get; set; }
        public decimal CostOfPolicyPer { get; set; }
        public decimal CostOfPolicyAmount { get; set; }
        public decimal FixedTaxesAmount { get; set; }
        public decimal FixedTaxesPer { get; set; }
        public decimal VATPer { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
