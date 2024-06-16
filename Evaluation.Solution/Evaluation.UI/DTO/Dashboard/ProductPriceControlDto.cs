using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Dashboard
{
    public class ProductPriceControlDto
    {
        public string BusinessLineCode { get; set; }
        public string BusinessLineName { get; set; }
        public int ProductId { get; set; }
        public string InsurerProductName { get; set; }
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public string InsurerCountry { get; set; }
        public DateTime LastDatePrice { get; set; }
        public int ModificationCount { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
