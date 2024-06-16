using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.AF1ColHeader
{
    public class AF1ColHeaderDto
    {
        public string AF1Code { get; set; }
        public string AF1ColHeader { get; set; }
        public bool IsActive { get; set; }
        public bool IsColHeaderValid { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
