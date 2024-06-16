
using Evaluation.UI.DTO.BL291908;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL291908
{
    public class SalesTransactionBL291908UpdAF1RecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        [Required]
        public List<AF1BL291908Dto> AF1BL291908 { get; set; }
    }
}
