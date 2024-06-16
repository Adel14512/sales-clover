using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL321110
{
    public class SalesTransactionBL321110UpdAF1RecReq :GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL321110Dto> AF1BL321110 { get; set; }
    }
}
