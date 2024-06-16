using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class RegionFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<RegionDto> Region { get; set; }
    }
}
