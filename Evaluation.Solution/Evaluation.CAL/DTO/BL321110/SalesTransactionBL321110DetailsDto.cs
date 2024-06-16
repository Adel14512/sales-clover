using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL321110
{
    public class SalesTransactionBL321110DetailsDto
    {
        public int RecId { get; set; }
        public int SalesTrxId { get; set; }
        public string Insurer_Code { get; set; }
        public string ThirdPartyAdmin_Code { get; set; }
        public int ContactId { get; set; }
        public List<AF1BL321110Dto> AF1BL321110 { get; set; }
        public List<Slip2BL321110Dto> Slip2BL321110 { get; set; }
        public List<Slip3BL321110Dto> Slip3BL321110 { get; set; }
        public List<Slip4BL321110Dto> Slip4BL321110 { get; set; }
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
