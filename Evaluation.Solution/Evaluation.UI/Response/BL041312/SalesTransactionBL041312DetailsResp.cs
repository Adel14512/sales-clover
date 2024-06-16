

using Evaluation.UI.DTO.BL041312;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL041312
{
    public class SalesTransactionBL041312DetailsResp:GenericWebResponse
    {
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312Details { get; set; }
        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPrices { get; set; }
    }
}
