
using Evaluation.UI.DTO.BL021502;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL021502
{
    public class SalesTransactionBL021502UpdAF1RecReq: GenericEmptyReq
    {
     
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL021502Dto> AF1BL021502 { get; set; }
    }
}
