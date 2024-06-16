using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.Product
{
    public class ProductFindAllReq :GenericEmptyReq
    {
        public bool IsActive { get; set; }
    }
}
