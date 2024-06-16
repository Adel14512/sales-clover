using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO
{
    public class GenderUpdDto
    {
        //public int RecId { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the RecId field")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid integer Number")]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int RecId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        //[Required(ErrorMessage = "CreatedBy is required")]
        //[MaxLength(50, ErrorMessage = "Max Length EQ 5")]
        //public string CreatedBy { get; set; }
    }
}
