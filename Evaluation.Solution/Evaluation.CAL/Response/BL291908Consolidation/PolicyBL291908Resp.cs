using Evaluation.CAL.DTO.BL291908;
using Evaluation.CAL.DTO.BL291908Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL291908Consolidation
{
    public class PolicyBL291908Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL291908Dto> Policy { get; set; }
        public SalesTransactionBL291908Dto SalesTransactionBL291908 { get; set; }
        public List<PaymentScheduleBL291908Dto> paymentScheduleBL291908 { get; set; }
        public List<PolicyRelatedDocBL291908Dto> policyRelatedDoc291908 { get; set; }
    }
}
