
using Evaluation.UI.DTO.BL041312Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL041312Consolidation
{
    public class PolicyBL041312UpdResp : GenericWebResponse
    {
        public List<PolicyBL041312Dto> PolicyBL041312 { get; set; }
    }
}
