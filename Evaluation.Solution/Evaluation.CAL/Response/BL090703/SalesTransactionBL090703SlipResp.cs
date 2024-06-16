using Evaluation.CAL.DTO.BL090703;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL090703
{
    public class SalesTransactionBL090703SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL090703Dto SalesTransactionBL090703 { get; set; }
        public List<CQHeader090703Dto> CQHeaderBL090703 { get; set; }
    }
}
