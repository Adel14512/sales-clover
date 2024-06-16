using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Product
{
    public class ProductDetailsPOIDto
    {
        public int RecId { get; set; }
        public int ProductId { get; set; }
        public int TechnicalSheet { get; set; }
        public int SectionId { get; set; }
        public bool Covered { get; set; }
        public int TerritorialScope { get; set; }
        public int ClassId { get; set; }
        public decimal CommissionInsurance { get; set; }
        public decimal LimitAmount { get; set; }
        public decimal LimitAmountMaxRange { get; set; }
        public int NetworkId { get; set; }
        //public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
