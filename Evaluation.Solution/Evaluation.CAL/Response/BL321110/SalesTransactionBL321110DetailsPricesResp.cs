using Evaluation.CAL.DTO.BL321110;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL321110
{
    public class SalesTransactionBL321110DetailsPricesResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPrices { get; set; }
        public SalesTransactionBL321110DetailsNewDto SalesTransactionBL321110Details { get; set; }
    }
}
