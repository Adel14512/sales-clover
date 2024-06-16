using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL061005
{
    public class AF1BL061005Dto
    {
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
        [Required]
        public string CountryOfResidenceCode { get; set; }
        [Required]
        public string RequestedLimitCurrency { get; set; }
        [Required]
        public string Occupation { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the LimitOfCoverage field")]
        [Required]
        public string ReasonOfInsurance { get; set; }
    }
}
