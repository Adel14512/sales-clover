using Evaluation.CAL.DTO.BL331211;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL331211
{
    public class SalesTransactionBL331211SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<dynamic> AF1BL331211 { get; set; }
        public List<dynamic> Step2BL331211 { get; set; }
        public List<dynamic> Step3BL331211 { get; set; }
        public List<dynamic> Step4BL331211 { get; set; }
        public List<CQHeader331211Dto> CQHeaderBL331211 { get; set; }
    }
}
