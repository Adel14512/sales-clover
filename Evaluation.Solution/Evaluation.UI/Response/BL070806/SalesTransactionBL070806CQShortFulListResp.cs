
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL070806
{
    public class SalesTransactionBL070806CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL070806Dto> CQFullListBL070806 { get; set; }
        public List<CQShortListBL070806Dto> CQShortListBL070806 { get; set; }
        public List<CQHeader070806Dto> CQHeaderBL070806 { get; set; }
    }
}
