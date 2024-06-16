namespace Evaluation.UI.Request
{
    public class GenericEmptyReq
    {
        public GenericEmptyReq() {
            WebRequestCommon = new WebRequestCommonReq();
        }
        public WebRequestCommonReq WebRequestCommon { get; set; }
    }
}
