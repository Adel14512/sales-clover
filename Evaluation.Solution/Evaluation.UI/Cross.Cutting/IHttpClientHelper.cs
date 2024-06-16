namespace Evaluation.UI.Cross.Cutting
{
    public interface IHttpClientHelper
    {
        string CallRestWebApiClient(string url, string methodType, object body = null);
        string CallRestClient(string url, string methodType, object body = null);
        Task<List<T>> PostApiRequestAsync<T>(object requestBody, string apiUrl, CancellationToken ct);
        Task<T> PostApiRequestModelAsync<T>(object requestBody, string apiUrl, CancellationToken ct);
    }
}
