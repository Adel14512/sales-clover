using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL321110
{
    public class CQHeader321110
    {
        public string TicketCode { get; set; }
        public DateTime OpenDate { get; set; }
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
