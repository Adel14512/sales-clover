using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class BusinessLineDto
    {
        //public int Id { get; set; }
        public int RecId { get; set; }
        public string SalesType { get; set; }
        public string ClientType { get; set; }
        public string ProductCategory { get; set; }
        public string NbrOfInsured { get; set; }
        public string ProductType { get; set; }
        public string ProductClass { get; set; }
        //public List<ProductCategoryDto> ProductCategory { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
