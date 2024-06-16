using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL010602Consolidation
{
    public class PolicyBL010602NewRecReq: GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
