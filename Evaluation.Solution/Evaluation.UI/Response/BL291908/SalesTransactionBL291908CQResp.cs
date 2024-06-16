
using Evaluation.UI.DTO.BL291908;

namespace Evaluation.UI.Response.BL291908
{
    public class SalesTransactionBL291908CQResp : GenericWebResponse
    {
        public List<CQDetailsBL291908Dto> CQDetailsBL291908 { get; set; }
        public List<CQSummaryBL291908Dto> CQSummaryBL291908 { get; set; }
        public List<dynamic> CQPivotBL291908 { get; set; }
        public List<dynamic> CQBenefitBL291908 { get; set; }
        public List<dynamic> CQBillsBL291908 { get; set; }
        public List<CQHeader291908Dto> CQHeaderBL291908 { get; set; }
        public List<CQCategory291908Dto> CQCategoryBL291908 { get; set; }
    }
}
