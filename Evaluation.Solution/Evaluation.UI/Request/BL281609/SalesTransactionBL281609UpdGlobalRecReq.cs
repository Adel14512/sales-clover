using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL281609
{
    public class SalesTransactionBL281609UpdGlobalRecReq : GenericEmptyReq
	{
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public string PolicyId { get; set; }
    }
}
