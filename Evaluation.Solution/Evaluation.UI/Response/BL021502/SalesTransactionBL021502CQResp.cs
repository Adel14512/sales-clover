
using Evaluation.UI.DTO.BL021502;
namespace Evaluation.UI.Response.BL021502
{
    public class SalesTransactionBL021502CQResp : GenericWebResponse
    {
        //public List<CQDetailsBL021502Dto> CQDetailsBL021502 { get; set; }
        //public List<CQSummaryBL021502Dto> CQSummaryBL021502 { get; set; }
        //public List<dynamic> CQPivotBL021502 { get; set; }
        //public List<dynamic> CQBenefitBL021502 { get; set; }
        //public List<dynamic> CQBillsBL021502 { get; set; }
        //public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
        //public List<CQCategory021502Dto> CQCategoryBL021502 { get; set; }
        public List<dynamic> CQPivotBL021502 { get; set; }
        public List<dynamic> CQBenefitBL021502 { get; set; }
        public List<dynamic> CQBillsBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
    }
}
