using Evaluation.UI.Request;

namespace Evaluation.UI.Request
{
  

public class ContactCreateReq
    {
        public ContactCreateReq() {
            WebRequestCommon = new WebRequestCommonReq();
        }   
        public WebRequestCommonReq WebRequestCommon { get; set; }
        public ContactReq Contact { get; set; }
    }
}
