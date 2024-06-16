using Evaluation.CAL.DTO.BL311703;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL311703
{
    public class SalesTransactionBL311703CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQDetailsBL311703Dto> CQDetailsBL311703 { get; set; }
        public List<CQSummaryBL311703Dto> CQSummaryBL311703 { get; set; }
        public List<dynamic> CQPivotBL311703 { get; set; }
        public List<dynamic> CQBenefitBL311703 { get; set; }
        public List<dynamic> CQBillsBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeaderBL311703 { get; set; }
        public List<CQCategory311703Dto> CQCategoryBL311703 { get; set; }
    }
}
