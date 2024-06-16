using Evaluation.CAL.DTO.BL041312;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL041312
{
    public class SalesTransactionBL041312DetailsResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312Details { get; set; }
        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPrices { get; set; }
    }
}
