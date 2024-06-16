using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL090703Consolidation
{
    public class PolicyBL090703NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
