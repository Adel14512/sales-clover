using Evaluation.CAL.DTO.BL331211;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL331211
{
    public class SalesTransactionBL331211CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        //public List<CQDetailsBL321110Dto> CQDetailsBL321110 { get; set; }
        //public List<CQSummaryBL321110Dto> CQSummaryBL321110 { get; set; }
        public List<dynamic> CQPivotSummaryBL331211 { get; set; }
        public List<dynamic> CQPivotSectionBL331211 { get; set; }
        public List<dynamic> CQPivotMemberBL331211 { get; set; }
        public List<CQHeader331211Dto> CQHeaderBL331211 { get; set; }
        public List<dynamic> CQPivotBenefitBL331211 { get; set; }
        public List<dynamic> CQPivotPricesListBL331211 { get; set; }
        //public List<CQCategory321110> CQCategoryBL321110 { get; set; }
    }
}
