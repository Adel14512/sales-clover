using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BusinessLineDetailsProduct
{
    public class BusinessLineDetailsProductDto
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public int ProductId { get; set; }       
        public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]        
        public string Reserved2 { get; set; }
    }
}
