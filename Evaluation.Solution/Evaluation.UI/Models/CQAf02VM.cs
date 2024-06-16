using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL021502;

namespace Evaluation.UI.Models
{
    public class CQAf02VM
    {
        public List<CQDetailsBL021502Dto> CQDetailsBL021502 { get; set; }
        public List<CQSummaryBL021502Dto> CQSummaryBL021502 { get; set; }
        public List<dynamic> CQPivotBL021502 { get; set; }
        public List<IDictionary<string, string>> CQPivotList { get; set; }
        public List<IDictionary<string, string>> CQBenefitList { get; set; }
        public List<IDictionary<string, string>> CQBillsList { get; set; }
        public List<dynamic> CQBenefitBL021502 { get; set; }
        public List<dynamic> CQBillsBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeader { get; set; }
        public List<CQCategory021502Dto> CQCategory { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
