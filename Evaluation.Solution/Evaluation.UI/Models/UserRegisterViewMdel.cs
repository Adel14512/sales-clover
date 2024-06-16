using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class UserRegisterViewMdel
    {
        private const string strPwd = "The Password field is required.";

        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The User Name field is required.")]
        [Remote("IsAlreadySigned", "Register", HttpMethod = "POST", ErrorMessage = "User Name already exists in database.")]
        public string UserName { get; set; }

        //[Remote(action: "RegisterUser", controller: "Register")]

        //[Required(ErrorMessage = "The Email Address is required field")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        //[Required(ErrorMessage = "The Email is required field"), RegularExpression("^(.+)@(.+)$", ErrorMessage = "The Email field is not a valid e-mail address")]
        [Required(ErrorMessage = "The Email field is required."), RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "The Email field is not a valid e-mail address.")]

        public string EmailAdress { get; set; }

        [Required(ErrorMessage = strPwd)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}
