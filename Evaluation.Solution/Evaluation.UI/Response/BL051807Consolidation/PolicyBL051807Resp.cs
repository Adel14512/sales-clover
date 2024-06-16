

using Evaluation.UI.DTO.BL051807;
using Evaluation.UI.DTO.BL051807Consolidation;

namespace Evaluation.UI.Response.BL051807Consolidation
{
    public class PolicyBL051807Resp:GenericWebResponse
    {
        public List<PolicyBL051807Dto> Policy { get; set; }
        public SalesTransactionBL051807Dto SalesTransactionBL051807 { get; set; }
        public List<PaymentScheduleBL051807Dto> paymentScheduleBL051807 { get; set; }
        public List<PolicyRelatedDocBL051807Dto> policyRelatedDoc051807 { get; set; }
    }
}
