using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL070806Consolidation
{
    public class PolicyBL070806Dto
    {
        public int SalesTransactionId { get; set; }
        public int TicketId { get; set; }
        public string ParentPolicyId { get; set; }
        public string PolicyId { get; set; }
        public string InsurerProduct { get; set; }
        public string PolicyHolder { get; set; }
        public string BusinessLineName { get; set; }
        public string Currency { get; set; }
        public decimal Premium { get; set; }
        public decimal CostOfPolicy { get; set; }
        public decimal PropTaxes { get; set; }
        public decimal FixedTaxes { get; set; }
        public decimal AdminFees { get; set; }
        public decimal VAT { get; set; }
        public decimal PolicyTotal { get; set; }
        public bool BillingToSamePolicyHolder { get; set; }
        public bool ProRataAccept { get; set; }
        public int FamilyId { get; set; }
        public decimal GrossPremiumGP { get; set; }
        public decimal CommisionFromGPPer { get; set; }
        public decimal CommisionFromGPAmount { get; set; }
        public decimal VATOnCommisionPer { get; set; }
        public decimal VATOnCommisionAmount { get; set; }
        public decimal BuiltInFixedTaxesAmount { get; set; }
        public decimal BuiltInPropTaxesPer { get; set; }
        public decimal BuiltInPropTaxesAmount { get; set; }
        public decimal BuiltInCostOfPolicyAmount { get; set; }
        public decimal InsurerLoadingPer { get; set; }
        public decimal InsurerLoadingAmount { get; set; }
        public decimal NetPremiumAmount { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
