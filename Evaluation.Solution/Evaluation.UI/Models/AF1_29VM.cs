using Evaluation.UI.DTO;
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.DTO.BL051807;
using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class AF1_29VM
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public List<AF1BL291908Dto> AF1BL291908 { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public List<RelationDto> Relations { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<StayTripOptionDto> StayTripOption { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public ContactVM ContactVM { get; set; }   
    }
}
