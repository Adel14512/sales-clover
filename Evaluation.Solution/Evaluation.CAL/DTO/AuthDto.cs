using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class AuthDto
    {
        [Required]
        [MaxLength(20)]
        public string ClientId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Scope { get; set; }
        [Required]
        [MaxLength(20)]
        public string Client_Secret { get; set; }
        [Required]
        [MaxLength(20)]
        public string Grant_Type { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
