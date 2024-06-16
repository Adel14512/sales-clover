using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL010602
{
    public class SalesTransactionBL010602UpdGlobalRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
