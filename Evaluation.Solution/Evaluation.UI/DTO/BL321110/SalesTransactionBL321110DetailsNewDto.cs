using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL321110
{
    public class SalesTransactionBL321110DetailsNewDto
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
        public bool AgeCalculationYear { get; set; }
        public bool AgeCalculationFullDate { get; set; }
        public DateTime AgeCalculationStartDate { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
