﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL041312
{
    public class AF1BL041312Dto
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
        public string Grade { get; set; }
        [Required]
        public string Currency { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        //[Required]
        //public string AnnualWages { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the LimitOfCoverage field")]
        public int LimitOfCoverage { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Shop { get; set; }
    }
}
