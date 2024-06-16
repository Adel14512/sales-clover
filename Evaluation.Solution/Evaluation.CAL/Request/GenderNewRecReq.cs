using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class GenderNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public GenderNewDto Gender { get; set; }
    }
}
