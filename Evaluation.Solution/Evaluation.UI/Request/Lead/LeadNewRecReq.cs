using Evaluation.UI.Models;

namespace Evaluation.UI.Request.Lead
{
    public class LeadNewRecReq: GenericEmptyReq
    {
        public LeadNewDto Lead { get; set; }
    }
}
