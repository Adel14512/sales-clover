
using Evaluation.UI.DTO.BL090703;
using Evaluation.UI.DTO.BL090703Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL090703Consolidation
{
    public class PolicyBL090703Resp : GenericWebResponse
    {
        public List<PolicyBL090703Dto> Policy { get; set; }
        public SalesTransactionBL090703Dto SalesTransactionBL090703 { get; set; }
        public List<PaymentScheduleBL090703Dto> paymentScheduleBL090703 { get; set; }
        public List<PolicyRelatedDocBL090703Dto> policyRelatedDoc090703 { get; set; }
    }
}
