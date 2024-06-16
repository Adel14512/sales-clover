using Evaluation.CAL.DTO.BL080501;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL080501
{
    public class SalesTransactionBL080501SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL080501Dto SalesTransactionBL080501 { get; set; }
        public List<CQHeader080501> CQHeaderBL080501 { get; set; }
    }
}
