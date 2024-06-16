using Evaluation.UI.Models;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response
{
    public class LeadFindAllResp : GenericWebResponse
    {
        public List<LeadDto> Lead { get; set; }
    }
}
