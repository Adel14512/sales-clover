using Evaluation.CAL.DTO.BL080501;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL080501
{
    public class SalesTransactionBL080501CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQDetailsBL080501Dto> CQDetailsBL080501 { get; set; }
        public List<CQSummaryBL080501Dto> CQSummaryBL080501 { get; set; }
        public List<dynamic> CQPivotBL080501 { get; set; }
        public List<dynamic> CQBenefitBL080501 { get; set; }
        public List<dynamic> CQBillsBL080501 { get; set; }
        public List<CQHeader080501> CQHeaderBL080501 { get; set; }
        public List<CQCategory080501> CQCategoryBL080501 { get; set; }
        public List<dynamic> CQBenefitComapreBL080501 { get; set; }
    }
}
