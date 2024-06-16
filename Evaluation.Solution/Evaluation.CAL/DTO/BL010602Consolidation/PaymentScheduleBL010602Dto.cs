using System;

namespace Evaluation.CAL.DTO.BL010602Consolidation
{
    public class PaymentScheduleBL010602Dto
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
