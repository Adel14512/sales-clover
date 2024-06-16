using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO
{
    public class GenderNewDto
    {
        //public int RecId { get; set; }
        [Required]
        [MinLength(1), MaxLength(1, ErrorMessage = "The Code Length should be EQ to 1")]
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
