using Evaluation.CAL.DTO.BL070806Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL070806Consolidation
{
    public class PolicyBL070806UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL070806Dto> PolicyBL070806 { get; set; }
    }
}
