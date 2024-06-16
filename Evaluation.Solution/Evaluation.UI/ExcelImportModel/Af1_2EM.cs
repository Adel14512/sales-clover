using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.ExcelImportModel
{
    public class Af1_2EM
    {
        
        public string Serial { get; set; }
   
        public string Company { get; set; }
        public string StaffNbr { get; set; }
      
        public string FirstName { get; set; }
  
        public string MiddleName { get; set; }
      
        public string LastName { get; set; }
     
        public string GenderCode { get; set; }
      
        public string DOB { get; set; }
        public string NationalityCode { get; set; }
        public string MaritalStatusCode { get; set; }
   
        public string CountryOfDepartureCode { get; set; }
        public string CountryOfDestinationCode { get; set; }
   
        public string StayTripOptionCode { get; set; }
        public string NbrDaysWhenLess92 { get; set; }
    }
}
