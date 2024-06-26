﻿using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO
{
    public class RegionNewDto
    {
        //public int RecId { get; set; }
        [Required]
        [MinLength(2), MaxLength(2, ErrorMessage = "The Code Length should be EQ to 2")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        //public bool IsActive { get; set; }
        //[Required(ErrorMessage = "CreatedBy is required")]
        //[MaxLength(50, ErrorMessage = "Max Length EQ 5")]
        //public string CreatedBy { get; set; }
    }
}
