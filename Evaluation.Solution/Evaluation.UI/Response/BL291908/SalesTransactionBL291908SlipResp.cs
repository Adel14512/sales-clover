
using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL291908
{
    public class SalesTransactionBL291908SlipResp :GenericWebResponse
    {
        public SalesTransactionBL291908Dto SalesTransactionBL291908 { get; set; }
        public List<CQHeader291908Dto> CQHeaderBL291908 { get; set; }
    }
}
