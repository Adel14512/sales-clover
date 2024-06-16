
using Evaluation.UI.DTO.BL331211;
using System.Collections.Generic;


namespace Evaluation.UI.Response.BL331211
{
    public class SalesTransactionBL331211DetailsPricesResp:GenericWebResponse
    {
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPrices { get; set; }
        public SalesTransactionBL331211DetailsNewDto SalesTransactionBL331211Details { get; set; }
    }
}
