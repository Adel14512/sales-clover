﻿using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL321110
{
    public class CQCategory321110
    {
        public int CatNbr { get; set; }
        public int Cnt { get; set; }
        public string ClassOfCoverage { get; set; }
        public string Ambulatory { get; set; }
        public string PrescriptionMedicine { get; set; }
        public string DoctorVisit { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}