using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class AuthReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public AuthDto Auth { get; set; }
    }
}
