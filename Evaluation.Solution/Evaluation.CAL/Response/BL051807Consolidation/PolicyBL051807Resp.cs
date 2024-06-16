using Evaluation.CAL.DTO.BL051807;
using Evaluation.CAL.DTO.BL051807Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL051807Consolidation
{
    public class PolicyBL051807Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL051807Dto> Policy { get; set; }
        public SalesTransactionBL051807Dto SalesTransactionBL051807 { get; set; }
        public List<PaymentScheduleBL051807Dto> paymentScheduleBL051807 { get; set; }
        public List<PolicyRelatedDocBL051807Dto> policyRelatedDoc051807 { get; set; }
    }
}
