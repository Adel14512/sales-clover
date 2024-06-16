using Evaluation.UI.DTO.BL030904;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL030904
{
    public class SalesTransactionBL030904UpdAF1RecReq :GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL030904Dto> AF1BL030904 { get; set; }
    }
}
