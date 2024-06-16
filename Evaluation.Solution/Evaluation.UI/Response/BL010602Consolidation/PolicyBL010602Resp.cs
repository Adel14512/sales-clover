using Evaluation.UI.DTO.BL010602;
using Evaluation.UI.DTO.BL010602Consolidation;

namespace Evaluation.UI.Response.BL010602Consolidation
{
    public class PolicyBL010602Resp : GenericWebResponse
    {
        public List<PolicyBL010602Dto> Policy { get; set; }
        public SalesTransactionBL010602Dto SalesTransactionBL010602 { get; set; }
        public List<PaymentScheduleBL010602Dto> paymentScheduleBL010602 { get; set; }
        public List<PolicyRelatedDocBL010602Dto> policyRelatedDoc010602 { get; set; }
    }
}
