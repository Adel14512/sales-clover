using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL010602
{
    public class AF1BL010602Dtco
    {
        [Required]
        public string CountryOfDepartureCode { get; set; }
        [Required]
        public string CountryOfDestinationCode { get; set; }
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        public int NbrDaysWhenLess92 { get; set; }
        public string StayTripOptionCode { get; set; }
        public bool HazardousCoverage { get; set; }        
        public List<AF1BL010602Dto> AF1BL010602List { get; set; }
    }
}
