using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class BusinessLineRelatedDocDto
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public string ApplicationForm { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
        public string AttachDocPath { get; set; }
        public byte[] AttachDocBinary { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
