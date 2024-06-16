using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL080501
{
    public class AF1BL080501Dtco
    {
        [Required]
        public string ResidenceCode { get; set; }
        [Required]
        public string NetworkLevelCode { get; set; }
        [Required]
        public int ClassOfCoveragCode { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        [Required]
        public bool Ambulatory { get; set; }
        [Required]
        public bool PrescriptionMedecine { get; set; }
        [Required]
        public bool DoctorVisit { get; set; }
        [Required]
        public bool NSSF { get; set; }
        public List<AF1BL080501Dto> AF1BL080501List { get; set; }

       
    }
}
