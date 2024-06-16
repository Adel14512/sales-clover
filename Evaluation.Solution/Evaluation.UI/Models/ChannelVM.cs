using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class ChannelVM
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [MaxLength(5)]
        public string Code { get; set; }
        [Required]
        public string Type { get; set; }

    }
}
