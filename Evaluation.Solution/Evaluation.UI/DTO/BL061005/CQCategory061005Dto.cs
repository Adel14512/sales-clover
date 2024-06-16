using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL061005
{
    public class CQCategory061005Dto
    {
        public int CatNbr { get; set; }
        public int Cnt { get; set; }
        //public string AnnualWages { get; set; }
        public int LimitOfCoverage { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
