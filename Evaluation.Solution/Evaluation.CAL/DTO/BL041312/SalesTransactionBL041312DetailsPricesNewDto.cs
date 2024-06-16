﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL041312
{
    public class SalesTransactionBL041312DetailsPricesNewDto
    {
        public int SalesTrxDetailsId { get; set; }
        public string SectionName { get; set; }
        public string Category { get; set; }
        public string Dependency { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Limit { get; set; }
        public int AgeMinRange { get; set; }
        public int AgeMaxRange { get; set; }
        public decimal Premium { get; set; }
        public decimal Rate { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}