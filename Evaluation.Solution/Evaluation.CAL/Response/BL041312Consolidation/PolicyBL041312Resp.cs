using Evaluation.CAL.DTO.BL041312;
using Evaluation.CAL.DTO.BL041312Consolidation;
using Evaluation.CAL.DTO.Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL041312Consolidation
{
    public class PolicyBL041312Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL041312Dto> Policy { get; set; }
        public SalesTransactionBL041312Dto SalesTransactionBL041312 { get; set; }
        public List<PaymentScheduleBL041312Dto> paymentScheduleBL041312 { get; set; }
        public List<PolicyRelatedDocBL041312Dto> policyRelatedDoc041312 { get; set; }
    }
}
