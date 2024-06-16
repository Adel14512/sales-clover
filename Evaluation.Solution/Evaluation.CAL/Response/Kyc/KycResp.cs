using Evaluation.CAL.DTO.Kyc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.Kyc
{
    public class KycResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<KycDto> Kyc { get; set; }
    }
}
