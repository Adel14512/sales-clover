using Evaluation.CAL.DTO.BL321110;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL321110
{
    public class SalesTransactionBL321110SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<dynamic> AF1BL321110 { get; set; }
        public List<dynamic> Step2BL321110 { get; set; }
        public List<dynamic> Step3BL321110 { get; set; }
        public List<dynamic> Step4BL321110 { get; set; }
        public List<CQHeader321110> CQHeaderBL321110 { get; set; }
    }
}
