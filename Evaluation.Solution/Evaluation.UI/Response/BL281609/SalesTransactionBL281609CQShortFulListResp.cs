
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL281609
{
    public class SalesTransactionBL281609CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL281609Dto> CQFullListBL281609 { get; set; }
        public List<CQShortListBL281609Dto> CQShortListBL281609 { get; set; }
        public List<CQHeader281609Dto> CQHeaderBL281609 { get; set; }
    }
}
