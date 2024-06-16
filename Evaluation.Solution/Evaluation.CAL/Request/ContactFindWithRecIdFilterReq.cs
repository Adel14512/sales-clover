using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ContactFindWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
    }
}
