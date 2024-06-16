using System;

namespace Evaluation.UI.DTO.BL041312Consolidation
{
    public class PaymentScheduleBL041312Dto
    {
        public string PaymentNumberStr { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public bool Paid { get; set; }
        public decimal RemainingAmount { get; set; }
        public string PolicyId { get; set; }
    }
}
