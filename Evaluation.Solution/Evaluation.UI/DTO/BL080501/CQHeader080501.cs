using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL080501
{
    public class CQHeader080501
    {
        public string TicketCode { get; set; }
        public DateTime OpenDate { get; set; }
        public string CreatedBy { get; set; }
        public string ContactName { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
