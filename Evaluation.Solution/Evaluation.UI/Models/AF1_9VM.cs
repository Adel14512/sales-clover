using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL090703;
using Evaluation.UI.DTO.Global;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_9VM
    {
        public AF1_9VM()
        {
            AF1BL090703Dtco = new AF1BL090703Dtco();
        }
        [Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public AF1BL090703Dtco AF1BL090703Dtco { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL090703Dto> AF1BL090703List { get; set; }
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
