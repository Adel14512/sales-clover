using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL030904
{
    public class SalesTransactionBL030904FindAF1WithRecIdReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
