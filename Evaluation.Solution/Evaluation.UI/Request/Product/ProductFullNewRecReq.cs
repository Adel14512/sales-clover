using Evaluation.UI.DTO.Product;
using Evaluation.UI.Request;

namespace Evaluation.UI.Request.Product
{
    public class ProductFullNewRecReq: GenericEmptyReq
    {
        public ProductFullNewDto ProductFull { get; set; }
    }
}
