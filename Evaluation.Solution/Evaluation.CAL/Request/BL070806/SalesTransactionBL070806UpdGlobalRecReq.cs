using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL070806
{
    public class SalesTransactionBL070806UpdGlobalRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
