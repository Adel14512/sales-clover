using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.DTO.Global;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_7VM
    {
        public AF1_7VM()
        {
            AF1BL070806Dtco = new AF1BL070806Dtco();
        }
        [Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public AF1BL070806Dtco AF1BL070806Dtco { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public int MasterId { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL070806Dto> AF1BL070806List { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<MasterDto> Masters { get; set; }
        public ContactVM ContactVM { get; set; }   
    }
}
