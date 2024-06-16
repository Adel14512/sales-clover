
using Evaluation.UI.DTO.BL311703;

namespace Evaluation.UI.Response.BL311703
{
    public class SalesTransactionBL311703SlipResp:GenericWebResponse
    {
        public SalesTransactionBL311703Dto SalesTransactionBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeaderBL311703 { get; set; }
    }
}
