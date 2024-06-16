namespace Evaluation.UI.Response
{
    public class ContactChannelResp
    {
        public int recId { get; set; }
        public int contactId { get; set; }
        public int channelId { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string contactChannelValue { get; set; }
        public string countryCode { get; set; }
        public string areaCode { get; set; }
        public object extension { get; set; }
    }
}
