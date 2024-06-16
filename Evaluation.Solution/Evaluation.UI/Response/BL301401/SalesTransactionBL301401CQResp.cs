using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL301401
{
    public class SalesTransactionBL301401CQResp :GenericWebResponse
    {
        //public List<CQDetailsBL301401Dto> CQDetailsBL301401 { get; set; }
        //public List<CQSummaryBL301401Dto> CQSummaryBL301401 { get; set; }
       
        //public List<dynamic> CQPivotBL301401 { get; set; }
        //public List<dynamic> CQBenefitBL301401 { get; set; }
        //public List<dynamic> CQBillsBL301401 { get; set; }
        //public List<CQHeader> CQHeaderBL301401 { get; set; }
        //public List<CQCategory> CQCategoryBL301401 { get; set; }
        public List<dynamic> CQPivotBL301401 { get; set; }
        public List<dynamic> CQBenefitBL301401 { get; set; }
        public List<dynamic> CQBenefitCompareBL301401 { get; set; }
        public List<dynamic> CQPivotMemberBL301401 { get; set; }
        public List<CQHeader301401Dto> CQHeaderBL301401 { get; set; }
        public List<CQCategory> CQCategoryBL301401 { get; set; }
    }
}
