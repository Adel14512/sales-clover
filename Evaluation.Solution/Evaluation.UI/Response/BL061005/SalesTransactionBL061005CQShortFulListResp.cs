
using Evaluation.UI.DTO.BL061005;

namespace Evaluation.UI.Response.BL061005
{
    public class SalesTransactionBL061005CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL061005Dto> CQFullListBL061005 { get; set; }
        public List<CQShortListBL061005Dto> CQShortListBL061005 { get; set; }
        public List<CQHeader061005Dto> CQHeaderBL061005 { get; set; }
    }
}
