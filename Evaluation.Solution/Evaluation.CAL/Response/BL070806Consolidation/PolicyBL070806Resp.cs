using Evaluation.CAL.DTO.BL070806;
using Evaluation.CAL.DTO.BL070806Consolidation;
using System.Collections.Generic;


namespace Evaluation.CAL.Response.BL070806Consolidation
{
    public class PolicyBL070806Resp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL070806Dto> Policy { get; set; }
        public SalesTransactionBL070806Dto SalesTransactionBL070806 { get; set; }
        public List<PaymentScheduleBL070806Dto> paymentScheduleBL070806 { get; set; }
        public List<PolicyRelatedDocBL070806Dto> policyRelatedDoc070806 { get; set; }
    }
}
