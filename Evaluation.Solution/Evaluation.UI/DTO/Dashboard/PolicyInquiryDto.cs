using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Dashboard
{
    public class PolicyInquiryDto
    {
        public int RecId { get; set; }
        public int SalesTransactionId { get; set; }
        public int TicketId { get; set; }
        public string ParentPolicyId { get; set; }
        public string PolicyId { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string ProductName { get; set; }
        public string InsurerProductName { get; set; }
        public string BusinessLine { get; set; }
        public string PolicyHolder { get; set; }
        public int? ClientId { get; set; }
        public int? MasterId { get; set; }
        public int SupplierId { get; set; }
        public string Currency { get; set; }
        public decimal Premium { get; set; }
        public decimal CostOfPolicy { get; set; }
        public decimal PropTaxes { get; set; }
        public decimal FixedTaxes { get; set; }
        public decimal AdminFees { get; set; }
        public decimal VAT { get; set; }
        public decimal PolicyTotal { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
