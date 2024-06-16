using Evaluation.CAL.DTO.BL051807;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL051807
{
    public class SalesTransactionBL051807CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL051807Dto> CQFullListBL051807 { get; set; }
        public List<CQShortListBL051807Dto> CQShortListBL051807 { get; set; }
        public List<CQHeader051807Dto> CQHeaderBL051807 { get; set; }
    }
}
