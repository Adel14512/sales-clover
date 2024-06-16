using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.DTO.BL041312
{
    public class Slip2BL041312Dto
    {
        public string Category { get; set; }
        public int CateMembers { get; set; }
        public string Grade { get; set; }
        public int MaxLimit { get; set; }
        public int MinLimit { get; set; }
    }
}
