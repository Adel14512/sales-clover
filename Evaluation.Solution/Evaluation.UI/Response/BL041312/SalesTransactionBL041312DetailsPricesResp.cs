

using Evaluation.UI.DTO.BL041312;

namespace Evaluation.UI.Response.BL041312
{
    public class SalesTransactionBL041312DetailsPricesResp : GenericWebResponse
    {
        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPrices { get; set; }
        public SalesTransactionBL041312DetailsNewDto SalesTransactionBL041312Details { get; set; }
    }
}
