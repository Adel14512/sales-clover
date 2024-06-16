using Evaluation.CAL.DTO.BL331211;
using Evaluation.CAL.DTO.BL331211Consolidation;
using Evaluation.CAL.DTO.Consolidation;
using System.Collections.Generic;


namespace Evaluation.CAL.Response.BL331211Consolidation
{
    public class PolicyBL331211Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL331211Dto> Policy { get; set; }
        public SalesTransactionBL331211Dto SalesTransactionBL331211 { get; set; }
        public List<PaymentScheduleBL331211Dto> paymentScheduleBL331211 { get; set; }
        public List<PolicyRelatedDocBL331211Dto> policyRelatedDoc331211 { get; set; }
    }
}
