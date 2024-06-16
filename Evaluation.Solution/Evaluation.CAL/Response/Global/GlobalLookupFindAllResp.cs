using Evaluation.CAL.DTO.Global;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.Global
{
    public class GlobalLookupFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ClientDto> Client { get; set; }
        public List<MasterDto> Master { get; set; }
    }
}
