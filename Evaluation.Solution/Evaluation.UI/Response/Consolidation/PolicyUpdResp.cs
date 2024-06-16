
using Evaluation.UI.DTO.Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.Consolidation
{
    public class PolicyUpdResp : GenericWebResponse
    {
        public List<PolicyDto> Policy { get; set; }
    }
}
