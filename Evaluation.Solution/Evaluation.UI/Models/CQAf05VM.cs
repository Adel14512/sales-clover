using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL051807;

namespace Evaluation.UI.Models
{
    public class CQAf05VM
    {
        public List<CQDetailsBL051807Dto> CQDetailsBL051807 { get; set; }
        public List<CQSummaryBL051807Dto> CQSummaryBL051807 { get; set; }
        public List<dynamic> CQPivotBL051807 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL051807 { get; set; }
        public List<dynamic> CQBillsBL051807 { get; set; }
        public List<CQHeader051807Dto> CQHeader { get; set; }
        public List<CQCategory051807Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
