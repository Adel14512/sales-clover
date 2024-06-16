using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class ContactChannelDto
    {
        //[JsonProperty(PropertyName = "recId")]
        public int RecId { get; set; }
        public int ContactId { get; set; }
        public int ChannelId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ContactChannelValue { get; set; }
        public string Type { get; set; }
        //public int CountryCode { get; set; }
        //public int AreaCode { get; set; }
        public int Extension { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
