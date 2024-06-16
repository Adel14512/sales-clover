using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL321110;

namespace Evaluation.UI.Models
{
    public class CQAf32VM
    {
        public List<CQDetailsBL321110Dto> CQDetailsBL321110 { get; set; }
        public List<CQSummaryBL321110Dto> CQSummaryBL321110 { get; set; }
        public List<dynamic> CQPivotBL321110 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL321110 { get; set; }
        public List<dynamic> CQBillsBL321110 { get; set; }
        public List<CQHeader321110> CQHeader { get; set; }
        public List<CQCategory321110> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
