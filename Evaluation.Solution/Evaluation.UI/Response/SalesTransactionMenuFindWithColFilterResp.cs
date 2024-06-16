
using Evaluation.UI.Models;
using Evaluation.UI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Response
{
    public class SalesTransactionMenuFindWithColFilterResp : GenericWebResponse
    {
        public List<SalesTransactionMenuDto> SalesTransactionMenu { get; set; }
    }
}
