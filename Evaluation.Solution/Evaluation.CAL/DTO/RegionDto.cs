﻿using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    //[Serializable]
    //[XmlRoot("")]
    public class RegionDto
    {
        public int RecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        //public int BranchCategoryClassId { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
