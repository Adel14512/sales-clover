using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.Consolidation;
using System.Collections.Generic;

namespace Evaluation.UI.Response.Consolidation
{
    public class PolicyResp : GenericWebResponse
    {
        public List<PolicyDto> Policy { get; set; }
        public SalesTransactionBL080501Dto SalesTransactionBL080501 { get; set; }
        public List<PaymentScheduleDto> PaymentSchedule { get; set; }
        public List<PolicyRelatedDocDto> PolicyRelatedDoc { get; set; }
    }
}
