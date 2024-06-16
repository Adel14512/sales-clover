using Evaluation.UI.DTO.Global;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.Global
{
    public class GlobalLookupFindAllResp : GenericWebResponse
    {
        public List<ClientDto> Client { get; set; }
        public List<MasterDto> Master { get; set; }
    }
}
