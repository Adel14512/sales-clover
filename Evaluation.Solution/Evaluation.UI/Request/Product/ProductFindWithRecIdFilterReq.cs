using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.Product
{
    public class ProductFindWithRecIdFilterReq : GenericEmptyReq
    {
        
        [Required]
        public int RecId { get; set; }
    }
}
