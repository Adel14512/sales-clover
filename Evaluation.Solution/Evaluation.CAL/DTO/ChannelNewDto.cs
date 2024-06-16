using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO
{
    public class ChannelNewDto
    {
        //public int RecId { get; set; }
        [Required]
        [MinLength(5), MaxLength(5, ErrorMessage = "The Code Length should be EQ to 5")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [MaxLength(5)]
        public string Type { get; set; }
        //public bool IsActive { get; set; }
        //[Required(ErrorMessage = "CreatedBy is required")]
        //[MaxLength(50, ErrorMessage = "Max Length EQ 5")]
        //public string CreatedBy { get; set; }
    }
}
