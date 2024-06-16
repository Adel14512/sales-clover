using Evaluation.CAL.DTO.BL041312Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL041312Consolidation
{
    public class PolicyBL041312UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL041312Dto> PolicyBL041312 { get; set; }
    }
}
