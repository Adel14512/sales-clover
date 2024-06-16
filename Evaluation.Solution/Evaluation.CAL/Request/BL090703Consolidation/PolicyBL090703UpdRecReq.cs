using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL090703Consolidation
{
    public class PolicyBL090703UpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public int TicketId { get; set; }
        public string ParentPolicyId { get; set; }
        public string PolicyId { get; set; }
        public string BusinessLineCode { get; set; }
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
        public string PolicyHolder { get; set; }
    }
}
