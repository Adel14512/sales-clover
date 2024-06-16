using Evaluation.CAL.DTO;
using System.Collections.Generic;


namespace Evaluation.CAL.Response
{
    public class LookupFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<RegionDto> Region { get; set; }
        public List<ChannelDto> Channel { get; set; }
        public List<GenderDto> Gender { get; set; }
        public List<MaritalStatusDto> MaritalStatus { get; set; }
        public List<RelationDto> Relaion { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<StayTripOptionDto> StayTripOption { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public List<NetworkLevelDto> NetworkLevel { get; set; }
    }
}
