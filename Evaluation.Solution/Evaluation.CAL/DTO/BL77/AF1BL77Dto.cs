﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL77
{
    public class AF1BL77Dto
    {
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the Serial field")]
        public int Serial { get; set; }
        [Required]
        public string Company { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StaffNbr field")]
        public int StaffNbr { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string GenderCode { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string NationalityCode { get; set; }
        [Required]
        public string MaritalStatusCode { get; set; }
        [Required]
        public string CountryOfDepartureCode { get; set; }
        [Required]
        public string CountryOfDestinationCode { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        public string StayTripOption { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the NbrDaysWhenLess92 field")]
        public int NbrDaysWhenLess92 { get; set; }
    }
}