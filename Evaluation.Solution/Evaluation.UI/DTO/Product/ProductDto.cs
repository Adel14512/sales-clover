using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Product
{
    public class ProductDto
    {
        public int RecId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductClass { get; set; }
        public string ProductName { get; set; }
        public string Insurer { get; set; }
        public string ThirdPartyAdmin { get; set; }
        public string Currency { get; set; } 
        //public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
