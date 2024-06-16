using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL051807
{
    public class SalesTransactionBL051807FindAF1WithRecIdReq : GenericEmptyReq
    {

        [Required]
        public int SalesTransactionId { get; set; }
    }
}
