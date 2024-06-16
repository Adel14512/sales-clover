using Evaluation.UI.DTO.BL080501;

namespace Evaluation.UI.Models
{
    public class CQAf8VM
    {
        public List<CQDetailsBL080501Dto> CQDetailsBL080501 { get; set; }
        public List<CQSummaryBL080501Dto> CQSummaryBL080501 { get; set; }
        public List<dynamic> CQPivotBL080501 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<IDictionary<string, string>> CQCompareList { get; set; }
        public List<dynamic> CQBenefitBL080501 { get; set; }
        public List<dynamic> CQBillsBL080501 { get; set; }
        public List<dynamic> CQBenefitComapreBL080501 { get; set; }
        public List<CQHeader080501> CQHeader { get; set; }
        public List<CQCategory080501> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
