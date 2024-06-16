using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL301401
{
    public class AF1BL301401Dto
    {
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the Serial field")]
        public int Serial { get; set; }
        [Required]
        public string ClientName { get; set; }
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
        [Required]
        public string RelationCode { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string NationalityCode { get; set; }
        [Required]
        public string MaritalStatusCode { get; set; }       
        public bool NSSF { get; set; }       
        public int ClassOfCoveragCode { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        [Required]
        public string NetworkLevelCode { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
    }
}