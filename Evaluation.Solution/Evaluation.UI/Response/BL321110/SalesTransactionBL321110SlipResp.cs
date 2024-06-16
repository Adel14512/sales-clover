
using Evaluation.UI.DTO.BL321110;

namespace Evaluation.UI.Response.BL321110
{
    public class SalesTransactionBL321110SlipResp:GenericWebResponse
    {
        public List<dynamic> AF1BL321110 { get; set; }
        public List<dynamic> Step2BL321110 { get; set; }
        public List<dynamic> Step3BL321110 { get; set; }
        public List<dynamic> Step4BL321110 { get; set; }
        public List<CQHeader321110> CQHeaderBL321110 { get; set; }
    }
}
