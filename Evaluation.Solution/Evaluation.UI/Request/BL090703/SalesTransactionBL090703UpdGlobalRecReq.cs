using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL090703
{
    public class SalesTransactionBL090703UpdGlobalRecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
