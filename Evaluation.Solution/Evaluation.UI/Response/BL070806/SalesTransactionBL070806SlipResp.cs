
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL070806
{
    public class SalesTransactionBL070806SlipResp : GenericWebResponse
    {
        public SalesTransactionBL070806Dto SalesTransactionBL070806 { get; set; }
        public List<CQHeader070806Dto> CQHeaderBL070806 { get; set; }
    }
}
