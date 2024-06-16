
using Evaluation.UI.DTO.ProductPriceList;

namespace Evaluation.UI.Response.ProductPriceList
{
    public class ProductPriceListResp : GenericWebResponse
    {
        public List<ProductPriceListDto> ProductPriceList { get; set; }
    }
}
