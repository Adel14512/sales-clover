

using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL331211
{
    public class SalesTransactionBL331211DetailsResp:GenericWebResponse
    {
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211Details { get; set; }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPrices { get; set; }
    }
}
