
using Evaluation.UI.DTO.Dashboard;

namespace Evaluation.UI.Response.Dashboard
{
    public class ProductPriceControlResp:GenericWebResponse
    {
        public List<ProductPriceControlDto> ProductPriceControl { get; set; }
    }
}