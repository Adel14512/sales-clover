using Evaluation.UI.DTO.BL061005;

namespace Evaluation.UI.Response.BL061005
{
    public class SalesTransactionBL061005CQResp : GenericWebResponse
    {
        public List<CQDetailsBL061005Dto> CQDetailsBL061005 { get; set; }
        public List<CQSummaryBL061005Dto> CQSummaryBL061005 { get; set; }
        public List<dynamic> CQPivotBL061005 { get; set; }
        public List<dynamic> CQBenefitBL061005 { get; set; }
        public List<dynamic> CQBillsBL061005 { get; set; }
        public List<CQHeader061005Dto> CQHeaderBL061005 { get; set; }
        public List<CQCategory061005Dto> CQCategoryBL061005 { get; set; }
    }
}
