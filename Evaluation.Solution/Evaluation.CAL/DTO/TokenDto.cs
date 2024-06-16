using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
