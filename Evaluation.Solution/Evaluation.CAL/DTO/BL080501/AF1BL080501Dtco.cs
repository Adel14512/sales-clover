using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL080501
{
    public class AF1BL080501Dtco
    {
        //[Required]
        public string ResidenceCode { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public string NetworkLevelCode { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool NSSF { get; set; }
        public List<AF1BL080501Dto> AF1BL080501List { get; set; }
    }
}
