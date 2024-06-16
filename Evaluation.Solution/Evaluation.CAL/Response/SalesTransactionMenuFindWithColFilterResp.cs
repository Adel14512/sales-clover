using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class SalesTransactionMenuFindWithColFilterResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<SalesTransactionMenuDto> SalesTransactionMenu { get; set; }
    }
}
