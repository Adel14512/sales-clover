using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace Evaluation.CAL.DTO.Kyc
{
    public class KycDto
    {
        public string ShuftiReference { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string MiddleName { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
