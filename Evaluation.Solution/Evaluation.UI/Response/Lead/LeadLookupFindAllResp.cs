
using Evaluation.UI.DTO;
using Evaluation.UI.Models;


namespace Evaluation.UI.Response
{
    public class LeadLookupFindAllResp : GenericWebResponse
    {
        public List<LeadSaleDto> LeadSale { get; set; }
        public List<LeadSourceDto> LeadSource { get; set; }
        public List<LeadStatusDto> LeadStatus { get; set; }
        public List<RegionDto> Region { get; set; }
    }
}
