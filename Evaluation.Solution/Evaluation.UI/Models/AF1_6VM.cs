using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL061005;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_6VM
    {
        public AF1_6VM()
        {
            AF1BL061005Dto = new AF1BL061005Dto();
        }
        [Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public AF1BL061005Dto AF1BL061005Dto { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL061005Dto> AF1BL061005List { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
