using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL030904
{
    public class AF1BL030904Dto
    {
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the Serial field")]
        //public int Serial { get; set; }
        //[Required]
        //public string Company { get; set; }
        ////[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StaffNbr field")]
        //public string StaffNbr { get; set; }
        [Required]
        public string FirstName { get; set; }
        //[Required]
        public string MiddleName { get; set; }
        //[Required]
        public string LastName { get; set; }
        [Required]
        //[ValueInTable(ErrorMessage = "The value must exist in the SQL table.")]
        public string GenderCode { get; set; }
        //[Required]
        //public string RelationCode { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string NationalityCode { get; set; }
        [Required]
        public string MaritalStatusCode { get; set; }
        //[Required]
        //public string Grade { get; set; }
        //public bool NSSF { get; set; }
        //public int ClassOfCoveragCode { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        //public bool Ambulatory { get; set; }
        //public bool PrescriptionMedecine { get; set; }
        //public bool DoctorVisit { get; set; }
        [Required]
        public string CountryOfResidenceCode { get; set; }
        [Required]
        public string RequestedLimitCurrency { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        [Required]
        public string Occupation { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the LimitOfCoverage field")]
        [Required]
        public string ReasonOfInsurance { get; set; }
        [Required]
        public string Beneficiary { get; set; }
    }
}
