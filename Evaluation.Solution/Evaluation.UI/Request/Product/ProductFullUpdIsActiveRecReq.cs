
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.Product
{
    public class ProductFullUpdIsActiveRecReq : GenericEmptyReq
    {
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
