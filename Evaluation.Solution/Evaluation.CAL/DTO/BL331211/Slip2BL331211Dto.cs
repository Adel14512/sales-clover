using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL331211
{
    public class Slip2BL331211Dto
    {
        public string Category { get; set; }
        public int CateMembers { get; set; }
        public string Grade { get; set; }
        public int MaxLimit { get; set; }
        public int MinLimit { get; set; }
    }
}
