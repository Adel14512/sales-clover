

using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.DTO.BL291908Consolidation;

namespace Evaluation.UI.Response.BL291908Consolidation
{
    public class PolicyBL291908Resp : GenericWebResponse
    {
        public List<PolicyBL291908Dto> Policy { get; set; }
        public SalesTransactionBL291908Dto SalesTransactionBL291908 { get; set; }
        public List<PaymentScheduleBL291908Dto> paymentScheduleBL291908 { get; set; }
        public List<PolicyRelatedDocBL291908Dto> policyRelatedDoc291908 { get; set; }
    }
}
