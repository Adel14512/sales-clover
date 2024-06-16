
using Evaluation.UI.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.Product
{
    public class ProductDetailsNewRecReq :GenericEmptyReq
    {
        public ProductDetailsNewDto ProductDetails { get; set; }
    }
}
