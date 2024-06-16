using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ContactChannelUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ContactUpdDto Contact { get; set; }
    }
}
