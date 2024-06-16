using Evaluation.UI.Models;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL77
{
    public class SalesTransactionBL77UpdRecReq :GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL77Dto> AF1BL77 { get; set; }
    }
}
