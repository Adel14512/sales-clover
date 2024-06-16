
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL041312
{
    public class SalesTransactionBL041312SlipResp : GenericWebResponse
    {
        public SalesTransactionBL041312Dto SalesTransactionBL041312 { get; set; }
        public List<dynamic> AF1BL041312 { get; set; }
        public List<dynamic> Step2BL041312 { get; set; }
        public List<dynamic> Step3BL041312 { get; set; }
        public List<dynamic> Step4BL041312 { get; set; }
        public List<CQHeader041312Dto> CQHeaderBL041312 { get; set; }
    }
}
