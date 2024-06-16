using Evaluation.CAL.DTO.BL090703;
using Evaluation.CAL.DTO.BL090703Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL090703Consolidation
{
    public class PolicyBL090703Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL090703Dto> Policy { get; set; }
        public SalesTransactionBL090703Dto SalesTransactionBL090703 { get; set; }
        public List<PaymentScheduleBL090703Dto> paymentScheduleBL090703 { get; set; }
        public List<PolicyRelatedDocBL090703Dto> policyRelatedDoc090703 { get; set; }
    }
}
