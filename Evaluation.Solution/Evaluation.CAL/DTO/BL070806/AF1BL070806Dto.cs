﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL070806
{
    public class AF1BL070806Dto
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
    }
}
