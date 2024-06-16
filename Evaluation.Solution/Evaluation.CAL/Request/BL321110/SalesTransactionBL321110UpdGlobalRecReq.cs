using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL321110
{
    public class SalesTransactionBL321110UpdGlobalRecReq
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
