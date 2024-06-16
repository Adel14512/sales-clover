using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.DTO.BL070806Consolidation;
using Evaluation.UI.DTO.Global;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models.Consolidation
{
    public class Consolidation070806VM
    {
        public List<PolicyBL070806Dto> Policy { get; set; }
        public SalesTransactionBL070806Dto SalesTransactionBL070806 { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int SalesTransactionId { get; set; }
        public string BusinessLineCode { get; set; }
        public List<PaymentScheduleBL070806Dto> PaymentSchedule { get; set; }
        public AF1BL070806Dto AF1BL070806Dtco { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL070806Dto> AF1BL070806List { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<PolicyRelatedDocBL070806Dto> PolicyRelatedDoc { get; set; }
        public List<NetworkLevelDto> NetworkLevel { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<ClientDto> Clients { get; set; }
        public List<MasterDto> Masters { get; set; }
    }
}
