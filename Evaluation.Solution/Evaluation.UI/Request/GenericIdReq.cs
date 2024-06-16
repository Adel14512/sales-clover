namespace Evaluation.UI.Request
{
    public class GenericIdReq
    {
        public GenericIdReq() {
            WebRequestCommon = new WebRequestCommonReq();
        }
        public WebRequestCommonReq WebRequestCommon { get; set; }
        public int recId { get; set; }
    }
}
