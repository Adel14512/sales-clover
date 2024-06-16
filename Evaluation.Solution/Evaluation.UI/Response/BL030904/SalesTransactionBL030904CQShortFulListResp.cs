
using Evaluation.UI.DTO.BL030904;

namespace Evaluation.UI.Response.BL030904
{
    public class SalesTransactionBL030904CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL030904Dto> CQFullListBL030904 { get; set; }
        public List<CQShortListBL030904Dto> CQShortListBL030904 { get; set; }
        public List<CQHeader030904Dto> CQHeaderBL030904 { get; set; }
    }
}
