using Evaluation.UI.Request;

namespace Evaluation.UI.Request
{
  

public class ContactSearchReq :GenericEmptyReq
    {
        public bool IsWideSearch { get; set; }
        public string SearchValue { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string LineNbr { get; set; }
        public string Dob { get; set; }
    }
}
