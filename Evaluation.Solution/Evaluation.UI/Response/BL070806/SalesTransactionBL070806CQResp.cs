
using Evaluation.UI.DTO.BL070806;

namespace Evaluation.UI.Response.BL070806
{
    public class SalesTransactionBL070806CQResp : GenericWebResponse
    {
        public List<CQDetailsBL070806Dto> CQDetailsBL070806 { get; set; }
        public List<CQSummaryBL070806Dto> CQSummaryBL070806 { get; set; }
        public List<dynamic> CQPivotBL070806 { get; set; }
        public List<dynamic> CQBenefitBL070806 { get; set; }
        public List<dynamic> CQBillsBL070806 { get; set; }
        public List<dynamic> CQBenefitComapreBL070806 { get; set; }
        public List<CQHeader070806Dto> CQHeaderBL070806 { get; set; }
        public List<CQCategory070806Dto> CQCategoryBL070806 { get; set; }

    }
}
