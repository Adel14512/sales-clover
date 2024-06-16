
using Evaluation.UI.DTO.BLDuplication;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BLDuplication
{
    public class BusinessLineDuplicationNewRecReq :GenericEmptyReq
    {

        [Required]
        public BusinessLineDuplicationNewDto BusinessLineDuplication  { get; set; }
    }
}
