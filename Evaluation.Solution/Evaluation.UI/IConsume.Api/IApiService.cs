using Evaluation.UI.Request;
using Evaluation.UI.Response;
using System.Net;

namespace Evaluation.UI.IConsume.Api
{
    public interface IApiService
    {
        UserResp CheckUserCred(UserCredReq request);
        UserResp IsUserAvailable(UserSignedReq request);
        UserResp RegisterUser(UserRegisterReq request);
        UserResp UpdateUserPassword(UserChangePasswordReq request);
        dynamic HandleHttpResponse(WebException ex);
      
    }
}
