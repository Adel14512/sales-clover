using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class ContactChannelNewDto
    {
        public string ChannelCode { get; set; }
        public string ContactChannelValue { get; set; }
        //public int CountryCode { get; set; }
        //public int AreaCode { get; set; }
        public int? Extension { get; set; }
        //public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
