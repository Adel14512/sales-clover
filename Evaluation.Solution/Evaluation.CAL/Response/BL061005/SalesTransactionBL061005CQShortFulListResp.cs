using Evaluation.CAL.DTO.BL051807;
using Evaluation.CAL.DTO.BL061005;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL061005
{
    public class SalesTransactionBL061005CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL061005Dto> CQFullListBL061005 { get; set; }
        public List<CQShortListBL061005Dto> CQShortListBL061005 { get; set; }
        public List<CQHeader061005Dto> CQHeaderBL061005 { get; set; }
    }
}
