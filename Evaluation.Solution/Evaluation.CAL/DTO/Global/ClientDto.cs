using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.Global
{
    public class ClientDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int MasterId { get; set; }
        public bool IsDefault { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
