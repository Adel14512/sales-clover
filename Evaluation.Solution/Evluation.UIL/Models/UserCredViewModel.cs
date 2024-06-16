using System.ComponentModel.DataAnnotations;

namespace Evaluation.UIL.Models
{
    public class UserCredViewModel
    {
        private const string strPwd = "The Password field is required.";

        [Required(ErrorMessage = "The User Name field is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = strPwd)]
        public string Password { get; set; }
    }
}
