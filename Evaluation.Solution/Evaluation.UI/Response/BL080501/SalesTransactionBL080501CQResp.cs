using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL080501
{
    public class SalesTransactionBL080501CQResp :GenericWebResponse
    {
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
