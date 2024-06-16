﻿using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL281609
{
    public class CQHeader281609Dto
    {
        public string TicketCode { get; set; }
        public DateTime OpenDate { get; set; }
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}