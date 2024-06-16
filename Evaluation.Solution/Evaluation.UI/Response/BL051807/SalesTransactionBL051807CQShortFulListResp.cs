
using Evaluation.UI.DTO.BL051807;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL051807
{
    public class SalesTransactionBL051807CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL051807Dto> CQFullListBL051807 { get; set; }
        public List<CQShortListBL051807Dto> CQShortListBL051807 { get; set; }
        public List<CQHeader051807Dto> CQHeaderBL051807 { get; set; }
    }
}
