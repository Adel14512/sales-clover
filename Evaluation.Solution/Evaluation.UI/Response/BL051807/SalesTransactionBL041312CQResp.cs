﻿
using Evaluation.UI.DTO.BL051807;

namespace Evaluation.UI.Response.BL051807
{
    public class SalesTransactionBL051807CQResp :GenericWebResponse
    {
        public List<CQDetailsBL051807Dto> CQDetailsBL051807 { get; set; }
        public List<CQSummaryBL051807Dto> CQSummaryBL051807 { get; set; }
        public List<dynamic> CQPivotBL051807 { get; set; }
        public List<dynamic> CQBenefitBL051807 { get; set; }
        public List<dynamic> CQBillsBL051807 { get; set; }
        public List<CQHeader051807Dto> CQHeaderBL051807 { get; set; }
        public List<CQCategory051807Dto> CQCategoryBL051807 { get; set; }
    }
}