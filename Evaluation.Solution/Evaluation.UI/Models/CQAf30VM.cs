using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL301401;

namespace Evaluation.UI.Models
{
    public class CQAf30VM
    {
        public List<CQDetailsBL301401Dto> CQDetailsBL301401 { get; set; }
        public List<CQSummaryBL301401Dto> CQSummaryBL301401 { get; set; }
        public List<dynamic> CQPivotBL301401 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL301401 { get; set; }
        public List<dynamic> CQBillsBL301401 { get; set; }
        public List<CQHeader> CQHeader { get; set; }
        public List<CQCategory> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
