using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ContactChannelNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ContactNewDto Contact { get; set; }
    }
}
