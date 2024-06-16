using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL090703
{
    public class SalesTransactionBL090703UpdGlobalRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
