using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Global
{
    public class ClientCodeFindWithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int RecId { get; set; }
    }
}
