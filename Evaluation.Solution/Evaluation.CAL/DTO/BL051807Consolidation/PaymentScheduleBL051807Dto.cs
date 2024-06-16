using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.DTO.BL051807Consolidation
{
    public class PaymentScheduleBL051807Dto
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
