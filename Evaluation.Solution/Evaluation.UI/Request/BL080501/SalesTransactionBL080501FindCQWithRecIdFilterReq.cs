using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Request.BL080501
{
    public class SalesTransactionBL080501FindCQWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
