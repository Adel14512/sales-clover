using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL080501
{
    public class SalesTransactionBL080501UpdGlobalRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public string PolicyId { get; set; }

    }
}
