namespace Evaluation.UI.Models
{
    public class TransactionVM
    {
        public TransactionVM() {
            Tabs = new List<Tab>();
        }
        public List<Tab> Tabs { get; set; }
        public string JsonTreewView { get; set; }
        public class Tab
        {
            public int Id { get; set; }
            public string Icon { get; set; }
            public string Name { get; set; }
        }
    }
}
