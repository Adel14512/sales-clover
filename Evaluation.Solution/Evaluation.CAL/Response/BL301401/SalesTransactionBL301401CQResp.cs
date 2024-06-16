using Evaluation.CAL.DTO.BL301401;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL301401
{
    public class SalesTransactionBL301401CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        //public List<CQDetailsBL301401Dto> CQDetailsBL301401 { get; set; }
        //public List<CQSummaryBL301401Dto> CQSummaryBL301401 { get; set; }
        public List<dynamic> CQPivotBL301401 { get; set; }
        public List<dynamic> CQBenefitBL301401 { get; set; }
        public List<dynamic> CQBenefitCompareBL301401 { get; set; }
        public List<dynamic> CQPivotMemberBL301401 { get; set; }
        //public List<dynamic> CQBillsBL301401 { get; set; }
        public List<CQHeader301401Dto> CQHeaderBL301401 { get; set; }
        public List<CQCategory> CQCategoryBL301401 { get; set; }
    }
}
