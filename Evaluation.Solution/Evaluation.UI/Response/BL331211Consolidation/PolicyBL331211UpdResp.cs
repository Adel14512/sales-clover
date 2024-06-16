using Evaluation.UI.DTO.BL331211Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL331211Consolidation
{
    public class PolicyBL331211UpdResp : GenericWebResponse
    {
        public List<PolicyBL331211Dto> PolicyBL331211 { get; set; }
    }
}
