using Evaluation.UI.Response;

namespace Evaluation.UI.Models
{
    public class BL77VM
    {
        public BL77VM() {
            Channels = new List<ChannelResp>();
            Regions = new List<RegionResp>();
            Genders = new List<GenderResp>();
            MaritalStatuses = new List<MaritalStatusResp>();
            SalesTransactionBL77Dto = new SalesTransactionBL77Dto();
        }
        public SalesTransactionBL77Dto SalesTransactionBL77Dto { get; set; }
        public List<ChannelResp> Channels { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
        public List<MaritalStatusResp> MaritalStatuses { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
