
using Evaluation.UI.DTO.Product;

namespace Evaluation.UI.Response.Product
{
    public class ProductFindAllResp : GenericWebResponse
    {
        public List<ProductDto> Product { get; set; }
    }
}
