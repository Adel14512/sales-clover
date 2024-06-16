using Evaluation.CAL.DTO.BL021502;
using Evaluation.CAL.DTO.BL021502Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL021502Consolidation
{
    public class PolicyBL021502Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL021502Dto> Policy { get; set; }
        public SalesTransactionBL021502Dto SalesTransactionBL021502 { get; set; }
        public List<PaymentScheduleBL021502Dto> paymentScheduleBL021502 { get; set; }
        public List<PolicyRelatedDocBL021502Dto> policyRelatedDoc021502 { get; set; }
    }
}
