using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO
{
    public class UserSignedDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[!@#$%^&*()_+\-=[\]{};':""\\|,.<>\/?])(?=.*\d).+$",
        ErrorMessage = "Password must have at least one special character and one number")]
        public string Password { get; set; }

    }
}
