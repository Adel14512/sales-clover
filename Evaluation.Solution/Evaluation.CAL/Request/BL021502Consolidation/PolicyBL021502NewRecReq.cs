using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL021502Consolidation
{
    public class PolicyBL021502NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
