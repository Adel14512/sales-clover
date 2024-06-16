using Evaluation.CAL.DTO.BL281609;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL281609
{
    public class SalesTransactionBL281609CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL281609Dto> CQFullListBL281609 { get; set; }
        public List<CQShortListBL281609Dto> CQShortListBL281609 { get; set; }
        public List<CQHeader281609Dto> CQHeaderBL281609 { get; set; }
    }
}
