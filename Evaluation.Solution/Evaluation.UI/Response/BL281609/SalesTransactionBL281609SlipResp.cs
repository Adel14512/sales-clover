
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL281609
{
    public class SalesTransactionBL281609SlipResp:GenericWebResponse
    {
        public SalesTransactionBL281609Dto SalesTransactionBL281609 { get; set; }
        public List<CQHeader281609Dto> CQHeaderBL281609 { get; set; }
    }
}
