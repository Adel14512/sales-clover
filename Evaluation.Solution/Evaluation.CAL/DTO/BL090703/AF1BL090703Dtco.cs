using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL090703
{
    public class AF1BL090703Dtco
    {
        //[Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public string NetworkLevelCode { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        //public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL090703Dto> AF1BL090703List { get; set; }
    }
}
