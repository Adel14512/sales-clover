using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL321110
{
    public class Slip2BL321110Dto
    {
        public string Category { get; set; }
        public int CateMembers { get; set; }
        public string Grade { get; set; }
        public string Class { get; set; }
        public bool Ambulatory { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool DoctorVisit { get; set; }
        public bool Dental { get; set; }
        public bool Optical { get; set; }
        public decimal AmlAMount { get; set; }
        public bool E_NoUnderwriting { get; set; }
        public bool E_Continuity { get; set; }
        public string E_NoWaitingPeriod { get; set; }
        public bool E_Renewability { get; set; }
        public bool N_NoUnderwriting { get; set; }
        public bool N_Continuity { get; set; }
        public string N_NoWaitingPeriod { get; set; }
        public bool N_Renewability { get; set; }
    }
}
