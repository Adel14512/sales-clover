using Evaluation.UI.DTO.BL301401Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL301401Consolidation
{
    public class PolicyBL301401UpdResp : GenericWebResponse
    {
        public List<PolicyBL301401Dto> PolicyBL301401 { get; set; }
    }
}
