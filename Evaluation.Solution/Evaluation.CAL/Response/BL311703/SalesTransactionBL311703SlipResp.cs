using Evaluation.CAL.DTO.BL311703;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL311703
{
    public class SalesTransactionBL311703SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL311703Dto SalesTransactionBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeaderBL311703 { get; set; }
    }
}
