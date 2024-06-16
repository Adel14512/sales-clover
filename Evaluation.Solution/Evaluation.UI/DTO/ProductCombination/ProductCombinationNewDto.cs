using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.ProductCombination
{
    public class ProductCombinationNewDto
    {
        public int ProductId { get; set; }
        public int? TechnicalSheet1 { get; set; }
        public int? TechnicalSheet2 { get; set; }
        public int? TechnicalSheet3 { get; set; }
        public int? TechnicalSheet4 { get; set; }
        public int? TechnicalSheet5 { get; set; }
        public int? TechnicalSheet6 { get; set; }
        public int? TechnicalSheet7 { get; set; }
        public int? TechnicalSheet8 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
