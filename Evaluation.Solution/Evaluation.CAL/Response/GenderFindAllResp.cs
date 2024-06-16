using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class GenderFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<GenderDto> Gender { get; set; }
    }
}
