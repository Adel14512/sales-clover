using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL331211
{
    public class AF1BL331211Dto
    {
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the Serial field")]
        public int Serial { get; set; }
        [Required]
        public string Company { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StaffNbr field")]
        public string StaffNbr { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string GenderCode { get; set; }
        //[Required]
        //public string RelationCode { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string NationalityCode { get; set; }
        [Required]
        public string MaritalStatusCode { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public string Currency { get; set; }
      //  [Required]//[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
      //  public string AnnualWages { get; set; }
        [Required]
        public string LimitOfCoverage { get; set; }
        //public bool DoctorVisit { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Shop { get; set; }
    }
}