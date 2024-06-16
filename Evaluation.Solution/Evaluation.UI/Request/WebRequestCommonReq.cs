namespace Evaluation.UI.Request
{
    public class WebRequestCommonReq
    {
        public WebRequestCommonReq() {
            UserName = "string";
            CorrelationId = "string";
        }
        public string UserName { get; set; }
        public string CorrelationId { get; set; }
    }
}
