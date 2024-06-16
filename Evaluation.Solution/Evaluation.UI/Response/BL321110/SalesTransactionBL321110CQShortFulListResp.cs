
using Evaluation.UI.DTO.BL321110;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL321110
{
    public class SalesTransactionBL321110CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL321110Dto> CQFullListBL321110 { get; set; }
        public List<CQShortListBL321110Dto> CQShortListBL321110 { get; set; }
        public List<CQHeader321110> CQHeaderBL321110 { get; set; }
    }
}
