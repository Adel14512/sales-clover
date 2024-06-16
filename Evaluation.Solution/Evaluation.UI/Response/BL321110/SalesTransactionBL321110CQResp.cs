using Evaluation.UI.DTO.BL321110;

namespace Evaluation.UI.Response.BL321110
{
    public class SalesTransactionBL321110CQResp:GenericWebResponse
    {
        //public List<CQDetailsBL321110Dto> CQDetailsBL321110 { get; set; }
        //public List<CQSummaryBL321110Dto> CQSummaryBL321110 { get; set; }
     
        //public List<dynamic> CQPivotBL321110 { get; set; }
        //public List<dynamic> CQBenefitBL321110 { get; set; }
        //public List<dynamic> CQBillsBL321110 { get; set; }
        //public List<CQHeader321110> CQHeaderBL321110 { get; set; }
        //public List<CQCategory321110> CQCategoryBL321110 { get; set; }
        public List<dynamic> CQPivotSummaryBL321110 { get; set; }
        public List<dynamic> CQPivotSectionBL321110 { get; set; }
        public List<dynamic> CQPivotMemberBL321110 { get; set; }
        public List<CQHeader321110> CQHeaderBL321110 { get; set; }
        public List<dynamic> CQPivotBenefitBL321110 { get; set; }
        public List<dynamic> CQPivotPricesListBL321110 { get; set; }
    }
}
