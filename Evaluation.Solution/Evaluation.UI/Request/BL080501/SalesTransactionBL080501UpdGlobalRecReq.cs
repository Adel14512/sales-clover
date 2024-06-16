
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL080501
{
    public class SalesTransactionBL080501UpdGlobalRecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
