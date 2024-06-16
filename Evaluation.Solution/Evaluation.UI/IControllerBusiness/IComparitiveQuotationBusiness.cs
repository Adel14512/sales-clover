using Evaluation.UI.DTO;
using Evaluation.UI.Models;
using System.Security.Claims;

namespace Evaluation.UI.IControllerBusiness
{
    public interface IComparitiveQuotationBusiness
    {
        Task<CQAf8VM> GetCQ_1_8(string id, IEnumerable<Claim> claims,bool isShort, CancellationToken ct);
        Task CQ_1_8(CQAf8VM cQAfVM, UserDto user, int trxID, bool isShort, CancellationToken ct);
        Task<CQAf07VM> GetCQ6(string id, IEnumerable<Claim> claims, bool isShort, CancellationToken ct);
        Task CQ6(CQAf07VM cQAfVM, UserDto user, int trxID, bool isShort, CancellationToken ct);
        Task<CQAf28VM> GetCQ9(string id, IEnumerable<Claim> claims, bool isShort, CancellationToken ct);
        Task CQ9(CQAf28VM cQAfVM, UserDto user, int trxID, bool isShort, CancellationToken ct);
    }
}
