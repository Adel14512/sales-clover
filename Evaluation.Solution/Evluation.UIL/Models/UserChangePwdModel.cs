using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UIL.Models
{
    public class UserChangePwdModel
    {
        private const string strPwd = "The New Password field is required.";

        [Required(ErrorMessage = "Current Password is required")]
        [Remote("IsCurrentPwdCorrect", "Register", HttpMethod = "POST", ErrorMessage = "Current Password is not correct.")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = strPwd)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New Password is required")]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirmation New Password must match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
