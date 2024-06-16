using Evaluation.UI.DTO;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Response;
using System.Security.Claims;

namespace Evaluation.UI.IConsume.Api
{
    public interface IUserApi
    {
        Task<UserCredResp> Login(UserCredViewModel request, CancellationToken ct);
        Task<UserDto> GetUserClaims(IEnumerable<Claim> claims);
    }
}
