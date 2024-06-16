
using Evaluation.UI.DTO.Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.Consolidation
{
    public class PolicyRelatedDocResp :GenericWebResponse
    {
        public PolicyRelatedDocDto PolicyRelatedDoc { get; set; }
    }
}
