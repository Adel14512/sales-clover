using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_4VM
    {

        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public SalesTransactionBL041312Dto SalesTransactionBL041312 { get; set; }


        public List<AF1BL041312Dto> AF1BL041312 { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<StayTripOptionDto> StayTripOption { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public ContactVM ContactVM { get; set; }
        public SalesTransactionBL041312Dto SalesTransactionBL041312Dto { get; set; }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312Details { get; set; }
        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPrices { get; set; }
        public List<AF1BL041312Dto> AF133s { get; set; }

        public List<ProductDetailsPOINetwork> ProductDetailsPOINetwork { get; set; }
        public List<NetworkLevelDto> Networks { get; set; }
        public List<TerritorialScope> Territorias { get; set; }
        public List<InsurerDto> Insurer { get; set; }
    }
}
