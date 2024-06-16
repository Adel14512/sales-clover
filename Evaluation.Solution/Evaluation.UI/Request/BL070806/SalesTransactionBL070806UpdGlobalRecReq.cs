using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL070806
{
    public class SalesTransactionBL070806UpdGlobalRecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
