using Evaluation.CAL.DTO.BL090703;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL090703
{
    public class SalesTransactionBL090703CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL090703Dto> CQFullListBL090703 { get; set; }
        public List<CQShortListBL090703Dto> CQShortListBL090703 { get; set; }
        public List<CQHeader090703Dto> CQHeaderBL090703 { get; set; }
    }
}
