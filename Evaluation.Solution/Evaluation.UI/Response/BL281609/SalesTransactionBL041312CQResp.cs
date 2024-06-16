
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL281609
{
    public class SalesTransactionBL281609CQResp : GenericWebResponse
    {
        public List<CQDetailsBL281609Dto> CQDetailsBL281609 { get; set; }
        public List<CQSummaryBL281609Dto> CQSummaryBL281609 { get; set; }
        public List<dynamic> CQPivotBL281609 { get; set; }
        public List<dynamic> CQBenefitBL281609 { get; set; }
        public List<dynamic> CQBillsBL281609 { get; set; }
        public List<CQHeader281609Dto> CQHeaderBL281609 { get; set; }
        public List<CQCategory281609Dto> CQCategoryBL281609 { get; set; }
        public List<dynamic> CQBenefitComapreBL281609 { get; set; }
    }
}
