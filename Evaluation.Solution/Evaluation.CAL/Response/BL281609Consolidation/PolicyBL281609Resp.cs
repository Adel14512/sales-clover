using Evaluation.CAL.DTO.BL281609;
using Evaluation.CAL.DTO.BL281609Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL281609Consolidation
{
    public class PolicyBL281609Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL281609Dto> Policy { get; set; }
        public SalesTransactionBL281609Dto SalesTransactionBL281609 { get; set; }
        public List<PaymentScheduleBL281609Dto> paymentScheduleBL281609 { get; set; }
        public List<PolicyRelatedDocBL281609Dto> policyRelatedDoc281609 { get; set; }
    }
}
