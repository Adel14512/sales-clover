using Evaluation.CAL.DTO.BL291908;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL291908
{
    public class SalesTransactionBL291908CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL291908Dto> CQFullListBL291908 { get; set; }
        public List<CQShortListBL291908Dto> CQShortListBL291908 { get; set; }
        public List<CQHeader291908Dto> CQHeaderBL291908 { get; set; }
    }
}
