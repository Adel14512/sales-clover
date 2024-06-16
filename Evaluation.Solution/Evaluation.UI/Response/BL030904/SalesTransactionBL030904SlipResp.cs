
using Evaluation.UI.DTO.BL030904;

namespace Evaluation.UI.Response.BL030904
{
    public class SalesTransactionBL030904SlipResp : GenericWebResponse
    {
        public SalesTransactionBL030904Dto SalesTransactionBL030904 { get; set; }
        public List<CQHeader030904Dto> CQHeaderBL030904 { get; set; }
    }
}
