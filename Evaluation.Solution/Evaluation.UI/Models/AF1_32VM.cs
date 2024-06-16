using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.Response;
using Evaluation.UI.Response.BL321110;

namespace Evaluation.UI.Models
{
    public class AF1_32VM
    {
        public SalesTransactionBL321110Dto SalesTransactionBL321110Dto { get; set; }
        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110Details { get; set; }
        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPrices { get; set; }
        public List<AF1BL321110Dto> AF130s { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<ProductDetailsPOINetwork> ProductDetailsPOINetwork { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<NetworkLevelDto> Networks { get; set; }
        public List<TerritorialScope> Territorias { get; set; }
        public List<ThirdPartyAdminDto> ThirdPartyAdmin { get; set; }
        public List<InsurerDto> Insurer { get; set; }
    }
}
