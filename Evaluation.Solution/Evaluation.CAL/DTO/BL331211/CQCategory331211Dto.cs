using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL331211
{
    public class CQCategory331211Dto
    {
        public int CatNbr { get; set; }
        public int Cnt { get; set; }
        public int LimitOfCoverage { get; set; }
        //public string Ambulatory { get; set; }
        //public string PrescriptionMedicine { get; set; }
        //public string DoctorVisit { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
