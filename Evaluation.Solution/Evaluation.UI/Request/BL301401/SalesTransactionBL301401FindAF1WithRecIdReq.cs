using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL301401
{
    public class SalesTransactionBL301401FindAF1WithRecIdReq :GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
