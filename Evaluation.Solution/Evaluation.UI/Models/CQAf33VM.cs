using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.DTO.BL331211;

namespace Evaluation.UI.Models
{
    public class CQAf33VM
    {
        public List<CQDetailsBL331211Dto> CQDetailsBL331211 { get; set; }
        public List<CQSummaryBL331211Dto> CQSummaryBL331211 { get; set; }
        public List<dynamic> CQPivotBL331211 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL331211 { get; set; }
        public List<dynamic> CQBillsBL331211 { get; set; }
        public List<CQHeader331211Dto> CQHeader { get; set; }
        public List<CQCategory331211Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
