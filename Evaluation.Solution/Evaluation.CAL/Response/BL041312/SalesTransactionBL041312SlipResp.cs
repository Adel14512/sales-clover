using Evaluation.CAL.DTO.BL041312;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL041312
{
    public class SalesTransactionBL041312SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<dynamic> AF1BL041312 { get; set; }
        public List<dynamic> Step2BL041312 { get; set; }
        public List<dynamic> Step3BL041312 { get; set; }
        public List<dynamic> Step4BL041312 { get; set; }
        public List<CQHeader041312Dto> CQHeaderBL041312 { get; set; }
    }
}
