using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL070806
{
    public class AF1BL070806Dtco
    {
        //[Required]
        public string SponsorName { get; set; }
        public bool Ambulatory { get; set; }

        //[Required]
        //public string CountryOfDepartureCode { get; set; }
        //[Required]
        //public string CountryOfDestinationCode { get; set; }
        ////[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the StayTripOption field")]
        //public int NbrDaysWhenLess92 { get; set; }
        //public string StayTripOptionCode { get; set; }
        //public bool HazardousCoverage { get; set; }
        public List<AF1BL070806Dto> AF1BL070806List { get; set; }
    }
}
