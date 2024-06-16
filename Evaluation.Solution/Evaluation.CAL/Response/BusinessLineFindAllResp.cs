using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class BusinessLineFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<BusinessLineDto> BusinessLine { get; set; }
    }
}
