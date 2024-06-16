using Evaluation.CAL.DTO.BL041312;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL041312
{
    public class SalesTransactionBL041312CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL041312Dto> CQFullListBL041312 { get; set; }
        public List<CQShortListBL041312Dto> CQShortListBL041312 { get; set; }
        public List<CQHeader041312Dto> CQHeaderBL041312 { get; set; }
    }
}
