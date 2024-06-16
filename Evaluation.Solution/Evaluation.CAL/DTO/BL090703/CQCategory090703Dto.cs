using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL090703
{
    public class CQCategory090703Dto
    {
        public int CatNbr { get; set; }
        public int Cnt { get; set; }
        public string ClassOfCoverage { get; set; }
        public string Ambulatory { get; set; }
        public string PrescriptionMedicine { get; set; }
        public string DoctorVisit { get; set; }       

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
