using Evaluation.CAL.DTO.BL321110;
using Evaluation.CAL.DTO.BL321110Consolidation;
using Evaluation.CAL.DTO.Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL321110Consolidation
{
    public class PolicyBL321110Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL321110Dto> Policy { get; set; }
        public SalesTransactionBL321110Dto SalesTransactionBL321110 { get; set; }
        public List<PaymentScheduleBL321110Dto> paymentScheduleBL321110 { get; set; }
        public List<PolicyRelatedDocBL321110Dto> policyRelatedDoc321110 { get; set; }
    }
}
