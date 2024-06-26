﻿using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL281609Consolidation
{
    public class PolicyRelatedDocBL281609Dto
    {
        public int RecId { get; set; }
        public int SalesTransactionId { get; set; }
        public int TicketId { get; set; }
        public string ParentPolicyId { get; set; }
        public string PolicyId { get; set; }
        public string BusinessLineCode { get; set; }
        public string DocumentType { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
