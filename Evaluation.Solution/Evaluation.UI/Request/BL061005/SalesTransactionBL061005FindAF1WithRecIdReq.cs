using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL061005
{
    public class SalesTransactionBL061005FindAF1WithRecIdReq : GenericEmptyReq
    {

        [Required]
        public int SalesTransactionId { get; set; }
    }
}
