using System.ComponentModel.DataAnnotations;


namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312FindSlipWithRecIdReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
