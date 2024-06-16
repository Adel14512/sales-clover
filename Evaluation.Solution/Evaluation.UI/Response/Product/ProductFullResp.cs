
using Evaluation.UI.DTO.Product;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.Product
{
    public class ProductFullResp: GenericWebResponse
    {
        public ProductFullDto ProductFull { get; set; }
    }
}
