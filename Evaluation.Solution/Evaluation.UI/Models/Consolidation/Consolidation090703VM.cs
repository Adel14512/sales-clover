using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL090703;
using Evaluation.UI.DTO.BL090703Consolidation;
using Evaluation.UI.DTO.Global;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models.Consolidation
{
    public class Consolidation090703VM
    {
        public List<PolicyBL090703Dto> Policy { get; set; }
        public SalesTransactionBL090703Dto SalesTransactionBL090703 { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int SalesTransactionId { get; set; }
        public string BusinessLineCode { get; set; }
        public List<PaymentScheduleBL090703Dto> PaymentSchedule { get; set; }
        public AF1BL090703Dto AF1BL090703Dtco { get; set; }
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
        public List<PolicyRelatedDocBL090703Dto> PolicyRelatedDoc { get; set; }
        public List<NetworkLevelDto> NetworkLevel { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<ClientDto> Clients { get; set; }
        public List<MasterDto> Masters { get; set; }
    }
}
