using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Models
{
    public class LeadNewDto
    {
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the LeadStatusId field")]
        public int LeadStatusId { get; set; }
        public int? CountryId { get; set; }
        public string Owner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EMail { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string Topic { get; set; }
        public string BusinessLine { get; set; }
        public int? LeadSourceId { get; set; }
        public int? LeadSaleId { get; set; }
        public string SummaryFeedback { get; set; }
        public DateTime? NextActionDate { get; set; }
    }
}
