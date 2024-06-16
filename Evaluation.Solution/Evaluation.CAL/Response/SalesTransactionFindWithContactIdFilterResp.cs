using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class SalesTransactionFindWithContactIdFilterResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<SalesTransactionDto> SalesTransaction { get; set; }
    }
}
