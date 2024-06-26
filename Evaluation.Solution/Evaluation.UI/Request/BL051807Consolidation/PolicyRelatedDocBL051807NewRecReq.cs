﻿using Evaluation.UI.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Request.BL051807Consolidation
{
    public class PolicyRelatedDocBL051807NewRecReq : GenericEmptyReq
    {
       
        public int SalesTransactionId { get; set; }
        public int TicketId { get; set; }
        public string ParentPolicyId { get; set; }
        public string PolicyId { get; set; }
        public string BusinessLineCode { get; set; }
        public string DocumentType { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
