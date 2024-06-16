using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models
{
    public class AF1_30VM
    {
        public SalesTransactionBL301401Dto SalesTransactionBL301401Dto { get; set; }
        public List<AF1BL301401Dto> AF130s { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<NetworkLevelDto> NetworkLevel { get; set; }

    }
}
