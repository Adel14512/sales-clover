using Evaluation.CAL.DTO.BL021502;

using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL021502
{
    public class SalesTransactionBL021502CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL021502Dto> CQFullListBL021502 { get; set; }
        public List<CQShortListBL021502Dto> CQShortListBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
    }
}
