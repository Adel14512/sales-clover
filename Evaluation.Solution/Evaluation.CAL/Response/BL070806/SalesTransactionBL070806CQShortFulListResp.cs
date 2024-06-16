using Evaluation.CAL.DTO.BL070806;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL070806
{
    public class SalesTransactionBL070806CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL070806Dto> CQFullListBL070806 { get; set; }
        public List<CQShortListBL070806Dto> CQShortListBL070806 { get; set; }
        public List<CQHeader070806Dto> CQHeaderBL070806 { get; set; }
    }
}
