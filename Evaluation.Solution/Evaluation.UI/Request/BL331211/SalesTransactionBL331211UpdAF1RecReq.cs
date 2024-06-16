using Evaluation.UI.DTO.BL331211;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211UpdAF1RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL331211Dto> AF1BL331211 { get; set; }
    }
}
