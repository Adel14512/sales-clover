using Evaluation.CAL.DTO.Global;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.Global
{
    public class ClientCodeFindResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ClientCodeDto> Client { get; set; }
    }
}
