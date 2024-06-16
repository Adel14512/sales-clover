using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class WebRequestCommon
    {
        [Required]
        //[DefaultValue(null)]
        public string UserName { get; set; }
        [Required]
        //[DefaultValue(null)]
        public string CorrelationId { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (UserName == "")
        //    {
        //        yield return new ValidationResult("");
        //    }
        //}
    }
}
