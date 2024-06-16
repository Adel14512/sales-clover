using Evaluation.UI.DTO.BL311703;

namespace Evaluation.UI.Response.BL311703
{
    public class SalesTransactionBL311703CQResp :GenericWebResponse
    {
        public List<CQDetailsBL311703Dto> CQDetailsBL311703 { get; set; }
        public List<CQSummaryBL311703Dto> CQSummaryBL311703 { get; set; }
        public List<dynamic> CQPivotBL311703 { get; set; }
        public List<dynamic> CQBenefitBL311703 { get; set; }
        public List<dynamic> CQBillsBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeaderBL311703 { get; set; }
        public List<CQCategory311703Dto> CQCategoryBL311703 { get; set; }
    }
}
