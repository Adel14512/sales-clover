using Evaluation.UI.Request;
using Evaluation.UI.Response;

namespace Evaluation.UI.IConsume.Api
{
    public interface IChannelApi
    {
        Task<ChannelResp> GetAllChannel(GenericEmptyReq request, CancellationToken ct);
        Task<ChannelResp> CreateChannel(ChannelNewRecReq request, CancellationToken ct);
        Task<ChannelResp> EditChannel(ChannelNewRecReq request, CancellationToken ct);
        Task<ChannelResp> GetChannelByID(GenericIdReq request, CancellationToken ct);
    }
}
