using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL010602
{
    public class CQCategory010602Dto
    {
        public int CatNbr { get; set; }
        public int Cnt { get; set; }
        public string CountryDeparture { get; set; }
        public string CountryDestination { get; set; }
        public string StayTripOption { get; set; }
        public int NbOfDays { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
