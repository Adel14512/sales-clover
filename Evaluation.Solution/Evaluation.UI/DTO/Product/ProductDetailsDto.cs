using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Product
{
    public class ProductDetailsDto
    {
        public int RecId { get; set; }
        public int ProductId { get; set; }
        public int ClassId { get; set; }
        public decimal AmlAmount { get; set; }
        public decimal CostPolicy { get; set; }
        public decimal AdminFees { get; set; }
        public decimal FirstYearDiscount { get; set; }
        public decimal Commision { get; set; }
        public bool IsActive { get; set; }
        public decimal CommisionFromGP { get; set; }
        public decimal VATOnCommision { get; set; }
        public decimal FixedTaxes { get; set; }
        public decimal BuiltInPropTaxes { get; set; }
        public decimal BuiltInCostOfPolicy { get; set; }
        public decimal InsurerLoading { get; set; }
        public decimal CostPolicyAmount { get; set; }
        public decimal FixedTaxAmount { get; set; }
        public decimal ProperTaxPer { get; set; }
        public decimal VatPer { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
