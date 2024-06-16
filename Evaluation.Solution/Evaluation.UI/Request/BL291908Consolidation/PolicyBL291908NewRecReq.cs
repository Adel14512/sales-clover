using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL291908Consolidation
{
    public class PolicyBL291908NewRecReq:GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
