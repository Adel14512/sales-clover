using Evaluation.CAL.DTO.BL301401;
using System.Collections.Generic;


namespace Evaluation.CAL.Response.BL301401
{
    public class SalesTransactionBL301401CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL301401Dto> CQFullListBL301401 { get; set; }
        public List<CQShortListBL301401Dto> CQShortListBL301401 { get; set; }
        public List<CQHeader301401Dto> CQHeaderBL301401 { get; set; }
    }
}
