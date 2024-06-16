using Evaluation.CAL.DTO.BL080501;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL080501
{
    public class SalesTransactionBL080501CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL080501Dto> CQFullListBL080501 { get; set; }
        public List<CQShortListBL080501Dto> CQShortListBL080501 { get; set; }
        public List<CQHeader080501> CQHeaderBL080501 { get; set; }
    }
}
