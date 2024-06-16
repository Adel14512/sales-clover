namespace Evaluation.UI.Request
{ 
    public class ChannelReq
    {
        public WebRequestCommonReq WebRequestCommon { get; set; }
        public string channelCode { get; set; }
        public string contactChannelValue { get; set; }
        public string type { get; set; }
        public int? countryCode { get; set; }
        public int? areaCode { get; set; }
        public int? extension { get; set; }
        public int? recId { get; set; }
        public bool IsActive { get; set; }
    }
}
