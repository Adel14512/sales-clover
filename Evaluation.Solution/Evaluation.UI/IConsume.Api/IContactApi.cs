using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Response;

namespace Evaluation.UI.IConsume.Api
{
    public interface IContactApi
    {
        Task<GenericWebResponse> CreateContactApi(ContactCreateReq request, CancellationToken ct);
        Task<GenericWebResponse> EditContactApi(ContactCreateReq request, CancellationToken ct);
        Task<ContactVM> GetContactByIDApi(GenericIdReq request, CancellationToken ct);
    }
}
