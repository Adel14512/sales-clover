using Evaluation.UI.Request;

namespace Evaluation.UI.Request.BL301401Consolidation
{
    public class PolicyBL301401NewRecReq : GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
