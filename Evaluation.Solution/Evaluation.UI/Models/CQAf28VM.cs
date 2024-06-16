using Evaluation.UI.DTO.BL281609;

namespace Evaluation.UI.Models
{
    public class CQAf28VM
    {
        public List<CQDetailsBL281609Dto> CQDetailsBL281609 { get; set; }
        public List<CQSummaryBL281609Dto> CQSummaryBL281609 { get; set; }
        public List<dynamic> CQPivotBL281609 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<IDictionary<string, string>> CQBenefitCompareList { get; set; }
        public List<dynamic> CQBenefitBL281609 { get; set; }
        public List<dynamic> CQBillsBL281609 { get; set; }
        public List<CQHeader281609Dto> CQHeader { get; set; }
        public List<CQCategory281609Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
