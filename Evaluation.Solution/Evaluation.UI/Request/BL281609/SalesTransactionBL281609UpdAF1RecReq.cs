
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL281609
{
    public class SalesTransactionBL281609UpdAF1RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL281609Dto> AF1BL281609 { get; set; }
    }
}
