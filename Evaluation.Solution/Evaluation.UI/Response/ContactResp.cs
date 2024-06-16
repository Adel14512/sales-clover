using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Response
{
  
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ContactResp :GenericWebResponse
    {
     
        public int RecId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MotherName { get; set; }
        public object Dob { get; set; }
        public int YOB { get; set; }
        public string RegistrationNo { get; set; }
        public int GenderId { get; set; }
        public string Code { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string LocalCode { get; set; }
        public string RegionCode { get; set; }
        public int RegionID { get; set; }
        public List<ContactChannelResp> ContactChannel { get; set; }
    }

   
  




}
