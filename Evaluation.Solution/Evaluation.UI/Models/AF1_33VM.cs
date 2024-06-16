using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Response;

namespace Evaluation.UI.Models
{
    public class AF1_33VM
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public SalesTransactionBL331211Dto SalesTransactionBL331211 { get; set; }


        public List<AF1BL331211Dto> AF1BL331211 { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<StayTripOptionDto> StayTripOption { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public ContactVM ContactVM { get; set; }
        public SalesTransactionBL331211Dto SalesTransactionBL331211Dto { get; set; }
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211Details { get; set; }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPrices { get; set; }
        public List<AF1BL331211Dto> AF133s { get; set; }
    
        public List<ProductDetailsPOINetwork> ProductDetailsPOINetwork { get; set; }
        public List<NetworkLevelDto> Networks { get; set; }
        public List<TerritorialScope> Territorias { get; set; }
        public List<InsurerDto> Insurer { get; set; }
    }
}
