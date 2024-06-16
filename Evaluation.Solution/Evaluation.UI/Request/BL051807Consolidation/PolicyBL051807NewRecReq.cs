using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL051807Consolidation
{
    public class PolicyBL051807NewRecReq:GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
