using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Evaluation.UI.DTO.BL080501
{
    public class SalesTransactionBL080501Dto
    {
        public int RecId { get; set; }
        public string BusinessLineCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int ContactId { get; set; }
        public string PolicyNumber { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public DateTime PolicyIssuedDate { get; set; }
        public AF1BL080501Dtco AF1BL080501 { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
