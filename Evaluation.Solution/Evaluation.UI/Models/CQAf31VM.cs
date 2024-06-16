using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.DTO.BL311703;

namespace Evaluation.UI.Models
{
    public class CQAf31VM
    {
        public List<CQDetailsBL311703Dto> CQDetailsBL311703 { get; set; }
        public List<CQSummaryBL311703Dto> CQSummaryBL311703 { get; set; }
        public List<dynamic> CQPivotBL311703 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL311703 { get; set; }
        public List<dynamic> CQBillsBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeader { get; set; }
        public List<CQCategory311703Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
