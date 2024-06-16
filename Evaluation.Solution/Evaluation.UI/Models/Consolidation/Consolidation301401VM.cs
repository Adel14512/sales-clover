using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.DTO.BL301401Consolidation;
using Evaluation.UI.DTO.Consolidation;
using Evaluation.UI.DTO.Global;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models.Consolidation
{
    public class Consolidation301401VM
    {
        public List<PolicyBL301401Dto> Policy { get; set; }
        public SalesTransactionBL301401Dto SalesTransactionBL301401 { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int SalesTransactionId { get; set; }
        public string BusinessLineCode { get; set; }
        public List<PaymentScheduleBL301401Dto> PaymentSchedule { get; set; }
        public AF1BL301401Dto AF1BL301401Dtco { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL301401Dto> AF1BL301401List { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<PolicyRelatedDocBL301401Dto> PolicyRelatedDoc { get; set; }
        public List<NetworkLevelDto> NetworkLevel { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<ClientDto> Clients { get; set; }
        public List<MasterDto> Masters { get; set; }
    }
}
