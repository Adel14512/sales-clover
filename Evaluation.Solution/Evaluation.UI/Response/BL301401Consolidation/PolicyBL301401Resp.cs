
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.DTO.BL301401Consolidation;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL301401Consolidation
{
    public class PolicyBL301401Resp : GenericWebResponse
    {
        public List<PolicyBL301401Dto> Policy { get; set; }
        public SalesTransactionBL301401Dto SalesTransactionBL301401 { get; set; }
        public List<PaymentScheduleBL301401Dto> paymentScheduleBL301401 { get; set; }
        public List<PolicyRelatedDocBL301401Dto> policyRelatedDoc301401 { get; set; }
    }
}
