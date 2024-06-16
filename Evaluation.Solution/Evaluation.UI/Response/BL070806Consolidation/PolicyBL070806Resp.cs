
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.DTO.BL070806Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;


namespace Evaluation.UI.Response.BL070806Consolidation
{
    public class PolicyBL070806Resp : GenericWebResponse
    {
        public List<PolicyBL070806Dto> Policy { get; set; }
        public SalesTransactionBL070806Dto SalesTransactionBL070806 { get; set; }
        public List<PaymentScheduleBL070806Dto> paymentScheduleBL070806 { get; set; }
        public List<PolicyRelatedDocBL070806Dto> policyRelatedDoc070806 { get; set; }
    }
}
