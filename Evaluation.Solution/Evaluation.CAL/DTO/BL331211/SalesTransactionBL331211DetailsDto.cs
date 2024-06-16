using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL331211
{
    public class SalesTransactionBL331211DetailsDto
    {
        public int RecId { get; set; }
        public int SalesTrxId { get; set; }
        public string Insurer_Code { get; set; }
        public string ThirdPartyAdmin_Code { get; set; }
        public int ContactId { get; set; }
        public List<AF1BL331211Dto> AF1BL331211 { get; set; }
        public List<Slip2BL331211Dto> Slip2BL331211 { get; set; }
        public List<Slip3BL331211Dto> Slip3BL331211 { get; set; }
        public List<Slip4BL331211Dto> Slip4BL331211 { get; set; }
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
