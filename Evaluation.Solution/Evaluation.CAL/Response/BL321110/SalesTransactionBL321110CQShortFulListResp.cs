using Evaluation.CAL.DTO.BL321110;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL321110
{
    public class SalesTransactionBL321110CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL321110Dto> CQFullListBL321110 { get; set; }
        public List<CQShortListBL321110Dto> CQShortListBL321110 { get; set; }
        public List<CQHeader321110> CQHeaderBL321110 { get; set; }
    }
}
