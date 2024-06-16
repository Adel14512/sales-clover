using Evaluation.UI.DTO.BL291908;

namespace Evaluation.UI.Models
{
    public class CQAf29VM
    {
        public List<CQDetailsBL291908Dto> CQDetailsBL291908 { get; set; }
        public List<CQSummaryBL291908Dto> CQSummaryBL291908 { get; set; }
        public List<dynamic> CQPivotBL291908 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL291908 { get; set; }
        public List<dynamic> CQBillsBL291908 { get; set; }
        public List<CQHeader291908Dto> CQHeader { get; set; }
        public List<CQCategory291908Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
