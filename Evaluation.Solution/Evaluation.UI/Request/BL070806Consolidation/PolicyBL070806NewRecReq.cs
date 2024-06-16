using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL070806Consolidation
{
    public class PolicyBL070806NewRecReq : GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
