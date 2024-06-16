
using Evaluation.UI.DTO;

namespace Evaluation.UI.Models.Lead
{
    public class LeadVM
    {
        public LeadVM() {
            LeadStatuses = new List<LeadStatusDto>();
            LeadSources = new List<LeadSourceDto>();
            LeadSales = new List<LeadSaleDto>();
            Regions = new List<RegionDto>();
        }
        public int? RecId { get; set; }
        public int? LeadStatusId { get; set; }
        public int? CountryId { get; set; }
        public string? Owner { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? EMail { get; set; }
        public string? Job { get; set; }
        public string? Company { get; set; }
        public string? Topic { get; set; }
        public string BusinessLine { get; set; }
        public int? LeadSourceId { get; set; }
        public int? LeadSaleId { get; set; }
        public string? SummaryFeedback { get; set; }
        public DateTime? NextActionDate { get; set; }
        public bool? IsActive { get; set; }
        public List<LeadSaleDto> LeadSales { get; set; }
        public List<LeadSourceDto> LeadSources{ get; set; }
        public List<LeadStatusDto> LeadStatuses{ get; set; }
        public List<RegionDto> Regions { get; set; }
    }
}
