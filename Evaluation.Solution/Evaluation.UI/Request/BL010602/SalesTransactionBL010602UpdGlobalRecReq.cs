using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL010602
{
    public class SalesTransactionBL010602UpdGlobalRecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
