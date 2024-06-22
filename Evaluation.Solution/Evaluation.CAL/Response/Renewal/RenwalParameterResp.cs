using Evaluation.CAL.DTO.Renewal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.Renewal
{
    public class RenwalParameterResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<RenewalParameterDto> RenewalParameter { get; set; }
    }
}