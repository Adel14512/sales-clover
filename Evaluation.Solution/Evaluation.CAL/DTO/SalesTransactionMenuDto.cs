using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class SalesTransactionMenuDto
    {
        public int RecId { get; set; }
        public string DisplayNameTreeView { get; set; }
        public int ParentId { get; set; }
        public string BusinessLineCode { get; set; }
        public string ClientType { get; set; }
        public string ProductCategory { get; set; }
        public string NbrInsured { get; set; }
        public string ProductType { get; set; }
        public string ProductClass { get; set; }
        public int AF1 { get; set; }
        public string AF1URL { get; set; }
        public int Slip { get; set; }
        public string SlipURL { get; set; }
        public int CQ { get; set; }
        public string CQURL { get; set; }
        public int CQEmail { get; set; }
        public string CQEmailURL { get; set; }
        public int AF2Email { get; set; }
        public string AF2EmailURL { get; set; }
        public string ParentChild { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public string TextForeColor { get; set; }
        public string MenuIcon { get; set; }
        public int CountSalesTrx { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
