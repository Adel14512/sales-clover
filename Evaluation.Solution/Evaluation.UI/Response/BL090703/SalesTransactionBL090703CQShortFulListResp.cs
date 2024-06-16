
using Evaluation.UI.DTO.BL090703;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL090703
{
    public class SalesTransactionBL090703CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL090703Dto> CQFullListBL090703 { get; set; }
        public List<CQShortListBL090703Dto> CQShortListBL090703 { get; set; }
        public List<CQHeader090703Dto> CQHeaderBL090703 { get; set; }
    }
}
