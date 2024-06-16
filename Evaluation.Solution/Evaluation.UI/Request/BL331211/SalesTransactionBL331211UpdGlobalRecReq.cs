using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211UpdGlobalRecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
