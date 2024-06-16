using Evaluation.CAL.DTO.BL070806;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL070806
{
    public class SalesTransactionBL070806SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL070806Dto SalesTransactionBL070806 { get; set; }
        public List<CQHeader070806Dto> CQHeaderBL070806 { get; set; }
    }
}
