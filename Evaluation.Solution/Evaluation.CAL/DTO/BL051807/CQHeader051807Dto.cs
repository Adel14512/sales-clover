﻿using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL051807
{
    public class CQHeader051807Dto
    {
        public string TicketCode { get; set; }
        public DateTime OpenDate { get; set; }
        public string CreatedBy { get; set; }
        public string ContactName { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
