using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL041312;

namespace Evaluation.UI.Models
{
    public class CQAf4VM
    {
        public List<CQDetailsBL041312Dto> CQDetailsBL041312 { get; set; }
        public List<CQSummaryBL041312Dto> CQSummaryBL041312 { get; set; }
        public List<dynamic> CQPivotBL041312 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL041312 { get; set; }
        public List<dynamic> CQBillsBL041312 { get; set; }
        public List<CQHeader041312Dto> CQHeader { get; set; }
        public List<CQCategory041312Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
