using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL301401
{
    public class SalesTransactionBL301401UpdGlobalRecReq:GenericEmptyReq
    {
      
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public string PolicyId { get; set; }
    }
}
