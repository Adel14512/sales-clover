
using Evaluation.UI.DTO.BL321110;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL321110
{
    public class SalesTransactionBL321110DetailsResp:GenericWebResponse
    {
        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110Details { get; set; }
        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPrices { get; set; }
    }
}
