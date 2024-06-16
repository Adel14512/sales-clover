namespace Evaluation.UI.Response
{
    public class ChannelResp :GenericWebResponse
    {
        public int recId { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public bool isActive { get; set; }
        public bool IsDefault { get; set; }
        public List<Channels> channel { get; set; }
    }
    public class Channels
    {
        public int recId { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public bool isActive { get; set; }
    }
}
