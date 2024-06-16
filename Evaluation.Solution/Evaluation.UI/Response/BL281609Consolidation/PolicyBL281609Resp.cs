
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.DTO.BL281609Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL281609Consolidation
{
    public class PolicyBL281609Resp : GenericWebResponse
    {
        public List<PolicyBL281609Dto> Policy { get; set; }
        public SalesTransactionBL281609Dto SalesTransactionBL281609 { get; set; }
        public List<PaymentScheduleBL281609Dto> paymentScheduleBL281609 { get; set; }
        public List<PolicyRelatedDocBL281609Dto> policyRelatedDoc281609 { get; set; }
    }
}
