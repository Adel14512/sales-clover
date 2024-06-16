using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL291908Consolidation
{
    public class PolicyBL291908NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
