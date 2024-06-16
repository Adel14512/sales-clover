
using Evaluation.UI.DTO.BL010602;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL010602
{
    public class SalesTransactionBL010602CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL010602Dto> CQFullListBL010602 { get; set; }
        public List<CQShortListBL010602Dto> CQShortListBL010602 { get; set; }
        public List<CQHeader010602Dto> CQHeaderBL010602 { get; set; }
    }
}
