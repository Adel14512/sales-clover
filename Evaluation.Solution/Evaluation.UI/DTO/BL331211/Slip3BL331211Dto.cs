using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL331211
{
    public class Slip3BL331211Dto
    {
        public string Category { get; set; }
        public string Section { get; set; }
        public int LimitAmount { get; set; }
        public decimal Co_InsurancePer { get; set; }
        public bool Covered { get; set; }
    }
}
