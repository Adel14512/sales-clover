using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL021502;
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models
{
    public class AF1_2VM
    {
        public SalesTransactionBL021502Dto SalesTransactionBL021502Dto { get; set; }
        public List<AF1BL021502Dto> AF130s { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<StayTripOptionDto> StayTripOptions { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
    }
}
