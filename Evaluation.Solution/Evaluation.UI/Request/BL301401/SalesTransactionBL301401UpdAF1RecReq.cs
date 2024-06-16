using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL301401
{
    public class SalesTransactionBL301401UpdAF1RecReq:GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public List<AF1BL301401Dto> AF1BL301401 { get; set; }
    }
}
