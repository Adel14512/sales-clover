using Evaluation.CAL.DTO.BL321110;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL321110
{
    public class SalesTransactionBL321110CQResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        //public List<CQDetailsBL321110Dto> CQDetailsBL321110 { get; set; }
        //public List<CQSummaryBL321110Dto> CQSummaryBL321110 { get; set; }
        public List<dynamic> CQPivotSummaryBL321110 { get; set; }
        public List<dynamic> CQPivotSectionBL321110 { get; set; }
        public List<dynamic> CQPivotMemberBL321110 { get; set; }
        public List<CQHeader321110> CQHeaderBL321110 { get; set; }
        public List<dynamic> CQPivotBenefitBL321110 { get; set; }
        public List<dynamic> CQPivotPricesListBL321110 { get; set; }
        //public List<CQCategory321110> CQCategoryBL321110 { get; set; }
    }
}
