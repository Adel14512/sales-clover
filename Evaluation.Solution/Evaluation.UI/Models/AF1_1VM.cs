using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL010602;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_1VM
    {
        public AF1_1VM()
        {
            AF1BL010602Dtco = new AF1BL010602Dtco();
        }
        [Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public AF1BL010602Dtco AF1BL010602Dtco { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL010602Dto> AF1BL010602List { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<StayTripOptionDto> StayTripOption { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public ContactVM ContactVM { get; set; }   
    }
}
