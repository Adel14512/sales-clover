using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.ProductDetailsPOIAllNetwork
{
    public class ProductDetailsPOINetworkDto
    {
        public int RecId { get; set; }
        public int ThirdPartyAdminId { get; set; }
        public int NetworkLevel { get; set; }
        public string NetworkName { get; set; }
        public string NetworkExplanation { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
