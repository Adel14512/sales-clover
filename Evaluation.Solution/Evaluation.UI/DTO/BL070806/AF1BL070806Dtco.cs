using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL070806
{
    public class AF1BL070806Dtco
    {
        [Required]
        public string SponsorName { get; set; }
        public bool Ambulatory { get; set; }
        public List<AF1BL070806Dto> AF1BL070806List { get; set; }
    }
}
