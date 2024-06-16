using Evaluation.CAL.DTO.BL010602;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL010602
{
    public class SalesTransactionBL010602CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL010602Dto> CQFullListBL010602 { get; set; }
        public List<CQShortListBL010602Dto> CQShortListBL010602 { get; set; }
        public List<CQHeader010602Dto> CQHeaderBL010602 { get; set; }
    }
}
