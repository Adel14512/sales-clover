
using Evaluation.UI.DTO.BL090703;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL090703
{
    public class SalesTransactionBL090703SlipResp : GenericWebResponse
    {
        public SalesTransactionBL090703Dto SalesTransactionBL090703 { get; set; }
        public List<CQHeader090703Dto> CQHeaderBL090703 { get; set; }
    }
}
