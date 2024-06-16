

using Evaluation.UI.DTO.BL321110;

namespace Evaluation.UI.Response.BL321110
{
    public class SalesTransactionBL321110DetailsPricesResp : GenericWebResponse
    {
        public SalesTransactionBL321110DetailsNewDto SalesTransactionBL321110Details { get; set; }
        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPrices { get; set; }
    }
}
