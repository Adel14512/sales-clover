using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL321110
{
    public class Slip3BL321110Dto
    {
        public string Category { get; set; }
        public string Section { get; set; }
        public string Class { get; set; }
        public string TerritorialScope { get; set; }
        public decimal Co_InsurancePer { get; set; }
        public decimal Co_Insurance_Amt { get; set; }
        public decimal LimitAmount { get; set; }
        public string NetworkLevel { get; set; }
        public string Network { get; set; }
        public bool Covered { get; set; }
    }
}
