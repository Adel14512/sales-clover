
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL041312
{
    public class SalesTransactionBL041312CQResp : GenericWebResponse
    {
        //public List<CQDetailsBL321110Dto> CQDetailsBL321110 { get; set; }
        //public List<CQSummaryBL321110Dto> CQSummaryBL321110 { get; set; }
        public List<dynamic> CQPivotSummaryBL041312 { get; set; }
        public List<dynamic> CQPivotSectionBL041312 { get; set; }
        public List<dynamic> CQPivotMemberBL041312 { get; set; }
        public List<CQHeader041312Dto> CQHeaderBL041312 { get; set; }
        public List<dynamic> CQPivotBenefitBL041312 { get; set; }
        public List<dynamic> CQPivotPricesListBL041312 { get; set; }
        //public List<CQCategory321110> CQCategoryBL321110 { get; set; }
    }
}
