using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.ExcelImportModel
{
    public class ProductListEM
    {

        public string ProductCategory { get; set; }
        public string ProductClass { get; set; }
        public string ProductName { get; set; }
        public string Insurer { get; set; }
        public string ThirdPartyAdmin { get; set; }
        public string Currency { get; set; }
        public string CreationDate { get; set; }
        public string ActivationDate { get; set; }
    }
}
