using Evaluation.CAL.DTO.BL080501;
using Evaluation.CAL.DTO.Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.Consolidation
{
    public class PolicyResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyDto> Policy { get; set; }
        public SalesTransactionBL080501Dto SalesTransactionBL080501 { get; set; }
        public List<PaymentScheduleDto> paymentSchedule { get; set; }
        public List<PolicyRelatedDocDto> policyRelatedDoc { get; set; }
    }
}
