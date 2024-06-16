using Evaluation.UI.DTO.BL331211;

namespace Evaluation.UI.Response.BL331211
{
    public class SalesTransactionBL331211CQResp : GenericWebResponse
    {
        public List<dynamic> CQPivotSummaryBL331211 { get; set; }
        public List<dynamic> CQPivotSectionBL331211 { get; set; }
        public List<dynamic> CQPivotMemberBL331211 { get; set; }
        public List<CQHeader331211Dto> CQHeaderBL331211 { get; set; }
        public List<dynamic> CQPivotBenefitBL331211 { get; set; }
        public List<dynamic> CQPivotPricesListBL331211 { get; set; }
    }
}
