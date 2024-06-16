
using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL080501
{
    public class SalesTransactionBL080501SlipResp:GenericWebResponse
    {
        public SalesTransactionBL080501Dto SalesTransactionBL080501 { get; set; }
        public List<CQHeader080501> CQHeaderBL080501 { get; set; }
    }
}
