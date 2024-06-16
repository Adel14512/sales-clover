using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request
{
    public class BusinessLineRelatedDocFindWithBusinessLineIdFilterReq :GenericEmptyReq
    {
        public string BusinessLineCode { get; set; }
        public string ApplicationForm { get; set; }
    }
}
