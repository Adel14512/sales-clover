using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL070806;

namespace Evaluation.UI.Models
{
    public class CQAf07VM
    {
        public List<CQDetailsBL070806Dto> CQDetailsBL070806 { get; set; }
        public List<CQSummaryBL070806Dto> CQSummaryBL070806 { get; set; }
        public List<dynamic> CQPivotBL070806 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL070806 { get; set; }
        public List<dynamic> CQBillsBL070806 { get; set; }
        public List<CQHeader070806Dto> CQHeader { get; set; }
        public List<CQCategory070806Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
        public List<IDictionary<string, string>> CQCompareList { get; set; }
     
        public List<dynamic> CQBenefitComapreBL080501 { get; set; }
    }
}
