
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211UpdSlip5RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip5BL331211Dto> Slip5BL331211 { get; set; }
    }
}
