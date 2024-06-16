
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.DTO.BL321110Consolidation;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL321110Consolidation
{
    public class PolicyBL321110Resp : GenericWebResponse
    {
        public List<PolicyBL321110Dto> Policy { get; set; }
        public SalesTransactionBL321110Dto SalesTransactionBL321110 { get; set; }
        public List<PaymentScheduleBL321110Dto> paymentScheduleBL321110 { get; set; }
        public List<PolicyRelatedDocBL321110Dto> policyRelatedDoc321110 { get; set; }
    }
}
