using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class LeadLookupFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<LeadSaleDto> LeadSale { get; set; }
        public List<LeadSourceDto> LeadSource { get; set; }
        public List<LeadStatusDto> LeadStatus { get; set; }
        public List<RegionDto> Region { get; set; }
    }
}
