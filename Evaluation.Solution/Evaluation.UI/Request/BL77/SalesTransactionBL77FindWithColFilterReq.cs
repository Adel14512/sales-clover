using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Request.BL77
{
    public class SalesTransactionBL77FindWithColFilterReq:GenericEmptyReq
    {
        public int ContactId { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
