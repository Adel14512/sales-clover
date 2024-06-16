using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class UserCredViewModel
    {
        
        //[Required]
        //[EmailAddress]
        public string UserName { get; set; }
        //[Required]
        //[RegularExpression(@"^(?=.*[!@#$%^&*()_+\-=[\]{};':""\\|,.<>\/?])(?=.*\d).+$",
        //ErrorMessage = "Password must have at least one special character and one number")]
        public string Password { get; set; }
    }
}
