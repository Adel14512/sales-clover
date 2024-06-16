using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.DTO.BL331211Consolidation;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL331211Consolidation
{
    public class PolicyBL331211Resp : GenericWebResponse
    {
        public List<PolicyBL331211Dto> Policy { get; set; }
        public SalesTransactionBL331211Dto SalesTransactionBL331211 { get; set; }
        public List<PaymentScheduleBL331211Dto> paymentScheduleBL331211 { get; set; }
        public List<PolicyRelatedDocBL331211Dto> policyRelatedDoc331211 { get; set; }
    }
}
