using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL301401Consolidation
{
    public class PolicyBL301401NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
