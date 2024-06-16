using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed331211VM
    {
        public int SalesTransactionId { get; set; }
        public string BusinessLineCode { get; set; }
        public string PageType { get; set; }
        public SalesTransactionBL331211Dto SalesTransactionBL331211Dto { get; set; }
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211Details { get; set; }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPrices { get; set; }
        public List<AF1BL331211Dto> AF130s { get; set; }
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
