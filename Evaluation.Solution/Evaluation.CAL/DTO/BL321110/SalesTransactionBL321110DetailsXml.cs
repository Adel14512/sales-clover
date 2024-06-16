using System;

namespace Evaluation.CAL.DTO.BL321110
{
    public class SalesTransactionBL321110DetailsXml
    {
        public int RecId { get; set; }
        public int SalesTrxId { get; set; }
        public string Insurer_Code { get; set; }
        public string ThirdPartyAdmin_Code { get; set; }
        public int ContactId { get; set; }
        public string AF1BL321110 { get; set; }
        public string Slip2BL321110 { get; set; }
        public string Slip3BL321110 { get; set; }
        public string Slip4BL321110 { get; set; }
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
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }
}
