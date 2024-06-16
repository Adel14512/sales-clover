
using Evaluation.UI.DTO.BL311703;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL311703
{
    public class SalesTransactionBL311703CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL311703Dto> CQFullListBL311703 { get; set; }
        public List<CQShortListBL311703Dto> CQShortListBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeaderBL311703 { get; set; }
    }
}
