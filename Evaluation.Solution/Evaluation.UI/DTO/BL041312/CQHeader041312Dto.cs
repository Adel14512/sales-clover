using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL041312
{
    public class CQHeader041312Dto
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
