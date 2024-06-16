
using Evaluation.UI.DTO.BL090703;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL090703
{
    public class SalesTransactionBL090703UpdAF1RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public AF1BL090703Dtco AF1BL090703 { get; set; }
    }
}
