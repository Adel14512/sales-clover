using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.Product
{
    public class ProductLookupDto
    {
        public int RecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        //public string Type { get; set; }
        public string IsDefault { get; set; }
        public string TableName { get; set; }
        public string BranchCategoryClassId { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
