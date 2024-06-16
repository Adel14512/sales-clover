using Evaluation.UI.DTO;
using System.Reflection;
using System.Threading.Channels;

namespace Evaluation.UI.Response
{
    public class GeneralListResp
    {
        public WebResponseCommonResp webResponseCommon { get; set; }
        public List<RegionResp> region { get; set; }
        public List<ChannelResp> channel { get; set; }
        public List<MaritalStatusResp> maritalStatus { get; set; }
        public List<GenderResp> gender { get; set; }
        public List<RelationDto> Relaion { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<StayTripOptionDto> StayTripOption { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public List<NetworkLevelDto> NetworkLevel { get; set; }

    }
}
