using Evaluation.UI.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Request.BL291908
{
    public class SalesTransactionBL291908FindCQShortFullListWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
