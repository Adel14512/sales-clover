using Evaluation.UI.DTO.BL331211;

namespace Evaluation.UI.Response.BL331211
{
    public class SalesTransactionBL331211SlipResp:GenericWebResponse
    {
        //public SalesTransactionBL331211Dto SalesTransactionBL331211 { get; set; }
        public List<dynamic> AF1BL331211 { get; set; }
        public List<dynamic> Step2BL331211 { get; set; }
        public List<dynamic> Step3BL331211 { get; set; }
        public List<dynamic> Step4BL331211 { get; set; }
        public List<CQHeader331211Dto> CQHeaderBL331211 { get; set; }
    }
}
