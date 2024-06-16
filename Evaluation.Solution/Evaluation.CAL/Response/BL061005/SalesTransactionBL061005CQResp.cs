using Evaluation.CAL.DTO.BL061005;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL061005
{
    public class SalesTransactionBL061005CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQDetailsBL061005Dto> CQDetailsBL061005 { get; set; }
        public List<CQSummaryBL061005Dto> CQSummaryBL061005 { get; set; }
        public List<dynamic> CQPivotBL061005 { get; set; }
        public List<dynamic> CQBenefitBL061005 { get; set; }
        public List<dynamic> CQBillsBL061005 { get; set; }
        public List<CQHeader061005Dto> CQHeaderBL061005 { get; set; }
        public List<CQCategory061005Dto> CQCategoryBL061005 { get; set; }
    }
}
