using Evaluation.UI.Models;

namespace Evaluation.UI.Response
{
    public class BusinessLineResp : GenericWebResponse
    {
        public List<BusinessLine> BusinessLine { get; set; }
    }
}
