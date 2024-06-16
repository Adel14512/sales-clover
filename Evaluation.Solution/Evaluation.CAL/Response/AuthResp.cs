using Evaluation.CAL.DTO;

namespace Evaluation.CAL.Response
{
    public class AuthResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public TokenDto Token { get; set; }
    }
}