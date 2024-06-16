using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.Global
{
    public class ClientCodeDto
    {
        public decimal Code { get; set; }
        public string Name { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Maiden { get; set; }
        public string PrimaryKey { get; set; }
        public string Types { get; set; }
        public string Id { get; set; }
        public string Idc { get; set; }
        public string Passport { get; set; }
        public string Passportc { get; set; }
        public string Iqama { get; set; }
        public string Iqamac { get; set; }
        public string Vat { get; set; }
        public string Cr { get; set; }
        public string Fiscal { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Countries { get; set; }
        public string Regions { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Department { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public decimal Broker { get; set; }
        public decimal Master { get; set; }
        public decimal Cell { get; set; }
        public string CpCode { get; set; }
        public decimal Pr { get; set; }
        public string Bankc { get; set; }
        public string Bearerc { get; set; }
        public string Cpcc { get; set; }
        public string Cpbt { get; set; }
        public string Hrms { get; set; }
        public string Estab { get; set; }
        public string AzadeaClt { get; set; }
        public decimal Pdid { get; set; }
        public decimal Cbcp { get; set; }
        public decimal Cbca { get; set; }
        public decimal Endp { get; set; }
        public decimal Enda { get; set; }
        public decimal Clmp { get; set; }
        public decimal Clma { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
