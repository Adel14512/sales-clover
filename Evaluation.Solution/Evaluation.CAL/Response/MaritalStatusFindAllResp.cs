using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class MaritalStatusFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<MaritalStatusDto> MaritalStatus { get; set; }
    }
}
