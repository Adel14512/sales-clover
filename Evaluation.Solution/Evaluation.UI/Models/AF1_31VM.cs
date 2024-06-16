using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.DTO.BL311703;
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models
{
    public class AF1_31VM
    {
        public SalesTransactionBL311703Dto SalesTransactionBL311703 { get; set; }
        public List<AF1BL311703Dto> AF130s { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
    }
}
