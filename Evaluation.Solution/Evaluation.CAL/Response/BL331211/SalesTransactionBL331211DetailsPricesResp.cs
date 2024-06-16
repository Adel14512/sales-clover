using Evaluation.CAL.DTO.BL331211;
using System.Collections.Generic;


namespace Evaluation.CAL.Response.BL331211
{
    public class SalesTransactionBL331211DetailsPricesResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPrices { get; set; }
        public SalesTransactionBL331211DetailsNewDto SalesTransactionBL331211Details { get; set; }
    }
}
