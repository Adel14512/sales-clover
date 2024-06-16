using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Global
{
    public class GlobalLookupDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string TableName { get; set; }
        public string Type { get; set; }
        public bool IsDefault { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
