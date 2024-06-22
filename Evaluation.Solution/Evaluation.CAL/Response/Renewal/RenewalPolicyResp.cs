using Evaluation.CAL.DTO.Renewal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.Renewal
{
    public class RenewalPolicyResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<RenewalPolicyDto> RenewalPolicy { get; set; }
    }
}
