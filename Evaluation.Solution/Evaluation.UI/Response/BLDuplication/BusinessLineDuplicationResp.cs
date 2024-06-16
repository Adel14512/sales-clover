using Evaluation.UI.DTO.BLDuplication;
using Evaluation.UI.Response;
using System;

namespace Evaluation.UI.Response.BLDuplication
{
    public class BusinessLineDuplicationResp :GenericWebResponse
    {
        public BusinessLineDuplicationDto BusinessLineDuplication { get; set; }
    }
}
