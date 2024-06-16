using System.Text.Json.Serialization;

namespace Evaluation.UI.Models
{
    public class LeadLookupDto
    {
        public int RecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
        public bool IsDefault { get; set; }
        public string TableName { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
