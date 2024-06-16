using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL090703
{
    public class AF1BL090703Dto
    {

        [Required]
        public string FirstName { get; set; }
        //[Required]
        public string MiddleName { get; set; }
        //[Required]
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
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
