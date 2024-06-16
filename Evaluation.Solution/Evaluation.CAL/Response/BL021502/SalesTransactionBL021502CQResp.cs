using Evaluation.CAL.DTO.BL021502;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL021502
{
    public class SalesTransactionBL021502CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        //public List<CQDetailsBL021502Dto> CQDetailsBL021502 { get; set; }
        //public List<CQSummaryBL021502Dto> CQSummaryBL021502 { get; set; }
        public List<dynamic> CQPivotBL021502 { get; set; }
        public List<dynamic> CQBenefitBL021502 { get; set; }
        public List<dynamic> CQBillsBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
       // public List<CQCategory021502Dto> CQCategoryBL021502 { get; set; }
    }
}
