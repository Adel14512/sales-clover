using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL030904;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_3VM
    {
        public AF1_3VM()
        {
            AF1BL030904Dto = new AF1BL030904Dto();
        }
        [Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public AF1BL030904Dto AF1BL030904Dto { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL030904Dto> AF1BL030904List { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public ContactVM ContactVM { get; set; }   
    }
}
