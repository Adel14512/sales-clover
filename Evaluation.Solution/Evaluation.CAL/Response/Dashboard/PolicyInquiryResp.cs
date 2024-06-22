using Evaluation.CAL.DTO.Dashboard;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.Dashboard
{
    public class PolicyInquiryResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyInquiryDto> PolicyInquiry { get; set; }
    }
}
