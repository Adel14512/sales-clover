
using Evaluation.UI.DTO.BL010602;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL010602
{
    public class SalesTransactionBL010602CQResp : GenericWebResponse
    {
        public List<CQDetailsBL010602Dto> CQDetailsBL010602 { get; set; }
        public List<CQSummaryBL010602Dto> CQSummaryBL010602 { get; set; }
        public List<dynamic> CQPivotBL010602 { get; set; }
        public List<dynamic> CQBenefitBL010602 { get; set; }
        public List<dynamic> CQBillsBL010602 { get; set; }
        public List<CQHeader010602Dto> CQHeaderBL010602 { get; set; }
        public List<CQCategory010602Dto> CQCategoryBL010602 { get; set; }
    }
}
