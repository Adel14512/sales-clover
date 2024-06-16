using Evaluation.UI.DTO.BL311703;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL311703
{
    public class SalesTransactionBL311703UpdAF1RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL311703Dto> AF1BL311703 { get; set; }
    }
}
