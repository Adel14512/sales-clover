using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.Response;
using Evaluation.UI.DTO;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed041312VM
    {
        public int SalesTransactionId { get; set; }
        public string BusinessLineCode { get; set; }
        public string PageType { get; set; }
        public SalesTransactionBL041312Dto SalesTransactionBL041312Dto { get; set; }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312Details { get; set; }
        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPrices { get; set; }
        public List<AF1BL041312Dto> AF130s { get; set; }
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
