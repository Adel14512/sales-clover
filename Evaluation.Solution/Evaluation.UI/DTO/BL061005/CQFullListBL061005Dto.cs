using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Evaluation.UI.DTO.BL061005
{
   public class CQFullListBL061005Dto
    {
        public int FamilyId { get; set; }
        public string Insurred { get; set; }
        public int ProductId { get; set; }
        public string InsurerProduct { get; set; }
        public string Combination { get; set; }
        public int MemberPerFamily { get; set; }
        public decimal IP { get; set; }
        public decimal CP { get; set; }
        public decimal AF { get; set; }
        public decimal TotalNet { get; set; }
        public string Features { get; set; }
        public int ClassId { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
