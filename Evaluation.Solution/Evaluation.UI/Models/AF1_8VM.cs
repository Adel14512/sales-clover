using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.Global;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_8VM
    {
        public AF1_8VM()
        {
            AF1BL080501Dtco = new AF1BL080501Dtco();
        }
        [Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public AF1BL080501Dtco AF1BL080501Dtco { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL080501Dto> AF1BL080501List { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<NetworkLevelDto> NetworkLevel { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<ClientDto> Clients { get; set; }
        public List<MasterDto> Masters { get; set; }
    }
}
