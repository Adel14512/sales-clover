using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Request
{
    public class SalesTransactionMenuFindWithColFilterReq : GenericEmptyReq
    {
        public string ClientType { get; set; }
        public int ContactId { get; set; }
    }
}
