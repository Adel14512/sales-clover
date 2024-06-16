using Evaluation.UI.Models.Transaction;
using System.Security.Claims;

namespace Evaluation.UI.IControllerBusiness
{
    public interface ITransactionBusiness
    {
        Task<Detailed301401VM> Detailed301401Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed070806VM> Detailed070806Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed090703VM> Detailed090703Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed010602VM> Detailed010602Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed021502VM> Detailed021502Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed281609VM> Detailed281609Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed331211VM> Detailed331211Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed030904VM> Detailed030904Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed051807VM> Detailed051807Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed041312VM> Detailed041312Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed061005VM> Detailed061005Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed291908VM> Detailed291908Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
        Task<Detailed311703VM> Detailed311703Business(string id, IEnumerable<Claim> claims, CancellationToken ct);
    }
}
