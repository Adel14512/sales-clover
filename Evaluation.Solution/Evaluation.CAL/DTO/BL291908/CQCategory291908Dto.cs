﻿using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL291908
{
    public class CQCategory291908Dto
    {
        public int CatNbr { get; set; }
        public int Cnt { get; set; }
        //public string AnnualWages { get; set; }
        public int LimitOfCoverage { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}