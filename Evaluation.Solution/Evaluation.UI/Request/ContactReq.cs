using Evaluation.UI.Response;

namespace Evaluation.UI.Request
{
    public class ContactReq
    {
        
        public int recId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime? dob { get; set; }
        public string genderCode { get; set; }
        public string yob { get; set; }
        public string registrationNo { get; set; }
        public string code { get; set; }
        public string job { get; set; }
        public string company { get; set; }
        public string description { get; set; }
        public string localCode { get; set; }
        public string regionCode { get; set; }
        public List<ChannelReq> contactChannel { get; set; }
    }
}
