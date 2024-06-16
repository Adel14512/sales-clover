using Evaluation.CAL.DTO.BL090703;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL090703
{
    public class SalesTransactionBL090703CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        //public List<CQDetailsBL090703Dto> CQDetailsBL090703 { get; set; }
        //public List<CQSummaryBL090703Dto> CQSummaryBL090703 { get; set; }
        public List<dynamic> CQPivotBL090703 { get; set; }
        public List<dynamic> CQBenefitBL090703 { get; set; }
        public List<dynamic> CQBillsBL090703 { get; set; }
        public List<CQHeader090703Dto> CQHeaderBL090703 { get; set; }
        //public List<CQCategory090703Dto> CQCategoryBL090703 { get; set; }
        public List<dynamic> CQBenefitComapreBL090703 { get; set; }
    }
}
